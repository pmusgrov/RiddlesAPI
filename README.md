# RiddlesAPI

## How to Request Data

The RiddlesAPI utilizes HTTP endpoints for communication purposes. The RiddlesAPI has three get endpoints (for getting all riddles, getting a riddle by id, and getting a riddle by number). Additionally, RiddlesAPI has a POST endpoint to add a riddle, a PUT endpoint to edit a riddle by id, and delete endpoint to delete a riddle by id. 

The routes for each endpoint are as follows:
GET all: {host}/api/Riddles
GET by id: {host}/api/Riddles/{id}
GET by number: {host}/api/Riddles/{number}
POST: {host}/api/Riddles
PUT by id: {host}/api/Riddles/{id}
DELETE by id: {host}/api/Riddles/{id}

{host} is set to https://localhost:7278

## How To Recieve

The Riddles API returns JSON riddle objects with the following schema:
Riddles{
    id	    string
            nullable: true
    number	integer($int32)
    riddle	string
            nullable: true
    answer	string
            nullable: true
}

## Example Call

An example for how the request/recieve data in python is shown below for GET routes:

import requests
def test_get_methods():
    base_url = "https://localhost:7278/api/Riddles"

    try:
        # Test GetAsync() method, verify False due to https/vpn
        response = requests.get(base_url, verify=False)
        response.raise_for_status()
        all_riddles = response.json()
        print("All Riddles:")
        for riddle in all_riddles:
            print(f"ID:{riddle['id']}\nNumber:{riddle['number']}\nRiddle: {riddle['riddle']}\n"
                  f"Answer: {riddle['answer']}\n")

        # Test GetAsync(id) method with a sample ID, verify False for https/vpn
        sample_id = "65d64c972e9244fa715c9060"
        response = requests.get(f"{base_url}/{sample_id}", verify=False)
        response.raise_for_status()
        riddle_by_id = response.json()
        print(f"Riddle with ID: {sample_id}\nNumber:{riddle_by_id['number']}\nRiddle: {riddle_by_id['riddle']}\n"
              f"Answer: {riddle_by_id['answer']}\n")

        # Test GetByNumberAsync(number) method with a sample number, verify False for https/vpn
        sample_number = 15
        response = requests.get(f"{base_url}/{sample_number}", verify=False)
        response.raise_for_status()
        riddle_by_number = response.json()
        print(f"Riddle with Number {sample_number}\nID:{riddle_by_number['id']}\nRiddle: {riddle_by_number['riddle']}"
              f"\nAnswer: {riddle_by_number['answer']}\n")


    except requests.HTTPError as e:
        print(f"HTTP Error: {e}")
    except Exception as e:
        print(f"An error occurred: {e}")

test_get_methods()
