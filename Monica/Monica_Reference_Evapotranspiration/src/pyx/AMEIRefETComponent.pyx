from datetime import datetime
from math import *
from Monica_Reference_Evapotranspiration.referenceevapotranspiration import model_referenceevapotranspiration
def model_ameirefet(float height_nn,
      float mean_air_temperature,
      float wind_speed,
      float wind_speed_height,
      float stomata_resistance,
      float net_radiation,
      float saturation_vapor_pressure_deficit):
    cdef float reference_evapotranspiration
    reference_evapotranspiration = model_referenceevapotranspiration(height_nn,mean_air_temperature,wind_speed,wind_speed_height,net_radiation,stomata_resistance,saturation_vapor_pressure_deficit)

    return (reference_evapotranspiration)