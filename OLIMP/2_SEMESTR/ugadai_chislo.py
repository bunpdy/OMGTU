
import math


def Prog(mode, input_path=None, output_path=None):
    actions = []
    if mode == 'file':
        f = open(input_path, "r")
        N = int(f.readline().strip())
        for i in range(0, N):
            actions.append(f.readline().strip().split(" "))
        R = int(f.readline().strip())
        f.close()
    if mode == "manual":
        N = int(input().strip())
        actions = []
        for i in range(0, N):
            actions.append(input().strip().split(" "))
        R = int(input().strip())

    actions.reverse()
    real_part = R
    x_part = 0
    for i in range(0, N):
        if actions[i][0] == "+":
            if actions[i][1] == "x":
                x_part += 1
            else:
                real_part -= int(actions[i][1])
        if actions[i][0] == "-":
            if actions[i][1] == "x":
                x_part -= 1
            else:
                real_part += int(actions[i][1])
        if actions[i][0] == "*":
            real_part = real_part / int(actions[i][1])
            x_part = x_part / int(actions[i][1])
    x_part += 1
    if real_part/x_part < 0:
        out_str = str(-math.ceil((abs(real_part / x_part))))
    else:
        out_str = str(math.ceil((real_part/x_part)))

    if mode == 'auto':
        f = open(output_path, "w")
        f.write(out_str)
        f.close()
    return out_str





autocheck = True

if autocheck:
    for w in range(1, 12):
        q = str(w)
        if len(q) == 1:
            q = "0" +q
        print(q)
        out = Prog(mode="file", input_path="C:/Users/User/Downloads/Отгадай число/input_s1_"+q+".txt", output_path="output.txt")
        f = open("C:/Users/User/Downloads/Отгадай число/output_s1_" + q +".txt")
        u = f.read()
        if out != u:
            print(out, u)
            print("ERROR")
            #print(u)
            #print("-----------")
            print(out)

else:
    print(Prog(mode="file", input_path="C:/Users/User/Downloads/Отгадай число/input_s1_01.txt", output_path="output.txt"))
    # print(Goroda(mode='manual'))
