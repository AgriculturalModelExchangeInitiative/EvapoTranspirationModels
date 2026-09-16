from . import PotentialET_PenmanComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_netRadiation = df[vardata.loc[vardata["Variables"]=="netRadiation","Data columns"].iloc[0]].to_list()
    t_solarRadiation = df[vardata.loc[vardata["Variables"]=="solarRadiation","Data columns"].iloc[0]].to_list()
    t_hslope = df[vardata.loc[vardata["Variables"]=="hslope","Data columns"].iloc[0]].to_list()
    t_VPDair = df[vardata.loc[vardata["Variables"]=="VPDair","Data columns"].iloc[0]].to_list()
    t_conductance = df[vardata.loc[vardata["Variables"]=="conductance","Data columns"].iloc[0]].to_list()

    #parameters
    lambdaV = params.loc[params["name"]=="lambdaV", "value"].iloc[0]
    psychrometricConstant = params.loc[params["name"]=="psychrometricConstant", "value"].iloc[0]
    Alpha = params.loc[params["name"]=="Alpha", "value"].iloc[0]
    ih = params.loc[params["name"]=="ih", "value"].iloc[0]
    specificHeatCapacityAir = params.loc[params["name"]=="specificHeatCapacityAir", "value"].iloc[0]
    rhoDensityAir = params.loc[params["name"]=="rhoDensityAir", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["evapoTranspirationPenman"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        netRadiation = t_netRadiation[i]
        solarRadiation = t_solarRadiation[i]
        hslope = t_hslope[i]
        VPDair = t_VPDair[i]
        conductance = t_conductance[i]
        evapoTranspirationPenman= PotentialET_PenmanComponent.model_potentialet_penman(netRadiation,lambdaV,psychrometricConstant,Alpha,solarRadiation,hslope,ih,VPDair,specificHeatCapacityAir,rhoDensityAir,conductance)

        df_out.loc[i] = [evapoTranspirationPenman]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out