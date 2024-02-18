f = open("C:/Users/bunpdy/PycharmProjects/pythonProject/unic/company1/input_s1_01.txt", "r")

a = f.readlines()
ls = []
last = ""
for i in a:
    if i.strip()[:3] != "END":
        ls.append((i.strip()[:4] + "!" + i.strip()[5:]).split('!'))
    last = i.strip()

ls_noname = []
ls_name = []
for i in ls[:-1]:
    if not i[-1]:
        ls_noname.append(i)
    else:
        ls_name.append(i)

ls.clear()
ls = ls_name + ls_noname
ls_clear = []
ls_per = ls
had = []

for x in ls_per:
    if x[0] not in had:
        had.append(x[0])
        if not x[1]:
            x[1] = "Unknown Name"
        ls_clear.append(x)

dict1 = {}
for i in ls_clear:
    key = i[0]
    dict1[key] = i[1]

number_of_boss = ""
answer = []
for i, j in dict1.items():
    if (i == last) or (j == last):
        number_of_boss += i

count = 0
for i, j in dict1.items():
    if number_of_boss:
        if int(i) > int(number_of_boss):
            count = 1
            answer.append([i, j])
    else:
        print("NO")
        break
else:
    if not count:
        print("NO")

for i in sorted(answer):
    print(i[0], i[1])
