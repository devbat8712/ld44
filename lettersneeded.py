import string

alphabet = list(string.ascii_lowercase)

words = "biking dancing donating eating family meditating reading sleeping walking"

for letter in alphabet:
    count = words.count(letter)
    if count > 0:
        print('"' + letter + '": ')