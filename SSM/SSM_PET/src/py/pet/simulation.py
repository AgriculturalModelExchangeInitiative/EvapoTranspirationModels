from . import petComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_tmax = df[vardata.loc[vardata["Variables"]=="tmax","Data columns"].iloc[0]].to_list()
    t_tmin = df[vardata.loc[vardata["Variables"]=="tmin","Data columns"].iloc[0]].to_list()
    t_srad = df[vardata.loc[vardata["Variables"]=="srad","Data columns"].iloc[0]].to_list()
    t_ddmp = df[vardata.loc[vardata["Variables"]=="ddmp","Data columns"].iloc[0]].to_list()
    t_lai = df[vardata.loc[vardata["Variables"]=="lai","Data columns"].iloc[0]].to_list()

    #parameters
    albedo = params.loc[params["name"]=="albedo", "value"].iloc[0]
    TEC = params.loc[params["name"]=="TEC", "value"].iloc[0]
    VPDF = params.loc[params["name"]=="VPDF", "value"].iloc[0]
    kpar = params.loc[params["name"]=="kpar", "value"].iloc[0]
    RUE = params.loc[params["name"]=="RUE", "value"].iloc[0]
    TBRUE = params.loc[params["name"]=="TBRUE", "value"].iloc[0]
    TP1RUE = params.loc[params["name"]=="TP1RUE", "value"].iloc[0]
    TP2RUE = params.loc[params["name"]=="TP2RUE", "value"].iloc[0]
    TCRUE = params.loc[params["name"]=="TCRUE", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["pet","TR","DDMP"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        tmax = t_tmax[i]
        tmin = t_tmin[i]
        srad = t_srad[i]
        ddmp = t_ddmp[i]
        lai = t_lai[i]
        pet,TR,DDMP= petComponent.model_pet(tmax,tmin,srad,albedo,ddmp,TEC,VPDF,lai,kpar,RUE,TBRUE,TP1RUE,TP2RUE,TCRUE)

        df_out.loc[i] = [pet,TR,DDMP]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out