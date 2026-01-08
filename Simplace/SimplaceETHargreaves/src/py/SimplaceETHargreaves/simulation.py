from . import ReferenceETHargreaves_Component
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_iTMax = df[vardata.loc[vardata["Variables"]=="iTMax","Data columns"].iloc[0]].to_list()
    t_iSolarRadiation = df[vardata.loc[vardata["Variables"]=="iSolarRadiation","Data columns"].iloc[0]].to_list()
    t_iTMin = df[vardata.loc[vardata["Variables"]=="iTMin","Data columns"].iloc[0]].to_list()

    #parameters
    cConvertLeByTemp = params.loc[params["name"]=="cConvertLeByTemp", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["ReferenceCropEvapotranspiration"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        iTMax = t_iTMax[i]
        iSolarRadiation = t_iSolarRadiation[i]
        iTMin = t_iTMin[i]
        ReferenceCropEvapotranspiration= ReferenceETHargreaves_Component.model_referenceethargreaves_(iTMax,iSolarRadiation,iTMin,cConvertLeByTemp)

        df_out.loc[i] = [ReferenceCropEvapotranspiration]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out