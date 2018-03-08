import requests
from bs4 import BeautifulSoup

def getBenqPrice():
    urls = readProductUrls()
    del(urls[-1])
    products = ''
    for url in urls:
        
        page = requests.get(url)
        page.raise_for_status()
        
        soup = BeautifulSoup(page.text, 'html.parser')
        price_box = soup.find('div', attrs={'class': 'product-price'})
        name_box = soup.find('h1', attrs={'class': 'product-main-info-webtext1'})

        products += name_box.text.strip() + ':' + price_box.text.strip() + '#'

    return products

def readProductUrls():
    urlFile = open(r'C:\Users\jimmi\source\repos\KomplettProductFollower\KomplettProductFollower\ProductFollow.txt','r')
    urls = urlFile.read().split('#')
    
    return urls

productList = getBenqPrice()
print(productList)

#name = input()
