from . import AMEIRefETComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_mean_air_temperature = df[vardata.loc[vardata["Variables"]=="mean_air_temperature","Data columns"].iloc[0]].to_list()
    t_wind_speed = df[vardata.loc[vardata["Variables"]=="wind_speed","Data columns"].iloc[0]].to_list()
    t_wind_speed_height = df[vardata.loc[vardata["Variables"]=="wind_speed_height","Data columns"].iloc[0]].to_list()
    t_stomata_resistance = df[vardata.loc[vardata["Variables"]=="stomata_resistance","Data columns"].iloc[0]].to_list()
    t_net_radiation = df[vardata.loc[vardata["Variables"]=="net_radiation","Data columns"].iloc[0]].to_list()
    t_saturation_vapor_pressure_deficit = df[vardata.loc[vardata["Variables"]=="saturation_vapor_pressure_deficit","Data columns"].iloc[0]].to_list()
    t_saturated_vapor_pressure_slope = df[vardata.loc[vardata["Variables"]=="saturated_vapor_pressure_slope","Data columns"].iloc[0]].to_list()
    t_psychrometric_constant = df[vardata.loc[vardata["Variables"]=="psychrometric_constant","Data columns"].iloc[0]].to_list()

    #parameters
    height_nn = params.loc[params["name"]=="height_nn", "value"].iloc[0]
    latent_heat_of_vaporization = params.loc[params["name"]=="latent_heat_of_vaporization", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["reference_evapotranspiration"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        mean_air_temperature = t_mean_air_temperature[i]
        wind_speed = t_wind_speed[i]
        wind_speed_height = t_wind_speed_height[i]
        stomata_resistance = t_stomata_resistance[i]
        net_radiation = t_net_radiation[i]
        saturation_vapor_pressure_deficit = t_saturation_vapor_pressure_deficit[i]
        saturated_vapor_pressure_slope = t_saturated_vapor_pressure_slope[i]
        psychrometric_constant = t_psychrometric_constant[i]
        reference_evapotranspiration= AMEIRefETComponent.model_ameirefet(height_nn,latent_heat_of_vaporization,mean_air_temperature,wind_speed,wind_speed_height,stomata_resistance,net_radiation,saturation_vapor_pressure_deficit,saturated_vapor_pressure_slope,psychrometric_constant)

        df_out.loc[i] = [reference_evapotranspiration]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out