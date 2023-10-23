def func(N):
    stepen = 2
    count = 0
    while 2 ** stepen <= N + 1:
        if N % ((2 ** stepen) - 1) == 0:
            count += 1
        stepen += 1
    else:
        return count


n = int(input())
summ = 0
for i in range(1, n + 1):
    summ += (func(i))
else:
    print(summ + n)
