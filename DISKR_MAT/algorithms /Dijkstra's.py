Inf = float('inf')

matrix = [[0, 10, 30, 50, 10],
          [Inf, 0, Inf, Inf, Inf],
          [Inf, Inf, 0, Inf, 10],
          [Inf, 40, 20, 0, Inf],
          [10, Inf, 10, 30, 0]]


ls = [Inf, Inf, Inf, Inf, Inf]  # метки вершин от которых смотрим пути

from_point = int(input("Введите номер начальной вершины: "))

to_point = int(input("Введите номер конечной вершины: "))

ls.pop(from_point)
ls.insert(from_point, 0)

for i in range(len(matrix)):
    for j in range(len(matrix[i])):
        if ls[i] + matrix[i][j] < ls[j]:
            ls[j] = ls[i] + matrix[i][j]


p = to_point
vertex = [p]
while p != from_point:
    flag = False
    for i in range(len(matrix)):
        if flag:
            break
        for j in range(len(matrix[i])):
            if (j == p) and (i not in vertex):
                if ls[i] + matrix[i][j] == ls[p]:
                    vertex.append(i)
                    p = i
                    if p == from_point:
                        flag = True

print(vertex[::-1], "Путь включает в себя вершину старта и конца")
