from functools import reduce

n = int(input("Введите количество домов в деревне: "))

ls = []
for i in range(n):
    x_y = input("Корды:")
    ls.append([int(x_y.split(" ")[0]), int(x_y.split(" ")[1])])
else:
    print(ls)


lengths = []
edges = []

for i in range(len(ls)):
    for j in range(i, len(ls)):
        if i != j:
            length = ((ls[i][0] - ls[j][0]) ** 2 + (ls[i][1] - ls[j][1]) ** 2) ** 0.5
            edges.append([i, j])
            lengths.append(length)


for j in range(len(lengths) - 1):
    for i in range(len(lengths) - 1):
        if lengths[i] > lengths[i + 1]:
            per = lengths[i]
            lengths[i] = lengths[i + 1]
            lengths[i + 1] = per
            per = edges[i]
            edges[i] = edges[i + 1]
            edges[i + 1] = per

print(edges)
print(lengths)
mass = 0
set_list = []
set1 = set()
set_list.append(set1)
for i in range(len(edges)):
    for j in set_list:
        if (edges[i][0] in j) and (edges[i][1] in j):
            break
    else:
        big_set = reduce(set.union, set_list)
        if (edges[i][0] in big_set) and (edges[i][1] in big_set):
            res = set()
            count1 = 0
            count2 = 0
            for t1 in range(len(set_list)):
                if len(res) != 0:
                    break
                if edges[i][0] in set_list[t1]:
                    count1 = t1
                    for t2 in range(len(set_list)):
                        if edges[i][1] in set_list[t2]:
                            count2 = t2
                            set1 = set_list[t1]
                            set2 = set_list[t2]
                            mass += lengths[i]
                            res = reduce(set.union, [set1, set2])
                            break
            set_list.remove(set_list[count2])
            set_list.remove(set_list[count1])
            set_list.append(res)
        elif (edges[i][0] not in big_set) and (edges[i][1] not in big_set):
            new_set = set()
            new_set.add(edges[i][0])
            new_set.add(edges[i][1])
            mass += lengths[i]
            set_list.append(new_set)
        else:
            for c in set_list:
                if (edges[i][0] in c) or (edges[i][1] in c):
                    c.add(edges[i][0])
                    c.add(edges[i][1])
                    mass += lengths[i]
                    break
else:
    print(mass) # вес минимального остовного дерева
