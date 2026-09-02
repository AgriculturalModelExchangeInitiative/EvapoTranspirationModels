cdef float AlphaE 
if ih == -999:
    if tau < tauAlpha:
        AlphaE=1.00
    else:
        AlphaE=Alpha - ((Alpha - 1.00) * (1.00 - tau) / (1.00 - tauAlpha))
    energyLimitedEvaporation=evapoTranspirationPriestlyTaylor / Alpha * AlphaE * tau
else:
    energyLimitedEvaporation=0.00