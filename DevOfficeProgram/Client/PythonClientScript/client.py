import time, socket, sys, pyautogui
from datetime import datetime

socket_server = socket.socket()
server_host = socket.gethostname()
ip = socket.gethostbyname(server_host)
sport = 8080

print('This is your IPv4 address: ', ip)

server_host = sys.argv[1]
login_name = sys.argv[2]
print('Your login name is: ', login_name)

socket_server.connect((server_host, sport))

join_message = "User " + login_name + " has activated WorkCheck."

socket_server.send(join_message.encode())
server_name = socket_server.recv(1024)
server_name = server_name.decode()

time_counter = 0
received_bool = False

print(server_name, ' - Connected to the host. WorkCheck service will be running as long as you run DevOffice.')
while True:

    if time_counter >= 30:

        now = datetime.now()
        current_time = now.strftime("%H%M%S")

        sending_msg = 'Sending'
        print(sending_msg)
        socket_server.send(sending_msg.encode())

        while True:
            started_receive = socket_server.recv(1024)
            if 'Receiving' in started_receive.decode():
                print('Host received our request.')
                ss = pyautogui.screenshot()
                ss.save(current_time + ".png")
                f = open(current_time + '.png', 'rb')
                while True:
                    l_f = f.read()
                    while l_f:
                        socket_server.send(l_f)
                        l_f = f.read()
                    socket_server.send(b"Sent")
                    f.close()
                    print('Sent successfully.')

                    while True:
                        received = socket_server.recv(1024)
                        print(received)
                        if b'Received' in received:
                            received_bool = True
                            print('Host has received the screenshot.')
                            break
                    break
            if received_bool:
                received_bool = False
                break
        time_counter = 0

    time_counter = 30
    time.sleep(30.0)



