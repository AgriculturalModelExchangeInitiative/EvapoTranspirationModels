from . import AMEIPotETComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_vapor_pressure = df[vardata.loc[vardata["Variables"]=="vapor_pressure","Data columns"].iloc[0]].to_list()
    t_saturated_vapor_pressure = df[vardata.loc[vardata["Variables"]=="saturated_vapor_pressure","Data columns"].iloc[0]].to_list()
    t_mean_air_temperature = df[vardata.loc[vardata["Variables"]=="mean_air_temperature","Data columns"].iloc[0]].to_list()
    t_wind_speed = df[vardata.loc[vardata["Variables"]=="wind_speed","Data columns"].iloc[0]].to_list()
    t_wind_speed_height = df[vardata.loc[vardata["Variables"]=="wind_speed_height","Data columns"].iloc[0]].to_list()
    t_stomata_resistance = df[vardata.loc[vardata["Variables"]=="stomata_resistance","Data columns"].iloc[0]].to_list()
    t_net_radiation = df[vardata.loc[vardata["Variables"]=="net_radiation","Data columns"].iloc[0]].to_list()
    t_kc_factor = df[vardata.loc[vardata["Variables"]=="kc_factor","Data columns"].iloc[0]].to_list()
    t_developmental_stage = df[vardata.loc[vardata["Variables"]=="developmental_stage","Data columns"].iloc[0]].to_list()
    t_crop_remaining_evapotranspiration = df[vardata.loc[vardata["Variables"]=="crop_remaining_evapotranspiration","Data columns"].iloc[0]].to_list()

    #parameters
    height_nn = params.loc[params["name"]=="height_nn", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["reference_evapotranspiration","potential_evapotranspiration"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        vapor_pressure = t_vapor_pressure[i]
        saturated_vapor_pressure = t_saturated_vapor_pressure[i]
        mean_air_temperature = t_mean_air_temperature[i]
        wind_speed = t_wind_speed[i]
        wind_speed_height = t_wind_speed_height[i]
        stomata_resistance = t_stomata_resistance[i]
        net_radiation = t_net_radiation[i]
        kc_factor = t_kc_factor[i]
        developmental_stage = t_developmental_stage[i]
        crop_remaining_evapotranspiration = t_crop_remaining_evapotranspiration[i]
        reference_evapotranspiration,potential_evapotranspiration= AMEIPotETComponent.model_ameipotet(vapor_pressure,saturated_vapor_pressure,height_nn,mean_air_temperature,wind_speed,wind_speed_height,stomata_resistance,net_radiation,kc_factor,developmental_stage,crop_remaining_evapotranspiration)

        df_out.loc[i] = [reference_evapotranspiration,potential_evapotranspiration]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out