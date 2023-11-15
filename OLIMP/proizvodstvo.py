def func(data_start, data_end, p):
    ls = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]
    per_st = data_start.split(".")
    per_ed = data_end.split(".")
    vis_days = (int(per_ed[-1]) - int(per_st[-1])) // 4
    days_st = (sum(ls[0:int(per_ed[1])-1]) - sum(ls[0:int(per_st[1])-1])) + ((int(per_ed[0]) - int(per_st[0])) + 1)
    years = int(per_ed[-1]) - int(per_st[-1])
    years_in_days = years * 365 + vis_days
    return ((p + (p + (days_st + years_in_days) - 1)) / 2) * (days_st + years_in_days)


print(func(input(), input(), int(input())))
