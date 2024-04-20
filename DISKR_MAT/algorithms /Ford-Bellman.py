Inf = float('inf')

matrix = [[0,    -1,  4,   Inf,  Inf],
          [Inf,  0,   3,   2,    2],
          [Inf,  Inf, 0,   Inf,  Inf],
          [Inf,  1,   5,   0,    Inf],
          [Inf,  Inf, Inf, -3,   0],]

from_point = int(input("Введите номер начальной вершины: "))

to_point = int(input("Введите номер конечной вершины: "))

ls = [Inf, Inf, Inf, Inf, Inf]

ls.pop(from_point)
ls.insert(from_point, 0)

for t in range(len(matrix) - 1):
    for i in range(len(matrix)):
        for j in range(len(matrix)):
            if ls[j] > matrix[i][j] + ls[i]:
                ls[j] = matrix[i][j] + ls[i]
                
print(ls)
print(f"Минимальное расстояние м/у вершинами {from_point} и {to_point} = {ls[to_point]}")
print("----------------------")

print(ls)
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
                    flag = True
        
                
print(vertex[::-1], "Путь включает в себя вершину старта и конца")
