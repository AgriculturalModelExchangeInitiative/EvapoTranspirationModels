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

package net.simplace.sim.components.evapotran.fao56;

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
 * Calculates reference evapotranspiration ET0 by Hargreaves method using solar radiation and temperature
 * 
 * WIKI_START
 * == Hargreaves 1975 == 
 * Uses the Hargreaves 1975 formula for ET0 calculation from temperature and solar radiation
 * WIKI_END
 * \(
 * ET0 = 0.0135 (MeanTemperature + 17.8)  SolarRadiationMM
 * \)
 * WIKI_START
 * 
 * Where 
 * 
 * WIKI_END
 * \(
 * SolarRadiationMM = 0.408 \cdot \text{iSolarRadiation} 
 * \)
 * WIKI_START 
 * 
 * is the solar radiation in mm/day, converted from  MJ/(m^2 d). For conversion the user can use 
 * the fixed factor 0.408 or - by setting `cConvertLeByTemp` to `true` - the latent heat of vaporisation as a function of daily mean temperature 
 * 1/(2.501-0.002361*Tmean).
 *  
 * == Notice: Hargreaves & Sarmani 1985 ==
 * 
 * The Hargreaves & Sarmani 1985 formula is
 * WIKI_END
 * \(
 *  ET0 = 0.0023(MeanTemperature + 17.8) \sqrt{MaxTemp - MinTemp} \cdot ExtraterrestrialRadiationMM
 * \)
 * WIKI_START 
 * 
 *  To use Hargreaves & Sarmani method, link the output `SolarRadiation` from the !SimComponent !SolarRadiationFromTemperature to the input `iSolarRadiation` of ReferenceETHargreaves.
 * 
 * 
 * == References == 
 * - Hargreaves G. H.  1975.  Moisture  availability  and  crop  production.  Transactions  of  the  American  Society  of  Agricultural  Engineers  18:980-984.
 * - Hargreaves G. H. and Z. A. Samani, 1985. Reference crop evapotranspiration from temperature. Appl. Eng. Agric. 1, 96-99.
 * WIKI_END
 * 
 * @author Gunther Krauss, gk@uni-bonn.de
 */
public class ReferenceETHargreaves extends FWSimComponent
{

	//constant
	private FWSimVariable<Boolean> cConvertLeByTemp;
	//input
	private FWSimVariable<Double> iTMax;
	private FWSimVariable<Double> iTMin;
	private FWSimVariable<Double> iSolarRadiation;

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
	private ReferenceETHargreaves(String aName, HashMap<String, FWSimVariable<?>> aFieldMap,
			HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
	{
		super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
	}

	/**
	 *  Empty constructor used by class.forName()
	 */
	public ReferenceETHargreaves()
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
		addVariable(FWSimVariable.createSimVariable("cConvertLeByTemp", "Use latent heat (Le) of vaporisation as a function of temperature to convert radiation from MJ/(m^2 day) to mm/day.", DATA_TYPE.BOOLEAN, CONTENT_TYPE.constant, "", null, null, false, this));
		//input
		addVariable(FWSimVariable.createSimVariable("iTMax", "maximum daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input, "http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius", null, null, 0.0, this));
		addVariable(FWSimVariable.createSimVariable("iTMin", "minimum daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input, "http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius", null, null, 0.0, this));
		addVariable(FWSimVariable.createSimVariable("iSolarRadiation", "solar radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input, "http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre_day", null, null, 0.0, this));

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
		
		double R_s_eveq = (cConvertLeByTemp.getValue()) 
				? EquationsFAO56.EvaporationEquivalentToRadiation(iSolarRadiation.getValue(),
						0.5*(iTMax.getValue()+iTMin.getValue()))
				: EquationsFAO56.EvaporationEquivalentToRadiation(iSolarRadiation.getValue());		
		ReferenceCropEvapotranspiration.setValue(max(0,EquationsFAO56.ReferenceEvapoTranspirationFromSolarRadiation(R_s_eveq, iTMax.getValue(), iTMin.getValue())), this);
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
		return new ReferenceETHargreaves(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
	}


}