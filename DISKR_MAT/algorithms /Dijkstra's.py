Inf = float('inf')

matrix = [[0, 10, 30, 50, 10],
          [Inf, 0, Inf, Inf, Inf],
          [Inf, Inf, 0, Inf, 10],
          [Inf, 40, 20, 0, Inf],
          [10, Inf, 10, 30, 0]]

ls = [0, Inf, Inf, Inf, Inf]  # метки вершин от которых смотрим пути

used_vertex = []  # вершины которые мы рассмотрели

for i in range(len(matrix)):
    for j in range(len(matrix[i])):
        if (ls[i] + matrix[i][j] < ls[j]) and (i not in used_vertex):
            ls[j] = ls[i] + matrix[i][j]
    used_vertex.append(i)

print(ls)
