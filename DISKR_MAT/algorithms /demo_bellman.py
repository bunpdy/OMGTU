Inf = float('inf')

matrix = [[0, -1, 4, Inf, Inf],
          [Inf, 0, 3, 2, 2],
          [Inf, Inf, 0, Inf, Inf],
          [Inf, 1, 5, 0, Inf],
          [Inf, Inf, Inf, -3, 0]]

ls = [0, Inf, Inf, Inf, Inf]

for t in range(len(matrix) - 1):
    for i in range(len(matrix)):
        for j in range(len(matrix[i])):
            if ls[j] > matrix[i][j] + ls[i]:
                ls[j] = matrix[i][j] + ls[i]


used_vertex = [3]

print(ls)
for t in range(2):
    for x in range(len(ls)):
        for i in range(len(matrix)):
            for j in range(len(matrix[i])):
                if j == used_vertex[-1] and x == i and (x != used_vertex[-1]):
                    if ls[x] + matrix[i][j] == ls[used_vertex[-1]]:
                        used_vertex.append(i)


print(used_vertex)
