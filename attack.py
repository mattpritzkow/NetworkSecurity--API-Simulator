import requests
import random
import string

def menu():
    print("[1]: Enter Valid User Credentials")
    print("[2]: Randomly Generate UID")
    print("[0]: Exit")

def verified():
    userN = input("Enter Username: ")
    uid = input("Enter UID: ")
    loop = int(input("How Many Requests? (int): "))
    print()
    for i in range(loop):
        r = requests.get('http://localhost:8081/warzone-matches/' + userN + '/' + uid)
        print("Request Number " + str(i + 1) + ":")
        print("Status Code: " + str(r.status_code))
        print("URL: " + r.url)
        print("Verified Request's Text: " + r.text)
        print()

def unverified():
    userN = input("Enter Username: ")
    num = int(input("How Many Digits in the UID (9 or 10)?: "))
    loop = int(input("How Many Requests? (int): "))
    print()
    for i in range(loop):
        rand = (''.join(random.choice(string.digits) for i in range(num)))
        r = requests.get('http://localhost:8081/warzone-matches/' + userN + '/' + rand)
        print("Request Number " + str(i + 1) + ":")
        print("UID Guessed: " + rand)
        print("URL: " + r.url)
        print("Unverified Request Text: " + r.text)
        print()

def main():
    menu()
    option = int(input("Enter Your Choice: "))
    print()

    while option != 0:
        if option == 1:
            verified()
        elif option == 2:
            unverified()
        else:
            print("Invalid Option")

        print()
        menu()
        option = int(input("Enter Your Choice: "))
        print()
    print("Exiting Script Now")

if __name__ == "__main__":
    main()