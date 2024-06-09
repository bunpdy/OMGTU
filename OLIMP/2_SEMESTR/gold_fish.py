words = []
dct_st = {}
dct_en = {}

n = int(input())
for i in range(n):
    words.append(input())

summa_st = 0
s = int(input())
for i in range(s):
    k, v = input().split()
    dct_st[k] = int(v)
    summa_st += int(v)

e = int(input())
for i in range(e):
    k, v = input().split()
    dct_en[k] = int(v)

set_st = set()
for w in words:
    for l in dct_st.keys():
        if w.startswith(l):
            set_st.add(w)

c = 0
rem = summa_st
for l in dct_en.keys():
    set_en = {w for w in words if w.endswith(l)}
    inter = set_st & set_en
    if len(inter) >= dct_en[l]:
        if rem >= dct_en[l]:
            c += dct_en[l]
            rem -= dct_en[l]
        else:
            c += rem
    else:
        if rem >= len(inter):
            c += len(inter)
            rem -= len(inter)
        else:
            c += rem
    print(inter)

if c > summa_st:
    print(summa_st)
else:
    print(c)
