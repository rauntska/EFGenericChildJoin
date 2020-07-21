using Microsoft.EntityFrameworkCore;

namespace EFGenericChildJoin.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Customer> Customer{ get; set; }
        public DbSet<Contract> Contract{ get; set; }
        public DbSet<ResourceAttachment> ResourceAttachment{ get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            //SEED
            builder.Entity<Customer>().HasData(
                new {Id = 1, Name = "Customer1",  Country= "England" });
            builder.Entity<Customer>().HasData(
                new {Id = 2, Name = "Customer2",  Country= "England" });
            
            builder.Entity<Contract>().HasData(
                new {Id = 1, Name = "Contract1",  Country= "England" });
            builder.Entity<Contract>().HasData(
                new {Id = 2, Name = "Contract2",  Country= "England" });
            
            builder.Entity<ResourceAttachment>().HasData(
                new {Id = 1,ParentId=(long)1, ResourceType=nameof(Customer), AttachmentType = "type1",  Value= "Value1" });
            builder.Entity<ResourceAttachment>().HasData(
                new {Id = 2,ParentId=(long)1, ResourceType=nameof(Customer), AttachmentType = "type2",  Value= "Value1" });
            
            builder.Entity<ResourceAttachment>().HasData(
                new {Id = 3,ParentId=(long)1, ResourceType=nameof(Contract), AttachmentType = "contract-type2",  Value= "Value2" });
        }
    }
}