
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace ET.DomainClass
{
    public class ETState : ICloneable, IDomainClass
    {
        private double _surface_water_storage;
        private double _evaporated_from_surface;
        private double _actual_evaporation;
        private double _actual_transpiration;
        private double[] _soil_moisture;
        private double[] _evaporation;
        private double[] _transpiration;
        private double[] _evapotranspiration;
        private double _actual_evapotranspiration;
        private ParametersIO _parametersIO;

        public ETState()
        {
            _parametersIO = new ParametersIO(this);
        }

        public ETState(ETState toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                        surface_water_storage = toCopy.surface_water_storage;
                        evaporated_from_surface = toCopy.evaporated_from_surface;
                        actual_evaporation = toCopy.actual_evaporation;
                        actual_transpiration = toCopy.actual_transpiration;
                        soil_moisture = new double[toCopy.soil_moisture.Length];
        for (int i = 0; i < toCopy.soil_moisture.Length; i++)
            { soil_moisture[i] = toCopy.soil_moisture[i]; }
    
                        evaporation = new double[toCopy.evaporation.Length];
        for (int i = 0; i < toCopy.evaporation.Length; i++)
            { evaporation[i] = toCopy.evaporation[i]; }
    
                        transpiration = new double[toCopy.transpiration.Length];
        for (int i = 0; i < toCopy.transpiration.Length; i++)
            { transpiration[i] = toCopy.transpiration[i]; }
    
                        evapotranspiration = new double[toCopy.evapotranspiration.Length];
        for (int i = 0; i < toCopy.evapotranspiration.Length; i++)
            { evapotranspiration[i] = toCopy.evapotranspiration[i]; }
    
                        actual_evapotranspiration = toCopy.actual_evapotranspiration;
                    }
                }

                public double surface_water_storage
    {
        get { return this._surface_water_storage; }
        set { this._surface_water_storage= value; } 
    }
                public double evaporated_from_surface
    {
        get { return this._evaporated_from_surface; }
        set { this._evaporated_from_surface= value; } 
    }
                public double actual_evaporation
    {
        get { return this._actual_evaporation; }
        set { this._actual_evaporation= value; } 
    }
                public double actual_transpiration
    {
        get { return this._actual_transpiration; }
        set { this._actual_transpiration= value; } 
    }
                public double[] soil_moisture
    {
        get { return this._soil_moisture; }
        set { this._soil_moisture= value; } 
    }
                public double[] evaporation
    {
        get { return this._evaporation; }
        set { this._evaporation= value; } 
    }
                public double[] transpiration
    {
        get { return this._transpiration; }
        set { this._transpiration= value; } 
    }
                public double[] evapotranspiration
    {
        get { return this._evapotranspiration; }
        set { this._evapotranspiration= value; } 
    }
                public double actual_evapotranspiration
    {
        get { return this._actual_evapotranspiration; }
        set { this._actual_evapotranspiration= value; } 
    }

                public string Description
                {
                    get { return "ETState of the component";}
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
                     _surface_water_storage = default(double);
                     _evaporated_from_surface = default(double);
                     _actual_evaporation = default(double);
                     _actual_transpiration = default(double);
                     _soil_moisture = new double[no_of_soil_moisture_layers];
                     _evaporation = new double[no_of_soil_moisture_layers];
                     _transpiration = new double[no_of_soil_moisture_layers];
                     _evapotranspiration = new double[no_of_soil_moisture_layers];
                     _actual_evapotranspiration = default(double);
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