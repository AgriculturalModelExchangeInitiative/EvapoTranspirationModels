cdef float vptmin
cdef float vptmax
cdef float VPD
#cdef float TR

vptmin = 0.6108 * exp((17.27 * tmin) / (tmin + 237.3))
vptmax = 0.6108 * exp((17.27 * tmax) / (tmax + 237.3))
VPD = VPDF * (vptmax - vptmin)

TR = ddmp * VPD / TEC