using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace EnergyBalanceComposite.DomainClass
{
    public interface IStrategyEnergyBalanceComposite : IStrategy
    {
        void Estimate( EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex);

        string TestPreConditions( EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex, string callID);

        string TestPostConditions( EnergyBalanceCompositeState s, EnergyBalanceCompositeState s1, EnergyBalanceCompositeRate r, EnergyBalanceCompositeAuxiliary a, EnergyBalanceCompositeExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}