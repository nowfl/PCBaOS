def b(a,x):
    l,r=0,len(a)-1
    while l<=r:
        m=(l+r)//2
        if a[m]==x:return m
        l,r=m+1,r if a[m]<x else l,m-1
    return -1

a = [1, 2, 3, 4, 5]
x = 3

print(b(a, x))