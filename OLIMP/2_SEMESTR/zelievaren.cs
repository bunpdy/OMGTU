f = open("temp", "r")
lines = [s.strip() for s in f.readlines()]


strr = ""
hmm = []
for line in lines:
    values = line.split(" ")
    for value in values:
        try:
            a = int(value)
            line = line.replace(" "+value, " _"+value+"_ ", 1)
        except:
            pass
    if "MIX" in line:
        s = line.replace("MIX", "").replace(" ", "")
        s = "MX"+s+"XM"
        hmm.append(s)
    if "WATER" in line:
        s = line.replace("WATER", "").replace(" ", "")
        s = "WT" + s + "TW"
        hmm.append(s)
    if "DUST" in line:
        s = line.replace("DUST", "").replace(" ", "")
        s = "DT" + s + "TD"
        hmm.append(s)
    if "FIRE" in line:
        s = line.replace("FIRE", "").replace(" ", "")
        s = "FR" + s + "RF"
        hmm.append(s)


for i in range(len(hmm), 1, -1):
    while "_" in hmm[i - 1]:
        num = int(hmm[i - 1].split("_")[1])
        hmm[i - 1] = hmm[i - 1].replace("_" + str(num) + "_", hmm[num - 1])

print(hmm[-1])
