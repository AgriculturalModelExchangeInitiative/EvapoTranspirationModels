using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace ReferenceETPM_.DomainClass
{
    public interface IStrategyReferenceETPM_ : IStrategy
    {
        void Estimate( ReferenceETPM_State s, ReferenceETPM_State s1, ReferenceETPM_Rate r, ReferenceETPM_Auxiliary a, ReferenceETPM_Exogenous ex);

        string TestPreConditions( ReferenceETPM_State s, ReferenceETPM_State s1, ReferenceETPM_Rate r, ReferenceETPM_Auxiliary a, ReferenceETPM_Exogenous ex, string callID);

        string TestPostConditions( ReferenceETPM_State s, ReferenceETPM_State s1, ReferenceETPM_Rate r, ReferenceETPM_Auxiliary a, ReferenceETPM_Exogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}