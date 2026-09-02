cdef float h 
cdef float clim 
clim=0.10
if ih != -999:
    clim=36.00
h=max(10.00, plantHeight) / 100.00
conductance=wind * pow(vonKarman, 2) / (log((heightWeatherMeasurements - (d * h)) / (zm * h)) * log((heightWeatherMeasurements - (d * h)) / (zh * h)))
conductance=max(clim, conductance)