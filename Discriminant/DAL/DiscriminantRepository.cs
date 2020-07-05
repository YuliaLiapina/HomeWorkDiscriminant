using DAL.Interfaces;
using DAL.ModelsDal;
using System.Data.Entity.Migrations;

namespace DAL
{
    public class DiscriminantRepository : IRepositoryDal
    {
        public void DiscriminantCalculation(Equation equation)
        {
            using (var context = new DiscriminantContext())
            {
                context.Equations.Add(equation);

                context.SaveChanges();
            }
        }

        public void CalculateRoots(Equation equation)
        {
            using (var context = new DiscriminantContext())
            {
                context.Equations.AddOrUpdate(equation);

                context.SaveChanges();
            }
        }
    }
}
