from datetime import datetime
from math import *
from SimplaceReferenceETPM.referenceetpm import model_referenceetpm
def model_referenceetpm_(float iNetRadiation,
      float cAltitude,
      float iActualVapourPressure,
      float iTMax,
      float iTMin,
      float iWindspeed):
    cdef float ReferenceCropEvapotranspiration
    ReferenceCropEvapotranspiration = model_referenceetpm(cAltitude,iTMax,iTMin,iActualVapourPressure,iNetRadiation,iWindspeed)

    return (ReferenceCropEvapotranspiration)