from . import ETComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_global_radiation = df[vardata.loc[vardata["Variables"]=="global_radiation","Data columns"].iloc[0]].to_list()
    t_julian_day = df[vardata.loc[vardata["Variables"]=="julian_day","Data columns"].iloc[0]].to_list()
    t_sunshine_hours = df[vardata.loc[vardata["Variables"]=="sunshine_hours","Data columns"].iloc[0]].to_list()
    t_max_air_temperature = df[vardata.loc[vardata["Variables"]=="max_air_temperature","Data columns"].iloc[0]].to_list()
    t_min_air_temperature = df[vardata.loc[vardata["Variables"]=="min_air_temperature","Data columns"].iloc[0]].to_list()
    t_use_external_vapor_pressure = df[vardata.loc[vardata["Variables"]=="use_external_vapor_pressure","Data columns"].iloc[0]].to_list()
    t_external_vapor_pressure = df[vardata.loc[vardata["Variables"]=="external_vapor_pressure","Data columns"].iloc[0]].to_list()
    t_relative_humidity = df[vardata.loc[vardata["Variables"]=="relative_humidity","Data columns"].iloc[0]].to_list()
    t_calc_stomata_resistance = df[vardata.loc[vardata["Variables"]=="calc_stomata_resistance","Data columns"].iloc[0]].to_list()
    t_fixed_stomata_resistance = df[vardata.loc[vardata["Variables"]=="fixed_stomata_resistance","Data columns"].iloc[0]].to_list()
    t_gross_photosynthesis_reference_mol = df[vardata.loc[vardata["Variables"]=="gross_photosynthesis_reference_mol","Data columns"].iloc[0]].to_list()
    t_atmospheric_co2_concentration = df[vardata.loc[vardata["Variables"]=="atmospheric_co2_concentration","Data columns"].iloc[0]].to_list()
    t_mean_air_temperature = df[vardata.loc[vardata["Variables"]=="mean_air_temperature","Data columns"].iloc[0]].to_list()
    t_wind_speed = df[vardata.loc[vardata["Variables"]=="wind_speed","Data columns"].iloc[0]].to_list()
    t_wind_speed_height = df[vardata.loc[vardata["Variables"]=="wind_speed_height","Data columns"].iloc[0]].to_list()
    t_stomata_resistance = df[vardata.loc[vardata["Variables"]=="stomata_resistance","Data columns"].iloc[0]].to_list()
    t_net_radiation = df[vardata.loc[vardata["Variables"]=="net_radiation","Data columns"].iloc[0]].to_list()
    t_kc_factor = df[vardata.loc[vardata["Variables"]=="kc_factor","Data columns"].iloc[0]].to_list()
    t_developmental_stage = df[vardata.loc[vardata["Variables"]=="developmental_stage","Data columns"].iloc[0]].to_list()
    t_crop_remaining_evapotranspiration = df[vardata.loc[vardata["Variables"]=="crop_remaining_evapotranspiration","Data columns"].iloc[0]].to_list()
    t_has_snow_cover = df[vardata.loc[vardata["Variables"]=="has_snow_cover","Data columns"].iloc[0]].to_list()
    t_crop_transpiration = df[vardata.loc[vardata["Variables"]=="crop_transpiration","Data columns"].iloc[0]].to_list()
    t_crop_evaporated_from_intercepted = df[vardata.loc[vardata["Variables"]=="crop_evaporated_from_intercepted","Data columns"].iloc[0]].to_list()
    t_percentage_soil_coverage = df[vardata.loc[vardata["Variables"]=="percentage_soil_coverage","Data columns"].iloc[0]].to_list()
    t_surface_water_storage = df[vardata.loc[vardata["Variables"]=="surface_water_storage","Data columns"].iloc[0]].to_list()
    t_evaporated_from_surface = df[vardata.loc[vardata["Variables"]=="evaporated_from_surface","Data columns"].iloc[0]].to_list()
    t_actual_evaporation = df[vardata.loc[vardata["Variables"]=="actual_evaporation","Data columns"].iloc[0]].to_list()
    t_actual_transpiration = df[vardata.loc[vardata["Variables"]=="actual_transpiration","Data columns"].iloc[0]].to_list()
    t_soil_moisture = df[vardata.loc[vardata["Variables"]=="soil_moisture","Data columns"].iloc[0]].to_list()
    t_evaporation = df[vardata.loc[vardata["Variables"]=="evaporation","Data columns"].iloc[0]].to_list()
    t_transpiration = df[vardata.loc[vardata["Variables"]=="transpiration","Data columns"].iloc[0]].to_list()
    t_evapotranspiration = df[vardata.loc[vardata["Variables"]=="evapotranspiration","Data columns"].iloc[0]].to_list()
    t_actual_evapotranspiration = df[vardata.loc[vardata["Variables"]=="actual_evapotranspiration","Data columns"].iloc[0]].to_list()
    t_use_external_et0 = df[vardata.loc[vardata["Variables"]=="use_external_et0","Data columns"].iloc[0]].to_list()
    t_external_et0 = df[vardata.loc[vardata["Variables"]=="external_et0","Data columns"].iloc[0]].to_list()

    #parameters
    latitude = params.loc[params["name"]=="latitude", "value"].iloc[0]
    reference_albedo = params.loc[params["name"]=="reference_albedo", "value"].iloc[0]
    height_nn = params.loc[params["name"]=="height_nn", "value"].iloc[0]
    saturation_beta = params.loc[params["name"]=="saturation_beta", "value"].iloc[0]
    stomata_conductance_alpha = params.loc[params["name"]=="stomata_conductance_alpha", "value"].iloc[0]
    carboxylation_pathway = params.loc[params["name"]=="carboxylation_pathway", "value"].iloc[0]
    evaporation_zeta = params.loc[params["name"]=="evaporation_zeta", "value"].iloc[0]
    maximum_evaporation_impact_depth = params.loc[params["name"]=="maximum_evaporation_impact_depth", "value"].iloc[0]
    evaporation_reduction_method = params.loc[params["name"]=="evaporation_reduction_method", "value"].iloc[0]
    xsa_critical_soil_moisture = params.loc[params["name"]=="xsa_critical_soil_moisture", "value"].iloc[0]
    no_of_soil_layers = params.loc[params["name"]=="no_of_soil_layers", "value"].iloc[0]
    no_of_soil_moisture_layers = params.loc[params["name"]=="no_of_soil_moisture_layers", "value"].iloc[0]
    layer_thickness = params.loc[params["name"]=="layer_thickness", "value"].iloc[0]
    permanent_wilting_point = params.loc[params["name"]=="permanent_wilting_point", "value"].iloc[0]
    field_capacity = params.loc[params["name"]=="field_capacity", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["declination","astronomic_daylength","effective_daylength","photoperiodic_daylength","sunshine_hours_global_radiation","extraterrestrial_radiation","clear_day_radiation","overcast_day_radiation","phot_act_radiation_mean","reference_evapotranspiration","potential_evapotranspiration"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        global_radiation = t_global_radiation[i]
        julian_day = t_julian_day[i]
        sunshine_hours = t_sunshine_hours[i]
        max_air_temperature = t_max_air_temperature[i]
        min_air_temperature = t_min_air_temperature[i]
        use_external_vapor_pressure = t_use_external_vapor_pressure[i]
        external_vapor_pressure = t_external_vapor_pressure[i]
        relative_humidity = t_relative_humidity[i]
        calc_stomata_resistance = t_calc_stomata_resistance[i]
        fixed_stomata_resistance = t_fixed_stomata_resistance[i]
        gross_photosynthesis_reference_mol = t_gross_photosynthesis_reference_mol[i]
        atmospheric_co2_concentration = t_atmospheric_co2_concentration[i]
        mean_air_temperature = t_mean_air_temperature[i]
        wind_speed = t_wind_speed[i]
        wind_speed_height = t_wind_speed_height[i]
        stomata_resistance = t_stomata_resistance[i]
        net_radiation = t_net_radiation[i]
        kc_factor = t_kc_factor[i]
        developmental_stage = t_developmental_stage[i]
        crop_remaining_evapotranspiration = t_crop_remaining_evapotranspiration[i]
        has_snow_cover = t_has_snow_cover[i]
        crop_transpiration = t_crop_transpiration[i]
        crop_evaporated_from_intercepted = t_crop_evaporated_from_intercepted[i]
        percentage_soil_coverage = t_percentage_soil_coverage[i]
        surface_water_storage = t_surface_water_storage[i]
        evaporated_from_surface = t_evaporated_from_surface[i]
        actual_evaporation = t_actual_evaporation[i]
        actual_transpiration = t_actual_transpiration[i]
        soil_moisture = t_soil_moisture[i]
        evaporation = t_evaporation[i]
        transpiration = t_transpiration[i]
        evapotranspiration = t_evapotranspiration[i]
        actual_evapotranspiration = t_actual_evapotranspiration[i]
        use_external_et0 = t_use_external_et0[i]
        external_et0 = t_external_et0[i]
        declination,astronomic_daylength,effective_daylength,photoperiodic_daylength,sunshine_hours_global_radiation,extraterrestrial_radiation,clear_day_radiation,overcast_day_radiation,phot_act_radiation_mean,reference_evapotranspiration,potential_evapotranspiration= ETComponent.model_et(latitude,global_radiation,julian_day,sunshine_hours,reference_albedo,height_nn,max_air_temperature,min_air_temperature,use_external_vapor_pressure,external_vapor_pressure,relative_humidity,calc_stomata_resistance,fixed_stomata_resistance,saturation_beta,stomata_conductance_alpha,carboxylation_pathway,gross_photosynthesis_reference_mol,atmospheric_co2_concentration,mean_air_temperature,wind_speed,wind_speed_height,stomata_resistance,net_radiation,kc_factor,developmental_stage,crop_remaining_evapotranspiration,evaporation_zeta,maximum_evaporation_impact_depth,evaporation_reduction_method,xsa_critical_soil_moisture,no_of_soil_layers,no_of_soil_moisture_layers,layer_thickness,permanent_wilting_point,field_capacity,has_snow_cover,crop_transpiration,crop_evaporated_from_intercepted,percentage_soil_coverage,surface_water_storage,evaporated_from_surface,actual_evaporation,actual_transpiration,soil_moisture,evaporation,transpiration,evapotranspiration,actual_evapotranspiration,use_external_et0,external_et0)

        df_out.loc[i] = [declination,astronomic_daylength,effective_daylength,photoperiodic_daylength,sunshine_hours_global_radiation,extraterrestrial_radiation,clear_day_radiation,overcast_day_radiation,phot_act_radiation_mean,reference_evapotranspiration,potential_evapotranspiration]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out