def func(x, y, z, p1, p2, p3, m1, m2, m3):
    if (((p1 == 0 and m1 == 0) or (p2 == 0 and m2 == 0) or (p3 == 0 and m3 == 0)) or
            ((p1 == x and m1 == x) or (p2 == y and m2 == y) or (p3 == z and m3 == z))):
        return ((p3 - m3) ** 2 + (p2 - m2) ** 2 + (p1 - m1) ** 2) ** 0.5

    elif (abs(p3 - m3) == z) or (abs(p2 - m2) == y) or (abs(p1 - m1) == x):
        if abs(p2 - m2) == y:
            right = (abs(p3 - m3) ** 2 + (y + abs(x - m1) + abs(x - p1)) ** 2) ** 0.5
            left = (abs(p3 - m3) ** 2 + (y + abs(m1) + abs(p1)) ** 2) ** 0.5
            up = (abs(p1 - m1) ** 2 + (y + abs(z - m3) + abs(z - p3)) ** 2) ** 0.5
            down = (abs(p1 - m1) ** 2 + (y + abs(z) + abs(z)) ** 2) ** 0.5
            return min(right, left, up, down)

        elif abs(p1 - m1) == x:
            right = (abs(p3 - m3) ** 2 + (x + abs(y - m2) + abs(y - p2)) ** 2) ** 0.5
            left = (abs(p3 - m3) ** 2 + (x + abs(m2) + abs(p2)) ** 2) ** 0.5
            up = (abs(p2 - m2) ** 2 + (x + abs(z - m3) + abs(z - p3)) ** 2) ** 0.5
            down = (abs(p2 - m2) ** 2 + (x + abs(m3) + abs(p3)) ** 2) ** 0.5
            return min(right, left, up, down)

        else:
            right = (abs(p2 - m2) ** 2 + (z + abs(x - m1) + abs(x - p1)) ** 2) ** 0.5
            left = (abs(p2 - m2) ** 2 + (z + abs(m1) + abs(p1)) ** 2) ** 0.5
            up = (abs(p1 - m1) ** 2 + (z + abs(y - m2) + abs(y - p2)) ** 2) ** 0.5
            down = (abs(p1 - m1) ** 2 + (z + abs(m2) + abs(p2)) ** 2) ** 0.5
            return min(right, left, up, down)
    else:
        ls = [p1, p2, p3]
        ls2 = [m1, m2, m3]
        for i in range(3):
            if (ls[i] == 0) or ((ls[i] == x and i == 0) or (ls[i] == y and i == 1) or (ls[i] == z and i == 2)):
                part_katet = abs(ls2[i] - ls[i])
                ls.pop(i)
                ls2.pop(i)
                if (p3 != 0 and m3 != 0) and (p3 != z and m3 != z):
                    return ((abs(ls2[0] - ls[0]) + part_katet) ** 2 + (abs(ls2[1] - ls[1])) ** 2) ** 0.5
                elif (p1 != 0 and m1 != 0) and (p1 != x and m1 != x):
                    return ((abs(ls2[0] - ls[0])) ** 2 + (abs(ls2[1] - ls[1]) + part_katet) ** 2) ** 0.5
                else:
                    if i == 0:
                        return ((abs(ls2[0] - ls[0])) ** 2 + (abs(ls2[1] - ls[1]) + part_katet) ** 2) ** 0.5
                    else:
                        return ((abs(ls2[0] - ls[0]) + part_katet) ** 2 + (abs(ls2[1] - ls[1])) ** 2) ** 0.5


text = ""

while True:
    x = input()
    if x:
        text += x + " "
    else:
        break

a = [int(i) for i in (text.split(' '))[:-1]]

print(func(a[0], a[1], a[2],
           a[3], a[4], a[5],
           a[6], a[7], a[8]))
