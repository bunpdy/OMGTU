def func(X1, Y1, Z1, X2, Y2, Z2, C1, C2) -> str:
    V1 = (X1 * Y1 * Z1) / 1000
    V2 = (X2 * Y2 * Z2) / 1000
    S1 = 2 * (X1*Y1 + X1*Z1 + Z1*Y1)
    S2 = 2 * (X2*Y2 + X2*Z2 + Z2*Y2)
    result = -1 * ((C2 * S1 - S2 * C1) / (V1 * S2 - V2 * S1))
    return f'{result:.2f}'


a = str(input())
lol = ""
for i in range(int(a)):
    x = input()
    lol += x + ' \n '

data = (lol.split(' ')[:-1])

results = []
line_range = data.count('\n')

for j in range(line_range):
    results.append(float(func(int(data[0]), int(data[1]), int(data[2]), int(data[3]), int(data[4]), int(data[5]), float(data[6]), float(data[7]))))
    data = data[9:]
else:
    print(results.index(min(results)) + 1, min(results))
