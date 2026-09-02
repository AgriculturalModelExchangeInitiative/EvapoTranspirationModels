from datetime import datetime
from math import *
from pet.potentialevapotranspiration import model_potentialevapotranspiration
from pet.potentialtranspiration import model_potentialtranspiration
from pet.drymatterprod import model_drymatterprod
def model_pet(float tmax,
      float tmin,
      float srad,
      float albedo,
      float ddmp,
      float TEC,
      float VPDF,
      float lai,
      float kpar,
      float RUE,
      float TBRUE,
      float TP1RUE,
      float TP2RUE,
      float TCRUE):
    cdef float pet
    cdef float TR
    cdef float ddmp
    ddmp = model_drymatterprod(tmax,tmin,srad,lai,kpar,RUE,TBRUE,TP1RUE,TP2RUE,TCRUE)
    TR = model_potentialtranspiration(tmax,tmin,ddmp,TEC,VPDF)

    return pet, TR, DDMP