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
 * ReferenceETPM.java
 *
 * Responsible developers: Gunther Krauss, Crop Science Group, Katzenburgweg 5, 53115 Bonn, Germany
 *                         Andreas Enders, Crop Science Group, Katzenburgweg 5, 53115 Bonn, Germany
 * Contact Information:    lapit@uni-bonn.de
 * More information on <http://www.simplace.net>
 */

package net.simplace.sim.components.evapotran.fao56;

import java.util.HashMap;

import net.simplace.sim.components.util.helper.EquationsFAO56;
import net.simplace.sim.model.FWSimComponent;
import net.simplace.sim.util.FWSimVarMap;
import net.simplace.sim.util.FWSimVariable;
import net.simplace.sim.util.FWSimVariable.CONTENT_TYPE;
import net.simplace.sim.util.FWSimVariable.DATA_TYPE;

import org.jdom2.Element;


/**
 * Calculates reference evapotranspiration ET0 by Penman-Monteith with the FAO56 approach.
 *
 * WIKI_START
 * FAO Penman-Monteith equation determines the evapotranspiration from the hypothetical
 * grass reference surface. (FAO 56)
 *
 * Uses daily max/min temperature, actual vapour pressure, net radiation and wind speed.
 * Checks for valid actual vapour pressure values.
 *
 * For documentation of the formulas please check the orginal reference (FAO 56)
 *
 * == References ==
 * [http://www.fao.org/docrep/x0490e/x0490e00.htm (FAO 56): Allen, Crop evapotranspiration - Guidelines for computing crop water requirements - FAO Irrigation and drainage paper 56, 1998]
 *
 * WIKI_END
 *
 * @author Gunther Krauss, gk@uni-bonn.de
 */
public class ReferenceETPM extends FWSimComponent
{
	//constant
	private FWSimVariable<Double> cAltitude;


	//input
	private FWSimVariable<Double> iTMax;
	private FWSimVariable<Double> iTMin;
	private FWSimVariable<Double> iActualVapourPressure;
	private FWSimVariable<Double> iNetRadiation;
	private FWSimVariable<Double> iWindspeed;


	//output
	private FWSimVariable<Double> ReferenceCropEvapotranspiration;


	//state


	//rate


	/**
	 * @param aName
	 * @param aFieldMap
	 * @param aInputMap
	 * @param aSimComponentElement
	 * @param aVarMap
	 */
	private ReferenceETPM(String aName, HashMap<String, FWSimVariable<?>> aFieldMap,
			HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
	{
		super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
	}

	/**
	 *  Empty constructor used by class.forName()
	 */
	public ReferenceETPM()
	{
		super();
	}

	/**
	 *
	 * Create the FWSimVariables as interface for this SimComponent
	 *
	 * @see net.simplace.sim.model.FWSimComponent#createVariables()
	 */
	@Override
	public HashMap<String, FWSimVariable<?>> createVariables()
	{
		//constant
		addVariable(FWSimVariable.createSimVariable("cAltitude", "elevation above sea level", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant, "http://www.wurvoc.org/vocabularies/om-1.8/metre", null, null, 0.0, this));

		//input
		addVariable(FWSimVariable.createSimVariable("iTMax", "maximum daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input, "http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius", null, null, 0.0, this));
		addVariable(FWSimVariable.createSimVariable("iTMin", "minimum daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input, "http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius", null, null, 0.0, this));
		addVariable(FWSimVariable.createSimVariable("iActualVapourPressure", "actual vapour pressure", DATA_TYPE.DOUBLE, CONTENT_TYPE.input, "http://www.wurvoc.org/vocabularies/om-1.8/kilopascal", null, null, 0.0, this));
		addVariable(FWSimVariable.createSimVariable("iNetRadiation", "net radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input, "http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day", null, null, 0.0, this));
		addVariable(FWSimVariable.createSimVariable("iWindspeed", "wind speed at 2m height", DATA_TYPE.DOUBLE, CONTENT_TYPE.input, "http://www.wurvoc.org/vocabularies/om-1.8/metre_per_second-time", null, null, 0.0, this));

		//output
		addVariable(FWSimVariable.createSimVariable("ReferenceCropEvapotranspiration", "reference evapotranspiration (ET0)", DATA_TYPE.DOUBLE, CONTENT_TYPE.out, "http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day", null, null, 0.0, this));

		return iFieldMap;
	}

	/**
	 * Initializes the fields by getting input and output FWSimVariables from VarMap
	 *
	 * @see net.simplace.sim.model.FWSimComponent#init()
	 */
	@Override
	protected void init()
	{
	}

	/**
	 * Process the algorithm and write the results back to VarMap
	 *
	 * @see net.simplace.sim.model.FWSimComponent#process()
	 */
	@Override
	protected void process()
	{
		double z = cAltitude.getValue();

		double T = (iTMax.getValue() + iTMin.getValue())/2;

		double R_n = iNetRadiation.getValue();
		double u_2 = iWindspeed.getValue();

		double e_a = iActualVapourPressure.getValue();

		double e_s;
		e_s = MeanSaturatedVapourPressure(iTMax.getValue(), iTMin.getValue());
		if(e_a > e_s)
		{
			//checkCondition(true, "Actual vapour pressure e_a:"+e_a+" is bigger than mean saturated vapour pressure e_s:"+e_s+". Setting e_a to e_s.");
			e_a = e_s;
		}

		ReferenceCropEvapotranspiration.setValue(ReferenceEvapotranspiration(T, R_n, u_2, e_s, e_a, z), this);
	}


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

	public static double PsychrometricConstant(double P)
	
	{
		final double lambdav = 2.45;
		final double c_p = 1.013E-3; // specific heat at constant pressure (for average atmospheric conditions) [MJ kg-1 °C-1]
		final double epsilon= 0.622; // ratio molecular weight of water vapour/dry air
		final double factor = Math.round(c_p/(epsilon*lambdav)*10E6)/10E6;
		return factor*P;
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
		return  4098*(0.6108*Math.exp(17.27*T/(tempT)))/Math.pow(tempT,2);
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
			return 101.3*Math.pow((293-0.0065*z)/293,5.26);
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
	 * Saturation vapour pressure at air temperature T
	 * Eq. (11)
	 *
	 * @param T air temperature [°C]
	 * @return vapour pressure e_0_T [kPa]
	 */
	public static double SaturationVapourPressureAtTemperature(double T)
	{
		return 0.6108 * Math.exp(17.27 * T / (T+237.3));
	}


	/**
	 * called for single component test to check the components algorithm. 
	 *
	 * @see net.simplace.sim.util.FWSimFieldContainer#fillTestVariables(int aParamIndex, TEST_STATE aDefineOrCheck)
	 */
	@Override
	public HashMap<String, FWSimVariable<?>> fillTestVariables(int aParamIndex, TEST_STATE aDefineOrCheck)
	{
		return iFieldMap;
	}
	
	/**

	 *
	 * @see net.simplace.sim.model.FWSimComponent#clone(net.simplace.sim.util.FWSimVarMap)
	 */
	@Override
	protected FWSimComponent clone(FWSimVarMap aVarMap)
	{
		return new ReferenceETPM(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
	}


}