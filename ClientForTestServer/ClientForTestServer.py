import socket
import threading as th
import array

sock = socket.socket()
sock.connect(('127.0.0.1', 2503))

print("""
###################################################################
#                                                                 #
#   Mode                                                          #
#   |------|----------|---------|                                 #
#   |  0   |    1     |    2    |                                 #
#   |------|----------|---------|                                 #
#   | 0x33 | 0x1/0xFF |         |                                 #
#   |------|----------|---------|                                 #
#                                                                 #
#   0 - Header                                                    #
#   1 - Mode (1 - Local, FF - Remote)                             #
#   2 - Reserved                                                  #
#                                                                 #
###################################################################
#                                                                 #
#   Set Parameters                                                #
#   |------|---------|---------|---------|---------|----------|   #
#   |  0   |    1    |    2    |    3    |    4    |    5     |   #
#   |------|---------|---------|---------|---------|----------|   #
#   | 0x33 | 0x1/0x2 | 0x1/0x2 | 0x1/0x2 | 0x1/0x2 |          |   #
#   |------|---------|---------|---------|---------|----------|   #
#                                                                 #
#   0 - Header                                                    #
#   1 - FCP (1 - O, 2 - R)                                        #
#   2 - PRD (1 - O, 2 - R)                                        #
#   3 - Freq (1 - 137.1, 2 - 137.9)                               #
#   4 - Interliving (1 - On, 2 - Off)                             #
#   5 - Reserved                                                  #
#                                                                 #
###################################################################
#                                                                 #
#   Start/Stop recording                                          #
#   |------|-----------|---------|                                #
#   |  0   |    1      |    2    |                                #
#   |------|-----------|---------|                                #
#   | 0x33 | 0xFC/0xFD |         |                                #
#   |------|-----------|---------|                                #
#                                                                 #
#   0 - Header                                                    #
#   1 - Start/Stop (FC - Start, FD - Stop)                        #
#   2 - Reserved                                                  #
#                                                                 #
###################################################################
#                                                                 #
#   Sync                                                          #
#   |------|-----|-----|                                          #
#   |  0   |  1  |  2  |                                          #
#   |------|-----|-----|                                          #
#   | 0x33 | 0x3 |     |                                          #
#   |------|-----|-----|                                          #
#                                                                 #
#   0 - Header                                                    #
#   1 - Check Sync                                                #
#   2 - Reserved                                                  #                         
#                                                                 #
###################################################################

""")

def transfer_rcv_data (transfer_data):
    sock.send(transfer_data)
    data = sock.recv(1024)
    print(f"\ndec - {[x for x in data]}")
    print(f"hex - {[hex(x) for x in data]}")
    print(f"oct - {[oct(x) for x in data]}\n")


while True:    
    inputCommand = input("Input command: ")
    if inputCommand == "exit":
        break
    command = array.array("B", [int(x, 16) for x in inputCommand.split()]).tostring()
    transfer_rcv_data(command)

sock.close()

