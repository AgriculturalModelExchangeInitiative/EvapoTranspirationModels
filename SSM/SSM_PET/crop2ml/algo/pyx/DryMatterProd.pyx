cdef float tmp
cdef float coeff_RUE
cdef float actual_RUE
cdef float fint
# cdef float ddmp

tmp = tmax + 0.4 * tmin

if tmp <= TBRUE or tmp >= TCRUE:
    coeff_RUE = 0.0
elif TBRUE < tmp and tmp < TP1RUE:
    coeff_RUE = (tmp - TBRUE) / (TP1RUE - TBRUE)
elif TP2RUE <= tmp and tmp <= TCRUE:
    coeff_RUE = (TCRUE - tmp) / (TCRUE - TP2RUE)
else:
    coeff_RUE = 1.0

actual_RUE = RUE * coeff_RUE
fint = 1.0 - exp(-kpar * lai)
ddmp = srad * 0.48 * fint * actual_RUE