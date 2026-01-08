/*
 * SIMPLACE - Scientific Impact assessment and Modeling PLattform for Advanced Crop and Ecosystem management
 *
 * This file is part of the SIMPLACE (before SMILEUtil) project.
 *
 * SIMPLACE is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * SIMPLACE is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with SIMPLACE.  If not, see <http://www.gnu.org/licenses/>.
 *
 * EquationsFAO56.java
 *
 * Responsible developers: Gunther Krauss, Crop Science Group, Katzenburgweg 5, 53115 Bonn, Germany
 *                         Andreas Enders, Crop Science Group, Katzenburgweg 5, 53115 Bonn, Germany
 * Contact Information:    lapit@uni-bonn.de
 * More information on <http://www.simplace.net>
 */

package net.simplace.sim.components.util.helper;

import static java.lang.StrictMath.*;


/**
 * Helper EquationsFAO56 for computing values due to equations from (FAO 56)
 * WIKI_START
 * Equation numbers refers to the paper cited below.
 *
 * == References ==
 * 
 * - [http://www.fao.org/docrep/x0490e/x0490e00.htm (FAO 56): Allen, Crop evapotranspiration - Guidelines for computing crop water requirements - FAO Irrigation and drainage paper 56, 1998]
 * - (Harrison) Harrison, L.P. 1963. Fundamentals concepts and definitions relating to humidity. In A. Wexler (ed.) Humidity and moisture. Vol 3. Reinhold Publishing Company, New York.
 * 
 * WIKI_END
 * @author Gunther Krauss
 *
 */
public class EquationsFAO56 {

	static final double G_sc = 0.0820; // solar constant [MJ m-2 min-1]
	static final double minutes_per_day = 24*60; // minutes per day [min]
	static final double sigma = 4.903E-9; // Stefan-Boltzman-constant [MJ K-4 m-2 day-1]

	/** default Value for Angstrom variables, regression constant */
	public static final double a_s_Default = 0.25;
	/** default Value for Angstrom variables, regression slope */
	public static final double b_s_Default = 0.50;
	/** default albedo for the hypothetical grass reference crop */
	public static final double albedo = 0.23;
	/** latent heat of vaporization [MJ kg-1] */
	public static final double lambda = 2.45;


	/**
	 * Calculates the daily crop evapotranspiration with the FAO-Penman-Montheith method
	 * Eq. (6)
	 *
	 * FAO Penman-Monteith equation determines the evapotranspiration from the hypothetical
	 * grass reference surface and provides a standard to which evapotranspiration in
	 * different periods of the year or in other regions can be compared and to which the
	 * evapotranspiration from other crops can be related. [FAO 56, p.65f]
	 *
	 * @param T air temperature at 2 m height [°C]
	 * @param R_n net radiation at the crop surface [MJ m-2 day-1]
	 * @param u_2 wind speed at 2m height [m s-1]
	 * @param e_s saturation vapour pressure [kPa]
	 * @param e_a actual vapour pressure [kPa]
	 * @param z elevation above sea level [m]
	 * @return crop reference evapotranspiration ET0 [mm day-1]
	 */
	public static double ReferenceEvapotranspiration(double T, double R_n, double u_2, double e_s, double e_a, double z)
	{
		double P = AtmosphericPressure(z);
		double gamma = PsychrometricConstant(P);
		double Delta = SlopeOfSaturationVapPressureCurve(T);
		double G = 0; // soil heat flux density [MJ m-2 day-1] can be neglected for daily calculations

		double ET0 = (0.408*Delta*(R_n-G) + gamma*(900/(T+273))*u_2*(e_s  -e_a)) / (Delta + gamma*(1 + 0.34*u_2));
		return ET0;
	}


	/**
	 * Calculates the atmospheric Pressure P
	 * Eq. (7)
	 *
	 * @param z elevation above sea level [m]
	 * @return atmospheric pressure P [kPa]
	 */
	public static double AtmosphericPressure(double z)
	{
		return 101.3*pow((293-0.0065*z)/293,5.26);
	}


