using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace ReferenceETPriestleyTaylor_.DomainClass
{
    public interface IStrategyReferenceETPriestleyTaylor_ : IStrategy
    {
        void Estimate( ReferenceETPriestleyTaylor_State s, ReferenceETPriestleyTaylor_State s1, ReferenceETPriestleyTaylor_Rate r, ReferenceETPriestleyTaylor_Auxiliary a, ReferenceETPriestleyTaylor_Exogenous ex);

        string TestPreConditions( ReferenceETPriestleyTaylor_State s, ReferenceETPriestleyTaylor_State s1, ReferenceETPriestleyTaylor_Rate r, ReferenceETPriestleyTaylor_Auxiliary a, ReferenceETPriestleyTaylor_Exogenous ex, string callID);

        string TestPostConditions( ReferenceETPriestleyTaylor_State s, ReferenceETPriestleyTaylor_State s1, ReferenceETPriestleyTaylor_Rate r, ReferenceETPriestleyTaylor_Auxiliary a, ReferenceETPriestleyTaylor_Exogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}