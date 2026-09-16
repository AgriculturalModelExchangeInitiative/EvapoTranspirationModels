using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace PotentialET_PT.DomainClass
{
    public interface IStrategyPotentialET_PT : IStrategy
    {
        void Estimate( PotentialET_PTState s, PotentialET_PTState s1, PotentialET_PTRate r, PotentialET_PTAuxiliary a, PotentialET_PTExogenous ex);

        string TestPreConditions( PotentialET_PTState s, PotentialET_PTState s1, PotentialET_PTRate r, PotentialET_PTAuxiliary a, PotentialET_PTExogenous ex, string callID);

        string TestPostConditions( PotentialET_PTState s, PotentialET_PTState s1, PotentialET_PTRate r, PotentialET_PTAuxiliary a, PotentialET_PTExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}