	/**
	 * Calculates the psychrometric constant gamma as function of atmospheric pressure P
	 * Eq. (8)
	 *
	 * The factor is calculated from parameters for average atmospheric conditions and is
	 * rounded to 3 decimals to be consistent with the reference.
	 *
	 * @param P atmospheric pressure [kPa]
	 * @return psychrometric constant gamma [kPa °C-1]
	 */
	public static double PsychrometricConstant(double P)
	{
		final double c_p = 1.013E-3; // specific heat at constant pressure (for average atmospheric conditions) [MJ kg-1 °C-1]
		final double epsilon= 0.622; // ratio molecular weight of water vapour/dry air
		final double factor = round(c_p/(epsilon*lambda)*10E6)/10E6;
		return factor*P;
	}

	/**
	 * Saturation vapour pressure at air temperature T
	 * Eq. (11)
	 *
	 * @param T air temperature [°C]
	 * @return vapour pressure e_0_T [kPa]
	 */
	public static double SaturationVapourPressureAtTemperature(double T)
	{
		return 0.6108 * exp(17.27 * T / (T+237.3));
	}

	/**
	 * Mean vapour pressure of a period
	 * Eq. (12)
	 *
	 * @param T_max maximum air temperature during period [°C]
	 * @param T_min minimum air temperature during period [°C]
	 * @return mean vapour pressure e_s [kPa]
	 */
	public static double MeanSaturatedVapourPressure(double T_max, double T_min)
	{
		return (SaturationVapourPressureAtTemperature(T_max)+SaturationVapourPressureAtTemperature(T_min)) / 2;
	}

	/**
	 * Calculates the slope  of saturation vapour pressure curve Delta as function of temperature T
	 * Eq (13)
	 *
	 * @param T air temperature [°C]
	 * @return slope of saturation vapour pressure Delta [kPa °C-1]
	 */
	public static double SlopeOfSaturationVapPressureCurve(double T)
	{
		double tempT = T+237.3;
		return  4098*(0.6108*exp(17.27*T/(tempT)))/pow(tempT,2);
	}

	/**
	 * Actual vapour pressure at dewpoint
	 * Eq. (14)
	 *
	 * @param T_dew dewpoint temperature [°C]
	 * @return actual vapour pressure e_a [kPa]
	 */
	public static double VapourPressureFromDewpoint(double T_dew)
	{
		return SaturationVapourPressureAtTemperature(T_dew);
	}

	/**
	 * Actual vapour pressure derived from psychrometric data
	 * Eq. (15)
	 *
	 * @param T_dry dry bulb temperature [°C]
	 * @param T_wet wet bulb temperature [°C]
	 * @param a_psy psychrometric constant of the instrument [°C-1]
	 * @param z elevation from sea level [m]
	 * @return actual vapour pressure e_a [kPa]
	 */
	public static double VapourPressureFromPsychrometricData(double T_dry, double T_wet, double a_psy, double z)
	{
		double gamma_psy = PsyochrometricConstantOfInstrument(a_psy, z);
		return SaturationVapourPressureAtTemperature(T_wet) - gamma_psy*(T_dry - T_wet);
	}

	/**
	 * Psychrometric constant of the instrument
	 * Eq. (16)
	 *
	 * @param a_psy psychrometric constant of the instrument [°C-1]
	 * @param z elevation from sea level [m]
	 * @return psychrometric constant of the instrument [kPa °C-1]
	 */
	static double PsyochrometricConstantOfInstrument(double a_psy, double z)
	{
		double P = AtmosphericPressure(z);
		return a_psy * P;
	}

	/**
	 * Actual vapour pressure from maximum and minimum relative humidity
	 * Eq. (17)
	 *
	 * @param RH_max maximum relative humidity [%]
	 * @param RH_min minimum relative humidity [%]
	 * @param T_max maximum temperature [°C]
	 * @param T_min minimum temperature [°C]
	 * @return actual vapour pressure e_a [kPa]
	 */
	public static double VapourPressureFromRelHumidityMaxMin(double RH_max, double RH_min, double T_max, double T_min)
	{
		return (SaturationVapourPressureAtTemperature(T_min)*RH_max/100 + SaturationVapourPressureAtTemperature(T_max)*RH_min/100)/2;
	}

