using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace SiriusQualityReferenceETHargreaves_.DomainClass
{
    public interface IStrategySiriusQualityReferenceETHargreaves_ : IStrategy
    {
        void Estimate( ReferenceETHargreaves_State s, ReferenceETHargreaves_State s1, ReferenceETHargreaves_Rate r, ReferenceETHargreaves_Auxiliary a, ReferenceETHargreaves_Exogenous ex);

        string TestPreConditions( ReferenceETHargreaves_State s, ReferenceETHargreaves_State s1, ReferenceETHargreaves_Rate r, ReferenceETHargreaves_Auxiliary a, ReferenceETHargreaves_Exogenous ex, string callID);

        string TestPostConditions( ReferenceETHargreaves_State s, ReferenceETHargreaves_State s1, ReferenceETHargreaves_Rate r, ReferenceETHargreaves_Auxiliary a, ReferenceETHargreaves_Exogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}