Inf = float('inf')

matrix = [[0, -1, 4, Inf, Inf],
          [Inf, 0, 3, 2, 2],
          [Inf, Inf, 0, Inf, Inf],
          [Inf, 1, 5, 0, Inf],
          [Inf, Inf, Inf, -3, 0]]

ls = [Inf, Inf, Inf, Inf, 0]


def ford_bellman(ls1):  # повторяем два раза так как нужно убедиться что граф не имеет отрицательных циклов
    for t in range(len(matrix) - 1):
        for i in range(len(matrix)):
            for j in range(len(matrix[i])):
                if matrix[i][j] + ls1[i] < ls1[j]:
                    # вес ребра = метка от начальной вершины < метка до нынешней вершины
                    ls1[j] = matrix[i][j] + ls1[i]

    return ls1   # они не должны отличаться если в графе нет отрицательных циклов

# Вывод -> в графе нет отрицательных циклов


used_vertex = [1]

clear_vertex = ford_bellman(ls)
print(clear_vertex)
# for z in range(len(clear_vertex) - 3):
for z in range(len(matrix)):
    for x in range(len(matrix)):
        for y in range(len(matrix)):
            for k in range(len(clear_vertex)):
                if (y == used_vertex[-1]) and (x == k) and (used_vertex[-1] != x):
                    if clear_vertex[k] + matrix[x][y] == clear_vertex[used_vertex[-1]]:
                        used_vertex.append(x)


print(used_vertex[::-1])

# print(used_vertex)