	/**
	 * Actual vapour pressure from maximum relative humidity
	 * Eq. (18)
	 *
	 * @param RH_max maximum relative humidity [%]
	 * @param T_min minimum temperature [°C]
	 * @return actual vapour pressure e_a [kPa]
	 */
	public static double VapourPressureFromRelHumidityMax(double RH_max, double T_min)
	{
		return SaturationVapourPressureAtTemperature(T_min)*RH_max/100;
	}

	/**
	 * Actual vapour pressure from mean relative humidity
	 * Eq. (19)
	 *
	 * @param RH_mean mean relative humidity [%]
	 * @param T_max maximum temperature [°C]
	 * @param T_min minimum temperature [°C]
	 * @return actual vapour pressure e_a [kPa]
	 */
	public static double VapourPressureFromRelHumidityMean(double RH_mean, double T_max, double T_min)
	{
		return RH_mean/100 * MeanSaturatedVapourPressure(T_max, T_min);
	}

	/**
	 * Converts radiation [energy/surface] to equivalent evaporation [depth of water]
	 * Eq. (20)
	 *
	 * @param Radiation [MJ m-2 day-1]
	 * @return equivalent evaporation [mm day-1]
	 */
	public static double EvaporationEquivalentToRadiation(double Radiation)
	{
		return 0.408 * Radiation;
	}

	/**
	 * Converts radiation [energy/surface] to equivalent evaporation [depth of water]
	 * 
	 * Correction by daily mean temperature (for 21.18°C it yields a conversion factor of 0.408)
	 * See (Harrison)
	 *
	 * @param Radiation [MJ m-2 day-1]
	 * @param DailyMeanTemperature [°C]
	 * @return equivalent evaporation [mm day-1]
	 */
	public static double EvaporationEquivalentToRadiation(double Radiation, double DailyMeanTemperature)
	{
		return 1/(2.501-0.002361*DailyMeanTemperature) * Radiation;
	}

	
	
	/**
	 * Calculates extraterrestrial radiation
	 * Eq. (21)
	 *
	 * @param d_r inverse relative distance earth-sun
	 * @param omega_s sunset hour angle [rad]
	 * @param phi latitude [rad]
	 * @param delta solar declination [rad]
	 * @return extraterrestrial radiation per day [MJ m-2 day-1]
	 */
	public static double ExtraterrestrialRadiation(double d_r, double omega_s, double phi, double delta)
	{
		double angle = omega_s*sin(phi)*sin(delta) + cos(phi)*cos(delta)*sin(omega_s);
		return minutes_per_day/PI * G_sc * d_r * angle;
	}

	/**
        * Convert decimal degrees to radians Eq. (22)
        *
        * @param degree [degree]
        * @return radians [rad]
        */
	public static double DecimalDegreesToRadians(double degree)
	{
		return PI / 180.0 * degree;
	}

	/**
     * Inverse relative distance Earth-Sun
     * Eq. (23)
     *
     * @param J number of the day in the year (DOY) [day]
     * @return inverse relative distance d_r []
     */
	public static double InverseRelativeDistanceEarthSun(int J)
	{
		return 1 + 0.033 * cos(2*PI/365.0 * J);
	}

	/**
	 * Solar declination
	 * Eq. (24)
	 *
	 * @param J number of the day in the year (DOY) [day]
	 * @return solar declination delta [rad]
	 */
	public static double SolarDeclination(int J)
	{
		return 0.409*sin(2*PI*J/365.0 - 1.39);
	}

	/**
	 * Sunset hour angle
	 * Eq. (25)
	 *
	 * @param phi latitude [rad]
	 * @param delta solar declination [rad]
	 * @return sunset hour angle omega_s [rad]
	 */
	public static double SunsetHourAngle(double phi, double delta)
	{
		return acos(-tan(phi)*tan(delta));
	}

