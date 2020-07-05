using BusinessLogic.ModelsBL;

namespace BusinessLogic.Interfaces
{
    public interface IRepositoryBl
    {
        double DiscriminantCalculate(EquationBl equationBl);
        GetRootsResult CalculateRoots(EquationBl equationBl);
    }
}
