from datetime import datetime
from math import *
from SimplaceReferenceETPriestleyTaylor.referenceetpriestleytaylor import model_referenceetpriestleytaylor
def model_referenceetpriestleytaylor_(float iTMin,
      float cAlphaPT,
      float iNetRadiation,
      float iTMax,
      float cAltitude):
    cdef float ReferenceCropEvapotranspiration
    ReferenceCropEvapotranspiration = model_referenceetpriestleytaylor(cAltitude,cAlphaPT,iTMax,iTMin,iNetRadiation)

    return (ReferenceCropEvapotranspiration)