	/**
	 * Diurnal extraterrestrial radiation
	 * Eq. (29(
	 *
	 *
	 * @param d_r
	 * @param delta
	 * @param phi
	 * @param omega_1
	 * @param omega_2
	 * @return
	 */
	public static double ExtraterrestrialRadiationDiurnal(double d_r, double delta, double phi, double omega_1, double omega_2)
	{
	    double angle = (omega_2-omega_1)*sin(phi)*sin(delta)+cos(phi)*cos(delta)*(sin(omega_2)-sin(omega_1));
	    double R_a = 12*60 / PI * G_sc*d_r*angle;
	    return R_a;
	}

	/**
	 * Solar time angle at beginning of period
	 * Eq. (29)
	 *
	 * @param t_l length of calculation period [h]
	 * @param omega solar time angel at midpoint of hourly or shorter period [rad]
	 * @return solar time angle at beginning omega_1 [rad]
	 */
	public static double SolarTimeAngleBeginning(double t_l, double omega)
	{
	    double omega_1 = omega - PI * t_l / 24;
	    return omega_1;
	}

	/**
	 * Solar time angle at end of period
	 * Eq. (30)
	 *
	 * @param t_l length of calculation period [h]
	 * @param omega solar time angel at midpoint of hourly or shorter period [rad]
	 * @return solar time angle at end omega_2 [rad]
	 */
	public static double SolarTimeAngleEnd(double t_l, double omega)
	{
	    double omega_1 = omega + PI * t_l / 24;
	    return omega_1;
	}

	/**
	 * Solar time angel at midpoint of period
	 * Eq. (31)
	 *
	 * @param t standard clock time at the midpoint of the period [h]
	 * @param L_z longitude of the center of the local time zone [degree]
	 * @param L_m longitude of the measurement site [degree]
	 * @param S_c seasonal correction for solar time [h]
	 * @return
	 */
        public static double SolarTimeAngleMidpoint(double t, double L_z, double L_m, double S_c)
        {
	    double omega = PI / 12 * ((t + 0.06667 * (L_z - L_m) + S_c) - 12);
	    return omega;
        }

	/**
	 * Seasonal correction for solar time
	 * Eq. (32) and (33)
	 * 	 *
	 * @param J day of year
	 * @return seasonal correction S_c [hour]
	 */
	public static double SeasonalCorrectionSolarTime(int J)
	{
	    double b = 2 * PI * (J-81) / 364;
	    double S_c = 0.1645 * sin(2*b) - 0.1255*cos(b)-0.025*sin(b);
	    return S_c;
	}


	/**
	 * Dayligth hours
	 * Eq. (34)
	 *
	 * @param omega_s sunset hour angle [rad]
	 * @return daylight hours N
	 */
	public static double DaylightHours(double omega_s)
	{
		return 24/PI * omega_s;
	}

	/**
	 * Calculates Solar Radiation from sunshine hours
	 * Eq. (35)
	 *
	 * @param n actual duration of sunshine [h]
	 * @param N maximum possible duration of sunshine/daylight hours [h]
	 * @param R_a extraterrestrial radiation [MJ m-2 day-1]
	 * @param a_s regression constant,  expressing the fraction of extrater. rad. reaching the earth on overcast day n=0
	 * @param b_s regression slope, a_s+b_s is the fraction of extrater. rad. reaching the earth on clear days n=N
	 * @return solar or shortwave radiation R_s [MJ m-2 day-1]
	 */
	public static double SolarRadiation(double R_a, double n, double N, double a_s, double b_s)
	{
		return (a_s + n/N*b_s)*R_a;
	}

	/**
	 * Calculates the clear-sky solar radiation when values for a_s and b_s are available
	 * Eq. (36)
	 *
	 * @param R_a extraterrestrial radiation [MJ m-2 day-1]
	 * @param a_s regression constant,  expressing the fraction of extrater. rad. reaching the earth on overcast day n=0
	 * @param b_s regression slope, a_s+b_s is the fraction of extrater. rad. reaching the earth on clear days n=N
	 * @return Clear-sky solar radiation R_so when N=n [MJ m-2 day-1]
	 */
	public static double ClearSkyRadiationWithAngstromVariables(double R_a, double a_s, double b_s)
	{
		return (a_s + b_s)* R_a;
	}

