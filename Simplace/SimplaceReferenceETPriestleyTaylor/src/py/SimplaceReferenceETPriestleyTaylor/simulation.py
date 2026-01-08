from . import ReferenceETPriestleyTaylor_Component
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_iTMin = df[vardata.loc[vardata["Variables"]=="iTMin","Data columns"].iloc[0]].to_list()
    t_iNetRadiation = df[vardata.loc[vardata["Variables"]=="iNetRadiation","Data columns"].iloc[0]].to_list()
    t_iTMax = df[vardata.loc[vardata["Variables"]=="iTMax","Data columns"].iloc[0]].to_list()

    #parameters
    cAlphaPT = params.loc[params["name"]=="cAlphaPT", "value"].iloc[0]
    cAltitude = params.loc[params["name"]=="cAltitude", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["ReferenceCropEvapotranspiration"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        iTMin = t_iTMin[i]
        iNetRadiation = t_iNetRadiation[i]
        iTMax = t_iTMax[i]
        ReferenceCropEvapotranspiration= ReferenceETPriestleyTaylor_Component.model_referenceetpriestleytaylor_(iTMin,cAlphaPT,iNetRadiation,iTMax,cAltitude)

        df_out.loc[i] = [ReferenceCropEvapotranspiration]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out