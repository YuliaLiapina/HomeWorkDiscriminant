using DAL.ModelsDal;
using System.Data.Entity;

namespace DAL
{
    public class DiscriminantContext : DbContext
    {
        public DiscriminantContext() : base("DefaultConnection")
        {

        }

        public DbSet<Equation> Equations { get; set; }
    }
}
