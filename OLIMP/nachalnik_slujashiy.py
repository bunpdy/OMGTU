class File:
    def __init__(self, catalog):
        self.dict1 = {}
        self.a = None
        self.last = None
        self.ls = []
        self.dict_clear = {}
        self.catalog = catalog

    def openfile(self):
        with open(self.catalog, "r") as f:
            self.a = f.readlines()
            self.last = self.a[-1]

    def return_last_element(self):
        self.openfile()
        return self.last

    def create_dict(self):
        self.openfile()
        for i in self.a[:-2]:
            key = i[:4]
            if i[5:]:
                self.dict1[key] = i[5:].replace("\n", "")
            else:
                self.dict1[key] = "Unknown Name"
        return self.dict1

    def return_list(self):
        ls1 = []
        self.openfile()
        for i in self.a[:-2]:
            ls1.append(i[:4])
        else:
            return ls1

    def return_clear_dict(self, torch):
        self.openfile()
        ls_names = {}
        for i in self.a[:-2]:
            per_ls = ((i[:4] + "!" + i[5:]).split("!"))
            key = per_ls[0]
            self.dict_clear[key] = per_ls[1].replace("\n", "")
            if per_ls[-1]:
                key = per_ls[0]
                ls_names[key] = per_ls[1].replace("\n", "")
        else:
            if torch == 0:
                return self.dict_clear
            else:
                return ls_names


def sort_by_priority(file):
    start = file.return_list()
    property_people = []
    for i, j in file.create_dict().items():
        if (i == file.return_last_element()) or (j == file.return_last_element()):
            property_people.append(i)
            break

    indices = []

    # основной алгоритм
    while True:
        count = 0
        for i in range(len(start)):
            if (i % 2 == 0) and (start[i] in property_people) and (start[i + 1] not in indices):
                indices.append(start[i + 1])
                property_people.append(start[i + 1])
                count = 1
        if count == 0:
            break
    return indices


def connect_keys_with_values(ls, file):
    count1 = 0
    end_dict = {}
    dict_clear_0 = file.return_clear_dict(0)
    dict_clear_1 = file.return_clear_dict(1)
    for i, j in dict_clear_0.items():
        if i in ls:
            if (file.return_list().count(i) > 1) and (not j):
                for x, y in dict_clear_1.items():
                    if x == i:
                        end_dict.update({x: y})
                        break
                else:
                    end_dict.update({i: "Unknown Name"})
            else:
                end_dict.update({i: j})
    else:
        sorted_rooms = dict(sorted(end_dict.items()))
        for x, y in sorted_rooms.items():
            if not y:
                count1 = 1
                print(x, "Unknown Name")
            else:
                count1 = 1
                print(x, y)
        else:
            if count1 == 0:
                print("NO")


def main():
    file1 = File("C:/Users/bunpdy/PycharmProjects/pythonProject/unic/company1/input_s1_1.txt")
    per_ls = sort_by_priority(file1)
    connect_keys_with_values(per_ls, file1)


if __name__ == "__main__":
    main()
