inf = float('inf')
matrix = [[0,   1,    1,   1,   inf, ],
          [1,   0,    1,   inf, inf, ],
          [1,   1,    0,   inf, 1, ],
          [1,   inf,  inf, 0,   inf, ],
          [inf, inf,  1,   inf, 0, ], ]

used_vertexes = []


def dfs(i):
    for j in range(len(matrix[i])):
        if (i not in used_vertexes) and (matrix[i][j] == 1):
            used_vertexes.append(i)
            dfs(j)


for i in range(len(matrix)):
    dfs(i)

print(used_vertexes)