	/**
	 * Calculates the clear-sky solar radiation when values for a_s and b_s are not available
	 * Eq. (37)
	 *
	 * @param R_a extraterrestrial radiation [MJ m-2 day-1]
	 * @param z elevation above sea level [m]
	 * @return Clear-sky solar radiation R_so when N=n [MJ m-2 day-1]
	 */
	public static double ClearSkyRadiation(double R_a, double z)
	{
		double sum_s_Default = a_s_Default + b_s_Default; // equals 0.75
		return (sum_s_Default + 2.0E-5*z)*R_a;
	}

	/**
	 * Net solar or net shortwave radiation
	 * Eq. (38)
	 *
	 * Calculates the amount of solar radiation that is not reflected.
	 *
	 * @param incoming solar radiation [MJ m-2 day-1]
	 * @param alpha albedo or canopy reflection coefficient []
	 * @return net shortwave radiation R_ns [MJ m-2 day-1]
	 */
	public static double NetShortwaveRadiation(double R_s, double alpha)
	{
		return (1-alpha)*R_s;
	}


	/**
	 * Net shortvawe radiation resulting from balance of incoming and reflected solar radiation
	 * Eq. (38)
	 *
	 * Calculates the amount of solar radiation that is not reflected.
	 * Albedo coefficient alpha is 0.23 for the hypothetical grass reference crop.
	 *
	 * @param R_s incoming solar radiation [MJ m-2 day-1]
	 * @return net solar or net shortwave radiation R_ns [MJ m-2 day-1]
	 */
	public static double NetSolarRadiation(double R_s)
	{
		return NetShortwaveRadiation(R_s, albedo);
	}

	/**
	 * Net longwave radiation
	 * Eq. (39)
	 *
	 * @param R_s solar or shortwave radiation [MJ m-2 day-1]
	 * @param R_so Clear-sky solar radiation when N=n [MJ m-2 day-1]
	 * @param e_a actual vapour pressure [kPa]
	 * @param T_max maximum of day temperature [°C]
	 * @param T_min minimum of day temperature [°C]
	 * @return net longwave radiation R_nl [MJ m-2 day-1]
	 */
	public static double NetLongwaveRadiation(double R_s, double R_so, double e_a, double T_max, double T_min)
	{
		final double T_absolute = 273.16;
		double T_maxK = T_max+T_absolute;
		double T_minK = T_min+T_absolute;

		double temps = (pow(T_maxK,4) + pow(T_minK,4))/2;

		double f = (R_so != 0.) ? R_s/R_so : 0; // TODO: check if it's reasonable to keep cloudreduction between 0 and 1
		double cloudreduction = min(max(0,1.35*f - 0.35),1); 
		return sigma * temps * (0.34 - 0.14*sqrt(e_a)) * cloudreduction;
	}

	/**
	 * Net longwave radiation
	 * Eq. (39) hourly
	 *
	 * @param R_s solar or shortwave radiation [MJ m-2 hour-1]
	 * @param R_so Clear-sky solar radiation when N=n [MJ m-2 hour-1]
	 * @param e_a actual vapour pressure [kPa]
	 * @param T temperature [°C]
	 * @return net longwave radiation R_nl [MJ m-2 hour-1]
	 */
	public static double NetLongwaveRadiationHourly(double R_s, double R_so, double e_a, double T)
	{
		final double T_absolute = 273.16;
		double T_K = T+T_absolute;

		double temps = pow(T_K,4);

		double f = (R_so != 0.) ? R_s/R_so : 0; // TODO: check if it's reasonable to keep cloudreduction between 0 and 1
		double cloudreduction = min(max(0,1.35*f - 0.35),1); 
		
		return sigma/24. * temps * (0.34 - 0.14*sqrt(e_a)) * cloudreduction;
	}


