# def potential_evapotranspiration(float tmax, float tmin, float srad, float etlai, float ket=0.5, float calb=0.23, float salb=0.13):
cdef float td
cdef float fraction_nrj_soil
cdef float albedo
cdef float eeq
# cdef float pet

td = 0.6 * tmax + 0.4 * tmin
fraction_nrj_soil = exp(-(ket * etlai))
albedo = calb * (1.0 - fraction_nrj_soil) + salb * fraction_nrj_soil
eeq = srad * (0.004876 - 0.004374 * albedo) * (td + 29.0)
if tmax > 5.0 and tmax < 34.0:
    pet = eeq * 1.1
else:
    if tmax >= 34.0:
        pet = eeq * ((tmax - 34.0) * 0.05 + 1.1)
    else:
        pet = eeq * 0.01 * exp(0.18 * (tmax + 20.0))

# return pet
# Changes: removed math import, used exp directly; replaced chained comparison with explicit and for compatibility.
# Manual changes (CP) : Comment
# - def function
# - pet from variable definition
# - return pet 