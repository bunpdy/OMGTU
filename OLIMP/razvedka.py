def func(N):
    if N > 5:
        if N % 2 == 0:
            return func(N // 2) * 2
        else:
            return func((N + 1) // 2) + func(N // 2)
    if 3 <= N <= 5 and (N % 2 != 0):
        return 1
    else:
        return 0


print(func(10))
print(func(4))
print(func(1024))
print(func(1048576))
print(func(8388608))
print(func(10000000))
print(func(9999999))
print(func(9999998))
print(func(9199296))
print(func(1048476))