	/**
	 * Net radiation (difference between incoming shortwave and outgoing longwave radiation)
	 * Eq. (40)
	 *
	 * Remark: equation works also for hourly values.
	 * When R_ns and R_nl are in [MJ m-2 hour-1], the resulting
	 * net radiation R_n is also in [MJ m-2 hour-1]
	 *
	 * @param R_ns net solar radiation [MJ m-2 day-1]
	 * @param R_nl net longwave radiation [MJ m-2 day-1]
	 * @return net radiation R_n [MJ m-2 day-1]
	 */
	public static double NetRadiation(double R_ns, double R_nl)
	{
		return R_ns - R_nl;
	}

	/**
	 * Soil heat flux for hourly periods during daylight periods
	 * Eq. (45)
	 *
	 * @param R_n [MJ m-2 hour-1]
	 * @return hourly soil heat flux G_hr [MJ m-2 hour-1]
	 */
	public static double SoilHeatFluxHourlyDaylight(double R_n)
	{
	    return 0.1 * R_n;
	}

	/**
	 * Soil heat flux for hourly periods during nighttime periods
	 * Eq. (46)
	 *
	 * @param R_n [MJ m-2 hour-1]
	 * @return hourly soil heat flux G_hr [MJ m-2 hour-1]
	 */
	public static double SoilHeatFluxHourlyNighttime(double R_n)
	{
	    return 0.5 * R_n;
	}


	/**
	 * Soil heat flux for hourly periods
	 * Eq. (46)
	 * @param t center of the time interval
	 * @param daylen daylength
	 * @param R_n [MJ m-2 hour-1]
	 * @return hourly soil heat flux G_hr [MJ m-2 hour-1]
	 */
	public static double SoilHeatFluxHourly(double t, double daylen, double R_n)
	{
		double G = 0;
		double G_d = SoilHeatFluxHourlyDaylight(R_n);
		double G_n = SoilHeatFluxHourlyNighttime(R_n);
		double sunrise = 12 - daylen / 2.;
		double sunset = 12 + daylen / 2. ;

		if(t < sunrise - .5)
		{
			G = G_n;
		}
		if(sunrise -.5 <= t && t < sunrise + .5)
		{
			double a = sunrise +.5 - t;
			G = a * G_n + (1-a)*G_d;
		}
		else if(sunrise + .5 <= t && t < sunset - .5)
		{
			G = G_d;
		}
		else if (sunset -.5 <= t && t < sunset +.5)
		{
			double a = sunset + .5 - t;
			G = a * G_d + (1-a)*G_n;
		}
		else
		{
			G = G_n;
		}
		return G;
	}

	/**
	 * Estimates solar radiation by extraterrestrial radiation and temperature
	 * Eq. (50)
	 *
	 * @param R_a extraterrestrial radiation [MJ m-2 day-1]
	 * @param T_max maximum of day temperature [°C]
	 * @param T_min minimum of day temperature [°C]
	 * @param k_Rs adjustment coefficient between 0.16 (interior locations) and 0.19 (coastal locations) [°C-.5]
	 * @return solar radiation R_s [MJ m-2 day-1]
	 */
	public static double SolarRadiationFromExtraterrestrialRadiationAndTemp(double R_a,double T_max, double T_min, double k_Rs)
	{
		return k_Rs*sqrt(T_max - T_min)*R_a;
	}

	/**
	 * Estimates the reference evapo transpiration by extraterrestrial radiation and temperature
	 * Eq. (52)
	 *
	 * @param R_a extraterrestrial radiation (evaporation equivalent) [mm day-1]
	 * @param T_max maximum of day temperature [°C]
	 * @param T_min minimum of day temperature [°C]
	 * @return ET0 crop reference evapotranspiration ET0 [mm day-1]
	 */
	public static double ReferenceEvapoTranspirationByExtraterrestrialRadiation(double R_a, double T_max, double T_min)
	{
		double T_mean = (T_max + T_min) / 2;
		return 0.0023*(T_mean + 17.8)*sqrt(T_max - T_min)*R_a;
	}


