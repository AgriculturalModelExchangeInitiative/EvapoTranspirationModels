from datetime import datetime
from math import *
from SSM_PET.potentialevapotranspiration import model_potentialevapotranspiration
def model_pet(float tmax,
      float tmin,
      float srad,
      float albedo):
    cdef float pet
    pet = model_potentialevapotranspiration(tmax,tmin,srad,albedo)

    return (pet)