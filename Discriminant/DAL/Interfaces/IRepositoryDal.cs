using DAL.ModelsDal;

namespace DAL.Interfaces
{
    public interface IRepositoryDal
    {
        void SaveResults(Equation equation);
    }
}