	/**
	 * Estimates the reference evapotranspiration by solar radiation and temperature
	 * Eq. (52) & Eq. (50) with k_Rs=0.17
	 * see: Hargreaves, Allen, 2003, History and Evaluation of Hargreaves Evapotranspiration Equation: Eq. (3)
	 *
	 * @param R_s solar radiation (evaporation equivalent) [mm day-1]
	 * @param T_max maximum of day temperature [°C]
	 * @param T_min minimum of day temperature [°C]
	 * @return ET0 crop reference evapotranspiration ET0 [mm day-1]
	 */
	public static double ReferenceEvapoTranspirationFromSolarRadiation(double R_s, double T_max, double T_min)
	{
		double T_mean = (T_max + T_min) / 2;
		return 0.0135*(T_mean + 17.8)*R_s;
	}

	/**
	 * Calculates hourly reference evapotranspiration
	 * Eq. (53)
	 *
	 * @param R_n net radiation at the grass surface [MJ m-2 hour-1]
	 * @param G soil heat flux density [MJ m-2 hour-1]
	 * @param T_hr mean hourly air temperature [°C]
	 * @param Delta saturation slope vapour pressure curve at T_hr [kPa °C-1]
	 * @param gamma psychrometric constant [kPa °C-1]
	 * @param e_0 saturation vapour pressure at air temperature T_hr [kPa]
	 * @param e_a average hourly actual vapour pressure [kPa]
	 * @param u2 average hourly wind speed [m s-1]
	 * @return reference evapotranspiration ET_0 [mm h-1]
	 */
	public static double ReferenceEvapoTranspirationHourly(double R_n, double G, double T_hr, double Delta, double gamma, double e_0, double e_a, double u2)
	{
	    double T_abs = T_hr + 273.;
	    double nom1 = 0.408*Delta*(R_n-G);
	    double nom2 = gamma * (37/T_abs)*u2*(e_0 - e_a);
	    double denom = Delta + gamma*(1+0.34*u2);
	    double ET0 = (nom1+nom2)/denom;
	    return ET0;

	}

	/**
	 * Estimates hourly actual vapour pressure from hourly relative humidity
	 * Eq. (54)
	 *
	 * @param e_0
	 * @param RH_hr
	 * @return
	 */
	public static double ActualVapourPressureFromRelativeHumidityHourly(double e_0, double RH_hr)
	{
	    double e_a = e_0*RH_hr/100.;
	    return e_a;
	}


	/**
	 * Adjustment of coefficient in climates where RH_min differs from 45% or where u2 is larger or smaller than 2 m/s
	 * Eq. (62)
	 *
	 * Same formula is used to adjust
	 * K_cmid [Eq. (62)], K_cend [Eq. (65)], K_cb [Eq. (70)], K_cmax [Eq. (72)], K_cbfull [Eq. (99)]
	 *
	 * @param K_c
	 * @param u2
	 * @param RH_min
	 * @param h
	 * @return K_c adjusted coefficient
	 */
	public static double AdjustedKCoefficientToWindAndHumidity(double K_c, double u2, double RH_min, double h)
	{
		return K_c + (0.04*(u2-2) - 0.004*(RH_min - 45))*pow(h/3,0.3);
	}


	/**
	 * Upper limit on the evaporation and transpiration from any cropped surface
	 * Eq. (72)
	 *
	 * @param K_cb basal crop coefficient
	 * @param u2 mean value for daily wind speed at 2m height over grass during calculation period [m s-1]
	 * @param RH_min mean value for daily minimum relative humidity during calculation period [%]
	 * @param h mean maximum plant height during the period of calculation [m]
	 * @return K_cmax upper limit
	 */
	public static double UpperLimitKCoefficient(double K_cb, double u2, double RH_min, double h )
	{
		/* TODO: The "1.2" coefficient in Equation 72 represents effects of wetting intervals that are
		 * greater than 3 or 4 days. If irrigation or precipitation events are more frequent, for example
		 * daily or each two days, then the soil has less opportunity to absorb heat between wettings, and
		 * the "1.2" coefficient in Equation 72 can be reduced to about 1.1. The time step to compute K c
		 * max may vary from daily to monthly. (from FAO56, pg. 144)
		 */
		double tK = AdjustedKCoefficientToWindAndHumidity(1.2, u2, RH_min, h);
		return max(tK,K_cb+0.05);
	}

