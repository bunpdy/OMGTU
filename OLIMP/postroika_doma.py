def func(X, Y, L, C1, C2, C3, C4, C5, C6):
    PER = 2 * (X + Y)
    if L <= max(X, Y):
        price = (L * C1) + (((PER - L) * C4) + ((PER - L) * C5))

    elif max(X, Y) < L <= PER:
        price = (max(X, Y) * C1) + ((L - max(X, Y)) * C2) + ((L - max(X, Y)) * C3) + (((PER - L) * C4) + ((PER - L) * C5))

    else:
        price = (max(X, Y) * C1) + (((PER - L) * C2) + ((PER - L) * C3)) + ((L - PER) * C6)

    return price


a = str(input())
ls = a.split(' ')

print(func(int(ls[0]), int(ls[1]), int(ls[2]), int(ls[3]), int(ls[4]), int(ls[5]), int(ls[6]), int(ls[7]), int(ls[8])))
