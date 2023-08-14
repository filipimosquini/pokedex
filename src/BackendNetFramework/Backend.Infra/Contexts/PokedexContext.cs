using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Backend.Infra.Contexts
{
    public class PokedexContext : DbContext
    {
        public PokedexContext() : base(nameof(PokedexContext)) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(PokedexContext).Assembly);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}