	/**
	 * Exposed and wetted soil fraction
	 * Eq. (75)
	 *
	 * @param f_c average fraction of soil covered (or shaded by vegetation)
	 * @param f_w average fraction of soil wetted by irrigation or precipitation
	 * @return f_ew exposed and wetted soil fraction
	 */
	public static double ExposedAndWettedSoilFraction(double f_c, double f_w)
	{
		return min(1-f_c, f_w);
	}

	/**
	 * Effective fraction of soil covered by vegetation
	 * Eq. (76)
	 *
	 * @param K_cb basal crop coefficient for particular day
	 * @param K_cmin minimum K_c for dry bare soil with no ground cover
	 * @param K_cmax maximum K_c immediately following wetting (Eq. 72)
	 * @param h mean plant height [m]
	 * @return f_c effective fraction of soil covered by vegetation
	 */
	public static double VegetationCoveredSoilFraction(double K_cb, double K_cmin,double K_cmax, double h)
	{
		return pow(max(K_cb - K_cmin,0.0)/(K_cmax - K_cmin), 1+0.5*h);
	}


	/**
	 * Estimated basal K_cb during the mid-season when plant density is lower than full cover
	 * Eq. (97)
	 *
	 * @param K_cmin minimum K_c for bare soil
	 * @param K_cbfull basal K_cb for for vegetation having full ground cover
	 * @param LAI actual leaf area index [m-2 m-2]
	 * @param k canopy light extinction factor
	 * @return Estimated basal K_cb during the mid-season when plant densitiy is lower than full cover
	 */
	public static double KCoefficientByLAI(double K_cmin, double K_cbfull, double LAI, double k)
	{
		return K_cmin + (K_cbfull - K_cmin)*(1- exp(-k*LAI));
	}

	
	/**
	 * Estimated basal K_cb during the mid-season when plant density is lower than full cover
	 * Eq. (97) - assumes a canopy light extiction factor of 0.7
	 *
	 * @param K_cmin minimum K_c for bare soil
	 * @param K_cbfull basal K_cb for for vegetation having full ground cover
	 * @param LAI actual leaf area index [m-2 m-2]
	 * @return Estimated basal K_cb during the mid-season when plant densitiy is lower than full cover
	 */
	public static double KCoefficientByLAI(double K_cmin, double K_cbfull, double LAI)
	{
		return KCoefficientByLAI(K_cmin, K_cbfull, LAI,  0.7);
	}

	
	
	/**
	 * Calculates the ETC-adjusted depletion fraction/factor p.
	 * Table 22, Footnote 2, and last paragraph of p. 162.
	 *
	 * Limited to 0.1 <= p <= 0.8
	 *
	 * @param nominalDepletion Unadjusted depletion fraction [-]
	 * @param ETC Crop evapotranspiration [mm/day]
	 * @return Adjusted p [-]
	 */
	public static double p( double nominalDepletion, double ETC ) {
		return max( 0.1, min(0.8, nominalDepletion + 0.04 * (5.00 - ETC)));
	}

	/**
	 * Calculates atmospheric density
	 * Eq. (3-5)
	 *
	 * @param T_Kv virtual temperature [K]
	 * @param P atmospheric pressure [kPa]
	 * @return rho atmospheric density [kg m-3]
	 */
	public static double AtmosphericDensity(double T_Kv, double P)
	{
		return 3.486 * P / T_Kv;
	}


	/**
	 * Calculates virtual temperature
	 * Eq. (3-6)
	 *
	 * @param T_k absolute temperature [K]
	 * @param e_a actual vapour pressure [kPa]
	 * @param P atmospheric pressure [kPa]
	 * @return T_Kv virtual temperature [K]
	 */
	public static double VirtualTemperature(double T_k, double e_a, double P)
	{
		return T_k / (1 - 0.378 * e_a / P);
	}

}
