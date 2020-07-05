using DAL.ModelsDal;

namespace DAL.Interfaces
{
    public interface IRepositoryDal
    {
        void DiscriminantCalculation(Equation equation);
        void CalculateRoots(Equation equation);
    }
}
