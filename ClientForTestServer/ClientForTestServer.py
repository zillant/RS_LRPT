import socket
import threading as th
import array

sock = socket.socket()
sock.connect(('127.0.0.1', 2503))

print("""
#####################################################################################################################################
#                                                                 #                                                                 # 
#   Mode (KMC)                                                    #   Mode (KB)                                                     #
#   |------|----------|---------|                                 #   |------|----------|---------|-----------|                     #
#   |  0   |    1     |    2    |                                 #   |  0   |    1     |    2    |     3     |                     #
#   |------|----------|---------|                                 #   |------|----------|---------|-----------|                     #
#   | 0x33 | 0x1/0xFF |         |                                 #   | 0x33 |   KMC    |         | 0x0 - 0x7 |                     #
#   |------|----------|---------|                                 #   |------|----------|---------|-----------|                     #
#                                                                 #                                                                 #
#   0 - Header                                                    #   0 - Header                                                    #
#   1 - Mode (1 - Local, FF - Remote)                             #   1 - KMC Value                                                 #
#   2 - Reserved                                                  #   2 - Reserved                                                  #
#                                                                 #   3 - Error code                                                #
#                                                                 #                                                                 #   
#####################################################################################################################################
#                                                                 #                                                                 #
#   Set Parameters (KMC)                                          #   Set Parameters (KB)                                           #
#   |------|---------|---------|---------|---------|----------|   #   |------|---|---|---|---|----------|-----------|               #
#   |  0   |    1    |    2    |    3    |    4    |    5     |   #   |  0   | 1 | 2 | 3 | 4 |    5     |     6     |               #
#   |------|---------|---------|---------|---------|----------|   #   |------|---|---|---|---|----------|-----------|               #
#   | 0x33 | 0x1/0x2 | 0x1/0x2 | 0x1/0x2 | 0x1/0x2 |          |   #   | 0x33 |     KMC       |          | 0x0 - 0x7 |               #
#   |------|---------|---------|---------|---------|----------|   #   |------|---------------|----------|-----------|               #
#                                                                 #                                                                 #
#   0 - Header                                                    #   0 - Header                                                    #
#   1 - FCP (1 - O, 2 - R)                                        #   1 - FCP (KMC Value)                                           #
#   2 - PRD (1 - O, 2 - R)                                        #   2 - PRD (KMC Value)                                           #
#   3 - Freq (1 - 137.1, 2 - 137.9)                               #   3 - Freq (KMC Value)                                          #
#   4 - Interliving (1 - On, 2 - Off)                             #   4 - Interliving (KMC Value)                                   #
#   5 - Reserved                                                  #   5 - Reserved                                                  #
#                                                                 #   6 - Error code                                                #
#                                                                 #                                                                 #          
#####################################################################################################################################
#                                                                 #                                                                 #
#   Start/Stop recording (KMC)                                    #   Start/Stop recording (KB)                                     #
#   |------|-----------|---------|                                #   |------|----------|---------|-----------|                     #
#   |  0   |    1      |    2    |                                #   |  0   |    1     |    2    |     3     |                     #
#   |------|-----------|---------|                                #   |------|----------|---------|-----------|                     #
#   | 0x33 | 0xFC/0xFD |         |                                #   | 0x33 |   KMC    |         | 0x0 - 0x7 |                     #
#   |------|-----------|---------|                                #   |------|----------|---------|-----------|                     #
#                                                                 #                                                                 #
#   0 - Header                                                    #   0 - Header                                                    #
#   1 - Start/Stop (FC - Start, FD - Stop)                        #   1 - KMC Value                                                 #
#   2 - Reserved                                                  #   2 - Reserved                                                  #
#                                                                 #   3 - Error code                                                #
#                                                                 #                                                                 #   
#####################################################################################################################################
#                                                                 #                                                                 #
#   Sync (KMC)                                                    #   Sync (KB)                                                     #
#   |------|-----|-----|                                          #   |------|-------|----------|----------|-------|-----------|    #
#   |  0   |  1  |  2  |                                          #   |  0   |   1   |     2    |     3    |   4   |    5      |    #
#   |------|-----|-----|                                          #   |------|-------|----------|----------|-------|-----------|    #
#   | 0x33 | 0x3 |     |                                          #   | 0x33 |  KMC  | 0x0/0xFF | 0x0/0xFF |       | 0x0 - 0x7 |    #
#   |------|-----|-----|                                          #   |------|-------|----------|----------|-------|-----------|    #
#                                                                 #                                                                 #
#   0 - Header                                                    #   0 - Header                                                    #
#   1 - Check Sync                                                #   1 - KMC Value                                                 #
#   2 - Reserved                                                  #   2 - Signal Sync (0 - Yes, FF - No )                           #                         
#                                                                 #   3 - Interliving Sync (0 - Yes, FF - No )                      #
#                                                                 #   4 - Reserved                                                  #
#                                                                 #   5 - Error code                                                #
#                                                                 #                                                                 #   
#####################################################################################################################################
#                                                                 #                                                                 #   
#   Errors Codes                                                  #   
#   |-----------------------|-----|                               #  
#   | Success KMC           |  0  |                               #
#   |-----------------------|-----|                               #
#   | Fail KMC              |  1  |                               #
#   |-----------------------|-----|                               #
#   | Parametres not set    |  2  |                               #
#                               |-----------------------|-----|                               #
#   | KPA in local mode     |  3  |                               #
#   |-----------------------|-----|                               #
#   | KPA in remote mode    |  4  |                               #
#   |-----------------------|-----|                               #
#   | Record in progress    |  5  |                               #
#   |-----------------------|-----|                               #
#   | Record isnt start     |  6  |                               #
#   |-----------------------|-----|                               #
#   | Last KMC not complete |  7  |                               #
#   |-----------------------|-----|                               #
#                                                                 #   
###################################################################

Input "exit" for quit.

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

