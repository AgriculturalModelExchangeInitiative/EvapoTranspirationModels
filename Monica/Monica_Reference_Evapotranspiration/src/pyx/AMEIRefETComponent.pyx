from datetime import datetime
from math import *
from Monica_Reference_Evapotranspiration.referenceevapotranspiration import model_referenceevapotranspiration
def model_ameirefet(float height_nn,
      float latent_heat_of_vaporization,
      float mean_air_temperature,
      float wind_speed,
      float wind_speed_height,
      float stomata_resistance,
      float net_radiation,
      float saturation_vapor_pressure_deficit,
      float saturated_vapor_pressure_slope,
      float psychrometric_constant):
    cdef float reference_evapotranspiration
    reference_evapotranspiration = model_referenceevapotranspiration(height_nn,latent_heat_of_vaporization,mean_air_temperature,wind_speed,wind_speed_height,net_radiation,stomata_resistance,saturation_vapor_pressure_deficit,saturated_vapor_pressure_slope,psychrometric_constant)

    return (reference_evapotranspiration)