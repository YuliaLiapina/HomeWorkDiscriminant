using DAL.Interfaces;
using DAL.ModelsDal;
using System.Data.Entity.Migrations;

namespace DAL
{
    public class DiscriminantRepository : IRepositoryDal
    {
        public void SaveResults(Equation equation)
        {
            using (var context = new DiscriminantContext())
            {
                context.Equations.AddOrUpdate(equation);

                context.SaveChanges();
            }
        }
    }
}
