public class PetComponent
{
    
    public PetComponent() { }

    PotentialEvapotranspiration _PotentialEvapotranspiration = new PotentialEvapotranspiration();

    public double getket()
    { return _PotentialEvapotranspiration.getket(); }
    public void setket(double _ket){
    _PotentialEvapotranspiration.setket(_ket);
    }

    public double getcalb()
    { return _PotentialEvapotranspiration.getcalb(); }
    public void setcalb(double _calb){
    _PotentialEvapotranspiration.setcalb(_calb);
    }

    public double getsalb()
    { return _PotentialEvapotranspiration.getsalb(); }
    public void setsalb(double _salb){
    _PotentialEvapotranspiration.setsalb(_salb);
    }
    public void  Calculate_Model(petState s, petState s1, petRate r, petAuxiliary a, petExogenous ex)
    {
        _PotentialEvapotranspiration.Calculate_Model(s, s1, r, a, ex);
    }
    private double ket;
    private double calb;
    private double salb;
    public petComponent(petComponent toCopy) // copy constructor 
    {
        this.ket = toCopy.getket();
        this.calb = toCopy.getcalb();
        this.salb = toCopy.getsalb();

    }
}