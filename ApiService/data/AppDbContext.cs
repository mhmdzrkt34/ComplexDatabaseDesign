using ApiService.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiService.data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions options):base(options) { 
        
        
        }



        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Choice>().HasOne(i => i.previousOutput).WithMany(j => j.choices).HasForeignKey(k => k.previous_output_id).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Choice>().HasOne(i => i.nextOutput).WithOne(j => j.previousChoice).HasForeignKey<Choice>(k => k.next_output_id).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Output>().HasOne(i => i.NextOutput).WithOne().HasForeignKey<Output>(j => j.next_output_id).OnDelete(DeleteBehavior.NoAction) ;
            modelBuilder.Entity<Output>().HasOne(i => i.PreviousOutput).WithOne().HasForeignKey<Output>(j => j.previous_output_id).OnDelete(DeleteBehavior.NoAction);


        }

        public DbSet<Choice> choices { get; set; }


        public DbSet<Output> outputs { get; set; }




















    }
}
