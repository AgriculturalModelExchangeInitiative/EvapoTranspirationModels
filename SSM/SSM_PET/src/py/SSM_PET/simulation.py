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

    #parameters
    albedo = params.loc[params["name"]=="albedo", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["pet"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        tmax = t_tmax[i]
        tmin = t_tmin[i]
        srad = t_srad[i]
        pet= petComponent.model_pet(tmax,tmin,srad,albedo)

        df_out.loc[i] = [pet]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out