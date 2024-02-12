f = open(r"company1\input_s1_01.txt", "r")
a = f.readlines()

numbers = "0123456789"

last = ""
ls = []
copies = []

count = start = 0

for i in a:
    count += 1
    last = i
    if not (len(i.replace("\n", "")) == 4):
        ls.append(i.replace("\n", ""))
    else:
        copies.append(i.replace("\n", ""))

dict1 = {}

for i in a:
    if start < count - 2:
        if copies.count(i[:4]) == 1:
            dict1.update({i[:4]: "Unknown Name"})
    start += 1

for i in (ls[:-2]):
    key = i[:4]
    dict1[key] = i[5:]
else:
    if last[0] not in numbers:
        for i, j in dict1.items():
            if j == last:
                last = i

sorted_dict = dict(sorted(dict1.items()))

for i, j in sorted_dict.items():
    if i > last:
        print(i, sorted_dict.get(i))
