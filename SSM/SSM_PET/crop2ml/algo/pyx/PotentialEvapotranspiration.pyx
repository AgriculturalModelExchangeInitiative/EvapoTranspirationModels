cdef float td
cdef float eeq
# cdef float pet

td = 0.6 * tmax + 0.4 * tmin
eeq = srad * (0.004876 - 0.004374 * albedo) * (td + 29.0)

if (tmax > 5.0) and (tmax < 34.0):
    pet = eeq * 1.1
elif tmax >= 34.0:
    pet = eeq * ((tmax - 34.0) * 0.05 + 1.1)
else:
    pet = eeq * 0.01 * exp(0.18 * (tmax + 20.0))
