inf = float('inf')

ls = [[-1, -1, -1, -1, -1, -1, -1, -1],
      [-1, 0, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, inf, inf, inf, inf, inf, inf, -1],
      [-1, -1, -1, -1, -1, -1, -1, -1]]
    
def func(center_x, center_y):
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

    
for i in range(1, len(ls) - 1):
    for j in range(1, len(ls) - 1):
        func(i, j)
                
        

            #if (t % 2 == 0) and (ls[around[t], around[t+1]] != -1):
                #ls[i][j] = min(ls[i][j], ls[around[t], around[t+1]] + ls[i][j])

for c in range(len(ls)):
    print(ls[c])
    
