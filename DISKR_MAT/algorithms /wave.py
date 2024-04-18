inf = float('inf')

ls = [[-1, -1, -1, -1, -1, -1, -1, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, -1, -1, -1, -1, -1, -1, -1]]

x_s, y_s = 1, 1
x_end, y_end = 6, 6

ls[x_s].pop(y_s)
ls[x_s].insert(y_s, 0)


def func(center_x, center_y):
    if ls[center_x][center_y] != - 1:
        if ls[center_x - 1][center_y - 1] != -1:
            ls[center_x - 1][center_y - 1] = min(ls[center_x - 1][center_y - 1], ls[i][j] + 1)

        if ls[center_x - 1][center_y] != -1:
            ls[center_x - 1][center_y] = min(ls[center_x - 1][center_y], ls[i][j] + 1)

        if ls[center_x - 1][center_y + 1] != -1:
            ls[center_x - 1][center_y + 1] = min(ls[center_x - 1][center_y + 1], ls[i][j] + 1)

        if ls[center_x][center_y - 1] != -1:
            ls[center_x][center_y - 1] = min(ls[center_x][center_y - 1], ls[i][j] + 1)

        if ls[center_x][center_y + 1] != -1:
            ls[center_x][center_y + 1] = min(ls[center_x][center_y + 1], ls[i][j] + 1)

        if ls[center_x + 1][center_y - 1] != -1:
            ls[center_x + 1][center_y - 1] = min(ls[center_x + 1][center_y - 1], ls[i][j] + 1)

        if ls[center_x + 1][center_y] != -1:
            ls[center_x + 1][center_y] = min(ls[center_x + 1][center_y], ls[i][j] + 1)

        if ls[center_x + 1][center_y + 1] != -1:
            ls[center_x + 1][center_y + 1] = min(ls[center_x + 1][center_y + 1], ls[i][j] + 1)


while ls[x_end][y_end] == inf:
    for i in range(1, len(ls) - 1):
        for j in range(1, len(ls[i]) - 1):
            func(i, j)

for c in range(len(ls)):
    print(ls[c])


def search_way(center_x, center_y):
    if ls[center_x - 1][center_y - 1] != -1 and ((ls[center_x][center_y] - ls[center_x - 1][center_y - 1]) == 1):
        return [center_x - 1, center_y - 1]

    if ls[center_x - 1][center_y] != -1 and ((ls[center_x][center_y] - ls[center_x - 1][center_y]) == 1):
        return [center_x - 1, center_y]

    if ls[center_x - 1][center_y + 1] != -1 and ((ls[center_x][center_y] - ls[center_x - 1][center_y + 1]) == 1):
        return [center_x - 1, center_y + 1]

    if ls[center_x][center_y - 1] != -1 and ((ls[center_x][center_y] - ls[center_x][center_y - 1]) == 1):
        return [center_x, center_y - 1]

    if ls[center_x][center_y + 1] != -1 and ((ls[center_x][center_y] - ls[center_x][center_y + 1]) == 1):
        return [center_x, center_y + 1]

    if ls[center_x + 1][center_y - 1] != -1 and ((ls[center_x][center_y] - ls[center_x + 1][center_y - 1]) == 1):
        return [center_x + 1, center_y - 1]

    if ls[center_x + 1][center_y] != -1 and ((ls[center_x][center_y] - ls[center_x + 1][center_y]) == 1):
        return [center_x + 1, center_y]

    if ls[center_x + 1][center_y + 1] != -1 and ((ls[center_x][center_y] - ls[center_x + 1][center_y + 1]) == 1):
        return [center_x + 1, center_y + 1]


coordinates = [[x_end, y_end],]
stop = -1
while [x_s, y_s] != coordinates[-1] and (stop <= len(ls) * len(ls[0])):
    stop += 1
    for x in range(len(ls)):
        for y in range(len(ls[x])):
            if [x, y] == coordinates[-1]:
                coordinates.append(search_way(x, y))

print(coordinates[::-1])
