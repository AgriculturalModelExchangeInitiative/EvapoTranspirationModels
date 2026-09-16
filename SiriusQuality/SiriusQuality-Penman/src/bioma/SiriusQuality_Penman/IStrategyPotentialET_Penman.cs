using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace PotentialET_Penman.DomainClass
{
    public interface IStrategyPotentialET_Penman : IStrategy
    {
        void Estimate( PotentialET_PenmanState s, PotentialET_PenmanState s1, PotentialET_PenmanRate r, PotentialET_PenmanAuxiliary a, PotentialET_PenmanExogenous ex);

        string TestPreConditions( PotentialET_PenmanState s, PotentialET_PenmanState s1, PotentialET_PenmanRate r, PotentialET_PenmanAuxiliary a, PotentialET_PenmanExogenous ex, string callID);

        string TestPostConditions( PotentialET_PenmanState s, PotentialET_PenmanState s1, PotentialET_PenmanRate r, PotentialET_PenmanAuxiliary a, PotentialET_PenmanExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}