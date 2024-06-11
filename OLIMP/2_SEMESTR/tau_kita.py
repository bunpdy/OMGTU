


def Tau(mode, input_path=None, output_path=None):
    if mode == 'file':
        f = open(input_path, "r")
        phrase = f.read()
        f.close()
    if mode == "manual":
        phrase = input()

    words = phrase.split(" ")
    new_words = []
    i = 0
    if len(new_words) == 0:
        if len(words) % 2 != 0:
            new_words.append(words[-1 - i])
        else:
            new_words.append(words[i])
    while len(new_words) != len(words):
        if len(words) % 2 != 0:
            new_words.append(words[i])
            if len(new_words) != len(words):
                i += 1
                new_words.append(words[-i-1])
        else:
            i += 1
            new_words.append(words[-1 - i+1])
            if len(new_words) != len(words):
                new_words.append(words[i])
    new_words.reverse()
    new_new_words = []
    for word in new_words:
        i = 0
        new_word = ""
        if len(new_word) == 0:
            if len(word) % 2 != 0:
                new_word = new_word + (word[-1 - i])
            else:
                new_word = new_word + (word[i])
        while len(new_word) != len(word):
            if len(word) % 2 != 0:
                new_word = new_word + (word[i])
                if len(new_word) != len(word):
                    i += 1
                    new_word = new_word + (word[-i - 1])
            else:
                i += 1
                new_word = new_word + (word[-i])
                if len(new_word) != len(word):
                    new_word = new_word + (word[i])
        new_word = new_word[::-1]
        new_new_words.append(new_word)

    out_str = ""
    for word in new_new_words:
        out_str = out_str +" "+ word
    out_str = out_str[1:]

    if mode == 'auto':
        f = open(output_path, "w")
        f.write(out_str)
        f.close()
    return out_str





autocheck = True

if autocheck:
    for w in range(1, 14):
        q = str(w)
        if len(q) == 1:
            q = "0" +q
        print(q)
        out = Tau(mode="file", input_path="C:/Users/User/Downloads/Тау-Кита/input_s1_"+q+".txt", output_path="output.txt")
        f = open("C:/Users/User/Downloads/Тау-Кита/output_s1_" + q +".txt")
        u = f.read()
        if out != u:
            print("ERROR")
            print(u)
            print("-----------")
            print(out)

else:
    print(Tau(mode="file", input_path="C:/Users/User/Downloads/Тау-Кита/input_s1_01.txt", output_path="output.txt"))
    # print(Goroda(mode='manual'))
