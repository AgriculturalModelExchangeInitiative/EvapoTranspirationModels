
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace EnergyBalanceComposite.DomainClass
                {
                    public class EnergyBalanceCompositeAuxiliary : ICloneable, IDomainClass
                    {
                        private double _maxTair;
                        private double _minTair;
                        private double _vaporPressure;
                        private double _extraSolarRadiation;
                        private double _solarRadiation;
                        private double _plantHeight;
                        private double _wind;
                        private double _hslope;
                        private double _VPDair;
                        private double _netOutGoingLongWaveRadiation;
                        private double _netRadiation;
                        private double _netRadiationEquivalentEvaporation;
                        private ParametersIO _parametersIO;

                        public EnergyBalanceCompositeAuxiliary()
                        {
                            _parametersIO = new ParametersIO(this);
                        }

                        public EnergyBalanceCompositeAuxiliary(EnergyBalanceCompositeAuxiliary toCopy, bool copyAll) // copy constructor 
                        {
                            if (copyAll)
                            {
                                        maxTair = toCopy.maxTair;
                                        minTair = toCopy.minTair;
                                        vaporPressure = toCopy.vaporPressure;
                                        extraSolarRadiation = toCopy.extraSolarRadiation;
                                        solarRadiation = toCopy.solarRadiation;
                                        plantHeight = toCopy.plantHeight;
                                        wind = toCopy.wind;
                                        hslope = toCopy.hslope;
                                        VPDair = toCopy.VPDair;
                                        netOutGoingLongWaveRadiation = toCopy.netOutGoingLongWaveRadiation;
                                        netRadiation = toCopy.netRadiation;
                                        netRadiationEquivalentEvaporation = toCopy.netRadiationEquivalentEvaporation;
                                    }
                                }

                                public double maxTair
    {
        get { return this._maxTair; }
        set { this._maxTair= value; } 
    }
                                public double minTair
    {
        get { return this._minTair; }
        set { this._minTair= value; } 
    }
                                public double vaporPressure
    {
        get { return this._vaporPressure; }
        set { this._vaporPressure= value; } 
    }
                                public double extraSolarRadiation
    {
        get { return this._extraSolarRadiation; }
        set { this._extraSolarRadiation= value; } 
    }
                                public double solarRadiation
    {
        get { return this._solarRadiation; }
        set { this._solarRadiation= value; } 
    }
                                public double plantHeight
    {
        get { return this._plantHeight; }
        set { this._plantHeight= value; } 
    }
                                public double wind
    {
        get { return this._wind; }
        set { this._wind= value; } 
    }
                                public double hslope
    {
        get { return this._hslope; }
        set { this._hslope= value; } 
    }
                                public double VPDair
    {
        get { return this._VPDair; }
        set { this._VPDair= value; } 
    }
                                public double netOutGoingLongWaveRadiation
    {
        get { return this._netOutGoingLongWaveRadiation; }
        set { this._netOutGoingLongWaveRadiation= value; } 
    }
                                public double netRadiation
    {
        get { return this._netRadiation; }
        set { this._netRadiation= value; } 
    }
                                public double netRadiationEquivalentEvaporation
    {
        get { return this._netRadiationEquivalentEvaporation; }
        set { this._netRadiationEquivalentEvaporation= value; } 
    }

                                public string Description
                                {
                                    get { return "EnergyBalanceCompositeAuxiliary of the component";}
                                }

                                public string URL
                                {
                                    get { return "http://" ;}
                                }

                                public virtual IDictionary<string, PropertyInfo> PropertiesDescription
                                {
                                    get { return _parametersIO.GetCachedProperties(typeof(IDomainClass));}
                                }

                                public virtual Boolean ClearValues()
                                {
                                     _maxTair = default(double);
                                     _minTair = default(double);
                                     _vaporPressure = default(double);
                                     _extraSolarRadiation = default(double);
                                     _solarRadiation = default(double);
                                     _plantHeight = default(double);
                                     _wind = default(double);
                                     _hslope = default(double);
                                     _VPDair = default(double);
                                     _netOutGoingLongWaveRadiation = default(double);
                                     _netRadiation = default(double);
                                     _netRadiationEquivalentEvaporation = default(double);
                                    return true;
                                }

                                public virtual Object Clone()
                                {
                                    IDomainClass myclass = (IDomainClass) this.MemberwiseClone();
                                    _parametersIO.PopulateClonedCopy(myclass);
                                    return myclass;
                                }
                            }
                        }