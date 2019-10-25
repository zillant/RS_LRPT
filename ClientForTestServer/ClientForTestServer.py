import socket
import threading as th

sock = socket.socket()
sock.connect(('127.0.0.1', 2503))

print("""
1 - Remote control (0x33 0xFF 0x34)
2 - Local control (0x33 0x01 0x03)
3 - Set Parameters (0x33 0x01 0x01 0x01 0x01 0x55)
4 - Start stream record (0x33 0xFC 0x03)
5 - Stop stream record (0x33 0xFD 0x03)
6 - Check is main program busy (0x33 0x02 0x01 0x02 0x02 0x55) (0x33 0xFC 0x03)
7 - Get syncs states (0x33 0x03 0x03)

# BAD COMMANDS
11 - (0x33 0x02 0x02 0x02 0x03 0x09)
12 - (0x33 0x0A)
13 - (0x00 0x02 0x02 0x02 0x02 0x0B)
14 - (0x00 0x02 0x02 0x02 0x02)
15 - (0x33 0xFF 0x0C)
16 - (0x33 0x01 0x03)(0x33 0x03 0x0C)
17 - (0x33 0xFF 0x03)(0x33 0xFC 0x03)
18 - (0x33 0x02 0x02 0x02 0x02 0x02)
19 - (0x33 0x03 0x0F)
20 - (0x33 0xFC 0x09)

30 - disconect
""")

def transfer_rcv_data (transfer_data):
    sock.send(transfer_data)
    data = sock.recv(1024)
    print(f"\ndec - {[x for x in data]}")
    print(f"hex - {[hex(x) for x in data]}")
    print(f"oct - {[oct(x) for x in data]}\n")


while True:    
    transfer = int(input("Enter the number: "))

    if transfer == 1:
        # Дистанционное управление
        transfer_rcv_data(b"\x33\xFF\x03")
    elif transfer == 2:
        # Местное управление
        transfer_rcv_data(b"\x33\x01\x03")
    elif transfer == 3:
        # Параметры приема битового потока
        transfer_rcv_data(b"\x33\x01\x02\x01\x02\x55")
    elif transfer == 4:
        # Начать запись
        transfer_rcv_data(b"\x33\xFC\x03")
    elif transfer == 5:
        # Остановить запись
        transfer_rcv_data(b"\x33\xFD\x03")
    elif transfer == 6:
        # Отсылка одновременно двух сообщений, для проверки кода ошибки "Пред. команда еще не выполнена." (Нужно поставить задержку в выполнении команды применения настроек)
        m1 = th.Thread(target=transfer_rcv_data, args=(b"\x33\x02\x01\x02\x02\x55",))
        m2 = th.Thread(target=transfer_rcv_data, args=(b"\x33\xFC\x03",))
        m1.start()
        m2.start()
        m1.join()
        m2.join()
    elif transfer == 7:
        # Проверить синхронизацию.
        transfer_rcv_data(b"\x33\x03\x03")

    # ---------- Ошибочные КМС ----------
    elif transfer == 11:
        transfer_rcv_data(b"\x33\x02\x02\x02\x03\x09")
    elif transfer == 12:
        transfer_rcv_data(b"\x33\x0A")
    elif transfer == 13:
        transfer_rcv_data(b"\x00\x02\x02\x02\x02\x0B")
    elif transfer == 14:
        transfer_rcv_data(b"\x00\x02\x02\x02\x02")
    elif transfer == 15:
        transfer_rcv_data(b"\x33\xFF\x0C")
    elif transfer == 16:
        transfer_rcv_data(b"\x33\x01\x03")
        transfer_rcv_data(b"\x33\x03\x0C")
    elif transfer == 17:
        transfer_rcv_data(b"\x33\xFF\x03")
        transfer_rcv_data(b"\x33\xFC\x03")
    elif transfer == 18:
        transfer_rcv_data(b"\x33\x02\x02\x02\x02\x02")
    elif transfer == 19:
        transfer_rcv_data(b"\x33\x03\x0F")
    elif transfer == 20:
        transfer_rcv_data(b"\x33\xFC\x09")

    # ---------- Выход ----------
    elif transfer == 30:
        break

sock.close()

