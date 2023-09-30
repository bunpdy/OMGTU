def size_of_beds(p, l, k, n):
    z = 1
    size = 0
    while z < n + 1:
        size += (p * 2) + (k * (z + 1)) + (l * 2 * z)
        z += 1
    else:
        return size


def formula(p, l, k, n):
    return (p * 2 * n) + (k * sum(list(range(n + 1))[1:])) + ((l + l) * sum(list(range(n + 2))[1:])) - k


print(size_of_beds(7, 5, 10, 1))
print(size_of_beds(7, 5, 10, 2))
print(size_of_beds(7, 5, 10, 5))
print(size_of_beds(7, 5, 10, 20))

print(formula(7, 5, 10, 1))
print(formula(7, 5, 10, 2))
print(formula(7, 5, 10, 5))
print(formula(7, 5, 10, 20))


