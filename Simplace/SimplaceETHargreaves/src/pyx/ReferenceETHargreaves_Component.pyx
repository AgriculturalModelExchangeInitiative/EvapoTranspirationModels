from datetime import datetime
from math import *
from SimplaceETHargreaves.referenceethargreaves import model_referenceethargreaves
def model_referenceethargreaves_(float iTMax,
      float iSolarRadiation,
      float iTMin,
      bool cConvertLeByTemp):
    cdef float ReferenceCropEvapotranspiration
    ReferenceCropEvapotranspiration = model_referenceethargreaves(cConvertLeByTemp,iTMax,iTMin,iSolarRadiation)

    return (ReferenceCropEvapotranspiration)