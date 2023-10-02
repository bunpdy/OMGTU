def func(X, Y, L, C1, C2, C3, C4, C5, C6):
    PER = 2 * (X + Y)
    if L <= max(X, Y):
        price = (L * C1) + (((PER - L) * C4) + ((PER - L) * C5))
        price2 = (L * C2 + L * C6) + (PER * C4) + (PER * C5)
        price3 = (L * C2 + L * C3) + ((PER - L) * C4) + ((PER - L) * C5)
        price4 = 9999999

    elif max(X, Y) < L <= PER:
        price = (max(X, Y) * C1) + ((L - max(X, Y)) * C2) + ((L - max(X, Y)) * C3) + (((PER - L) * C4) + ((PER - L) * C5))
        price2 = (L * C2 + L * C6) + (PER * C4) + (PER * C5)
        price3 = (max(X, Y) * C1) + (((L - max(X, Y)) * C2) + ((L - max(X, Y)) * C6)) + (((PER - max(X, Y)) * C4) + ((PER - max(X, Y)) * C5))
        price4 = (L * C2 + L * C3) + ((PER - L) * C4) + ((PER - L) * C5)

    else:
        print('!3')
        price = (PER * C4 + PER * C5) + ((L * C2) + (L * C6))
        price2 = (max(X, Y) * C1) + (((PER - max(X, Y)) * C2) + ((PER - max(X, Y)) * C3)) + (((L - PER) * C2) + ((L - PER) * C6))
        price3 = (PER * C2 + PER * C3) + (((L - PER) * C2) + ((L - PER) * C6))
        price4 = 9999999

    return min(price, price2, price3, price4)


a = str(input())
ls = a.split(' ')

print(func(int(ls[0]), int(ls[1]), int(ls[2]), int(ls[3]), int(ls[4]), int(ls[5]), int(ls[6]), int(ls[7]), int(ls[8])))
