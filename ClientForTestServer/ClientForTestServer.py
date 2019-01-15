import socket
import threading as th

sock = socket.socket()
sock.connect(('127.0.0.1', 11005))

print("""
1 - Remote control (0x33 0xFF 0x34)
2 - Local control (0x33 0x01 0x03)
3 - Set Parameters (BAD) (0x33 0x01 0x03 0x01 0x01 0x35)
4 - Set Parameters (0x33 0x02 0x01 0x02 0x02 0x55)
5 - Start stream record (0x33 0xFC 0x03)
6 - Stop stream record (0x33 0xFD 0x03)
7 - Check is main program busy
8 - Get syncs states
9 - disconect
""")

def transfer_rcv_data (transfer_data):
    sock.send(transfer_data)
    data = sock.recv(1024)
    print(data)

while True:    
    transfer = int(input("Select number? "))

    if transfer == 1:
        # Дистанционное управление
        transfer_rcv_data(b"\x33\xFF\x34")
    elif transfer == 2:
        # Местное управление
        transfer_rcv_data(b"\x33\x01\x03")
    elif transfer == 3:
        # Параметры приема битового потока
        transfer_rcv_data(b"\x33\x01\x03\x01\x01\x35")
    elif transfer == 4:
        # Параметры приема битового потока
        transfer_rcv_data(b"\x33\x02\x01\x02\x01\x55")
    elif transfer == 5:
        # Начать запись
        transfer_rcv_data(b"\x33\xFC\x03")
    elif transfer == 6:
        # Остановить запись
        transfer_rcv_data(b"\x33\xFD\x03")
    elif transfer == 7:
        # Отсылка одновременно двух сообщений, для проверки кода ошибки "Пред. команда еще не выполнена." (Нужно поставить задержку в выполнении команды применения настроек)
        m1 = th.Thread(target=transfer_rcv_data, args=(b"\x33\x02\x01\x02\x02\x55",))
        m2 = th.Thread(target=transfer_rcv_data, args=(b"\x33\xFC\x03",))
        m1.start()
        m2.start()
        m1.join()
        m2.join()
    elif transfer == 8:
        # Проверить синхронизацию.
        transfer_rcv_data(b"\x33\x03\x03")
    elif transfer == 9:
        break

sock.close()

