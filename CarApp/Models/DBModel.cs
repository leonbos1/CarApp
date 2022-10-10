using System.Data.Entity;

namespace CarApp.Models
{
    public class DBModel
    {
    }

    public class EmpDBContext : DbContext
    {
        public EmpDBContext()
        {

        }
        public DbSet<CarViewModel> Cars { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
