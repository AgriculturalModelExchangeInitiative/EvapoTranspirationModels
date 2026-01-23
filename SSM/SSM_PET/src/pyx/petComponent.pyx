from datetime import datetime
from math import *
from SSM_PET.potentialevapotranspiration import model_potentialevapotranspiration
def model_pet(float tmax,
      float tmin,
      float srad,
      float etlai,
      float ket,
      float calb,
      float salb):
    cdef float pet
    pet = model_potentialevapotranspiration(tmax,tmin,srad,etlai,ket,calb,salb)

    return (pet)