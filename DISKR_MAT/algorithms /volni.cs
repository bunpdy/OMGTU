inf = float('inf')

ls = [[-1, -1, -1, -1, -1, -1, -1, -1],
      [-1, 0, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, -1, -1, -1, -1, -1, -1, -1]]
    

    
x_s, y_s = 0, 0
for l in range(1):
    for i in range(1, len(ls) - 1):
        for j in range(1, len(ls) - 1):
            around = [i - 1, j - 1, i - 1, j, i - 1, j + 1, i, j - 1, i, j + 1, i + 1, j - 1, i + 1, j, i + 1, j + 1]
            for t in range(len(around) - 1):
                if (t % 2 == 0) and (ls[around[t]][around[t + 1]] != -1):
                    x1 = around[t]
                    y1 = around[t + 1]
                    if ls[i][j] + 1 < ls[x1][y1]:
                        ls[x1][y1] = ls[i][j] + 1
        

            #if (t % 2 == 0) and (ls[around[t], around[t+1]] != -1):
                #ls[i][j] = min(ls[i][j], ls[around[t], around[t+1]] + ls[i][j])

for c in range(len(ls)):
    print(ls[c])
    
