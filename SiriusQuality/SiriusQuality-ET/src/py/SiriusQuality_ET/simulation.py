from . import EnergyBalanceCompositeComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_maxTair = df[vardata.loc[vardata["Variables"]=="maxTair","Data columns"].iloc[0]].to_list()
    t_minTair = df[vardata.loc[vardata["Variables"]=="minTair","Data columns"].iloc[0]].to_list()
    t_vaporPressure = df[vardata.loc[vardata["Variables"]=="vaporPressure","Data columns"].iloc[0]].to_list()
    t_ih = df[vardata.loc[vardata["Variables"]=="ih","Data columns"].iloc[0]].to_list()
    t_extraSolarRadiation = df[vardata.loc[vardata["Variables"]=="extraSolarRadiation","Data columns"].iloc[0]].to_list()
    t_solarRadiation = df[vardata.loc[vardata["Variables"]=="solarRadiation","Data columns"].iloc[0]].to_list()
    t_plantHeight = df[vardata.loc[vardata["Variables"]=="plantHeight","Data columns"].iloc[0]].to_list()
    t_wind = df[vardata.loc[vardata["Variables"]=="wind","Data columns"].iloc[0]].to_list()
    t_hslope = df[vardata.loc[vardata["Variables"]=="hslope","Data columns"].iloc[0]].to_list()
    t_VPDair = df[vardata.loc[vardata["Variables"]=="VPDair","Data columns"].iloc[0]].to_list()

    #parameters
    albedoCoefficient = params.loc[params["name"]=="albedoCoefficient", "value"].iloc[0]
    tau = params.loc[params["name"]=="tau", "value"].iloc[0]
    elevation = params.loc[params["name"]=="elevation", "value"].iloc[0]
    stefanBoltzman = params.loc[params["name"]=="stefanBoltzman", "value"].iloc[0]
    albedoCoefficientCan = params.loc[params["name"]=="albedoCoefficientCan", "value"].iloc[0]
    d = params.loc[params["name"]=="d", "value"].iloc[0]
    heightWeatherMeasurements = params.loc[params["name"]=="heightWeatherMeasurements", "value"].iloc[0]
    zh = params.loc[params["name"]=="zh", "value"].iloc[0]
    zm = params.loc[params["name"]=="zm", "value"].iloc[0]
    vonKarman = params.loc[params["name"]=="vonKarman", "value"].iloc[0]
    lambdaV = params.loc[params["name"]=="lambdaV", "value"].iloc[0]
    psychrometricConstant = params.loc[params["name"]=="psychrometricConstant", "value"].iloc[0]
    Alpha = params.loc[params["name"]=="Alpha", "value"].iloc[0]
    specificHeatCapacityAir = params.loc[params["name"]=="specificHeatCapacityAir", "value"].iloc[0]
    rhoDensityAir = params.loc[params["name"]=="rhoDensityAir", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["netOutGoingLongWaveRadiation","conductance","netRadiation","evapoTranspirationPriestlyTaylor","evapoTranspirationPenman"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        maxTair = t_maxTair[i]
        minTair = t_minTair[i]
        vaporPressure = t_vaporPressure[i]
        ih = t_ih[i]
        extraSolarRadiation = t_extraSolarRadiation[i]
        solarRadiation = t_solarRadiation[i]
        plantHeight = t_plantHeight[i]
        wind = t_wind[i]
        hslope = t_hslope[i]
        VPDair = t_VPDair[i]
        netOutGoingLongWaveRadiation,conductance,netRadiation,evapoTranspirationPriestlyTaylor,evapoTranspirationPenman= EnergyBalanceCompositeComponent.model_energybalancecomposite(albedoCoefficient,maxTair,minTair,vaporPressure,ih,extraSolarRadiation,solarRadiation,tau,elevation,stefanBoltzman,albedoCoefficientCan,d,heightWeatherMeasurements,plantHeight,zh,zm,vonKarman,wind,lambdaV,psychrometricConstant,Alpha,hslope,VPDair,specificHeatCapacityAir,rhoDensityAir)

        df_out.loc[i] = [netOutGoingLongWaveRadiation,conductance,netRadiation,evapoTranspirationPriestlyTaylor,evapoTranspirationPenman]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out