using BusinessLogic.ModelsBL;

namespace BusinessLogic.Interfaces
{
    public interface IRepositoryBl
    {
        double DiscriminantCalculate(EquationBl equationBl);
        EquationResultBl CalculateRoots(EquationBl equationBl, double discriminant);
    }
}
