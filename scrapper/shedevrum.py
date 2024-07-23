import requests

url = 'https://api.artbreeder.com/v1/art'
params = {'seed': '6c35e479-3642-4f6a-a61f-273e24d81583', 'size': 256}
response = requests.get(url, params=params)
data = response.json()

print(data['image_url'])