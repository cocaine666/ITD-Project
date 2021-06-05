import time, socket, sys
from datetime import datetime
from typing import BinaryIO
from os import path

new_socket = socket.socket()
host_name = socket.gethostname()
s_ip = socket.gethostbyname(host_name)

port = 8080

new_socket.bind((host_name, port))
print("Binding successful!")
print("This is your IP: ", s_ip)

name = sys.argv[1]

new_socket.listen(1)

conn, add = new_socket.accept()

print("Received connection from ", add[0])
print('Connection Established. Connected From: ', add[0])
client = (conn.recv(1024)).decode()
print(client)
f_user = open("C:/WorkCheckServer/Users/test_user.usr", 'w+')
f_user.write("1")
f_user.close()
conn.send(name.encode())
while True:
    while True:
        receive = conn.recv(1024)
        if 'Sending' in receive.decode():
            conn.send('Receiving'.encode())
            break
    now = datetime.now()
    current_time = now.strftime("%H%M%S")
    f = open('C:/WorkCheckServer/Screenshots/' + current_time + '_received' + '.png', 'wb')
    l_f = conn.recv(4096000)
    while l_f:
        f.write(l_f)
        l_f = conn.recv(4096000)
        if b'Sent' in l_f:
            break

    print('Closed file.')
    f.close()
    print('Received.')
    conn.send(b"Received")
    print("Received screenshot from client.")
    time.sleep(1.0)


