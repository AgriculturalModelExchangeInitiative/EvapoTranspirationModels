from . import PotentialET_PTComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_solarRadiation = df[vardata.loc[vardata["Variables"]=="solarRadiation","Data columns"].iloc[0]].to_list()
    t_hslope = df[vardata.loc[vardata["Variables"]=="hslope","Data columns"].iloc[0]].to_list()
    t_netRadiation = df[vardata.loc[vardata["Variables"]=="netRadiation","Data columns"].iloc[0]].to_list()

    #parameters
    lambdaV = params.loc[params["name"]=="lambdaV", "value"].iloc[0]
    psychrometricConstant = params.loc[params["name"]=="psychrometricConstant", "value"].iloc[0]
    Alpha = params.loc[params["name"]=="Alpha", "value"].iloc[0]
    ih = params.loc[params["name"]=="ih", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["evapoTranspirationPriestlyTaylor"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        solarRadiation = t_solarRadiation[i]
        hslope = t_hslope[i]
        netRadiation = t_netRadiation[i]
        evapoTranspirationPriestlyTaylor= PotentialET_PTComponent.model_potentialet_pt(lambdaV,psychrometricConstant,Alpha,solarRadiation,hslope,ih,netRadiation)

        df_out.loc[i] = [evapoTranspirationPriestlyTaylor]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out