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
 * ReferenceETHargreaves.java
 *
 * Responsible developers: Gunther Krauss, Crop Science Group, Katzenburgweg 5, 53115 Bonn, Germany
 *                         Andreas Enders, Crop Science Group, Katzenburgweg 5, 53115 Bonn, Germany
 * Contact Information:    lapit@uni-bonn.de
 * More information on <http://www.simplace.net>
 */

package net.simplace.sim.components.evapotran;

import static java.lang.StrictMath.*;

import java.util.HashMap;

import net.simplace.sim.components.util.helper.EquationsFAO56;
import net.simplace.sim.model.FWSimComponent;
import net.simplace.sim.util.FWSimVarMap;
import net.simplace.sim.util.FWSimVariable;
import net.simplace.sim.util.FWSimVariable.CONTENT_TYPE;
import net.simplace.sim.util.FWSimVariable.DATA_TYPE;

import org.jdom2.Element;


/**
 * Calculates reference evapotranspiration ET0 according to the 
 * Priestley-Taylor method, using solar radiation and temperature.
 * 
 * WIKI_START
 * == Priestley-Taylor (1972) == 
 * Uses the equation developed by Priestley and Taylor (1972) for ET0 calculation from temperature and solar radiation.
 * 
 * "The Priestley-Taylor equation was developed as a substitute to the Penman-Monteith equation to remove 
 * dependence on observations. For Priestley-Taylor, only radiation (irradiance) observations are required. 
 * This is done by removing the aerodynamic terms from the Penman-Monteith equation and adding an empirically 
 * derived constant factor, \alpha. (source: Wikipedia)
 * 
 * == References == 
 * Priestley, C.H.B., Taylor, R.J., 1972. On the Assessment of Surface Heat Flux and Evaporation Using Large-Scale Parameters. 
 *     Monthly Weather Review 100, 81-92. doi:10.1175/1520-0493(1972)100<0081:OTAOSH>2.3.CO;2
 *
 * WIKI_END
 * 
 * @author Heidi Webber
 * @author Roelof Oomen
 * 
 */
public class ReferenceETPriestleyTaylor extends FWSimComponent
{
	//constant
	private FWSimVariable<Double> cAltitude;
	private FWSimVariable<Double> cAlphaPT;
	
	//input
	private FWSimVariable<Double> iTMax;
	private FWSimVariable<Double> iTMin;
	private FWSimVariable<Double> iNetRadiation;

	//output
	private FWSimVariable<Double> ReferenceCropEvapotranspiration;

	//state
	// No states

	//rate
	// No rates

	/**
	 * @param aName
	 * @param aFieldMap
	 * @param aInputMap
	 * @param aSimComponentElement
	 * @param aVarMap 
	 */
	private ReferenceETPriestleyTaylor(String aName, HashMap<String, FWSimVariable<?>> aFieldMap,
			HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
	{
		super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
	}

	/**
	 *  Empty constructor used by class.forName()
	 */
	public ReferenceETPriestleyTaylor()
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
		addVariable(FWSimVariable.createSimVariable("cAltitude", "altitude", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant, 
				"http://www.wurvoc.org/vocabularies/om-1.8/metre", null, null, 0.0, this));
		addVariable(FWSimVariable.createSimVariable("cAlphaPT", "Priestley-Taylor coefficient", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant, 
				"http://www.wurvoc.org/vocabularies/om-1.8/one", 0.0, null, 1.26, this));
				
		//input
		addVariable(FWSimVariable.createSimVariable("iTMax", "maximum daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input, 
				"http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius", null, null, 0.0, this));
		addVariable(FWSimVariable.createSimVariable("iTMin", "minimum daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input, 
				"http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius", null, null, 0.0, this));
		addVariable(FWSimVariable.createSimVariable("iNetRadiation", "net radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input, 
				"http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day", null, null, 0.0, this));
		
		//output
		addVariable(FWSimVariable.createSimVariable("ReferenceCropEvapotranspiration", "reference evapotranspiration (ET0)", DATA_TYPE.DOUBLE, CONTENT_TYPE.out, 
				"http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day", null, null, 0.0, this));

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
		// nothing to do
	}

	/**
	 * Process the algorithm and write the results back to VarMap
	 * 
	 * @see net.simplace.sim.model.FWSimComponent#process()
	 */
	@Override
	protected void process()
	{
		final double lambdav = 2.45;
		double T = (iTMax.getValue() + iTMin.getValue())/2.0; // Average temperature
		double Delta = SlopeOfSaturationVapPressureCurve(T); //slope of saturation vapour pressure curve [kPa °C-1] Allen et al. (1998) Eq[13]
		double AtmPres = AtmosphericPressure(cAltitude.getValue()); // atmospheric pressure [kPa] Allen et al. (1998) Eq[7]
		double Gamma = PsychrometricConstant(AtmPres); //psychrometric constant [kPa °C-1] Allen et al. (1998) Eq[8]
		double G = 0.0; // Soil heat flux (Allen et al, 1998) [W m-2] Eq[45] and Eq[46] 	
		
		ReferenceCropEvapotranspiration.setValue( max(0, cAlphaPT.getValue() * Delta/(Delta + Gamma) * (iNetRadiation.getValue() - G)/lambdav ), this );
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
		final double lambdav = 2.45;
		final double c_p = 1.013E-3; // specific heat at constant pressure (for average atmospheric conditions) [MJ kg-1 °C-1]
		final double epsilon= 0.622; // ratio molecular weight of water vapour/dry air
		final double factor = Math.round(c_p/(epsilon*lambdav)*10E6)/10E6;
		return factor*P;
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
		return new ReferenceETPriestleyTaylor(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
	}

}
