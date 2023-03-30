using Microsoft.EntityFrameworkCore;

namespace Web_Api_Computer_Shop.Entities
{
    public class ComputerShopDBContext: DbContext
    {
        public ComputerShopDBContext()
        {
        }

        public ComputerShopDBContext(DbContextOptions<ComputerShopDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Feedback> Feeback { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<OrderSupplier> OrderSupplier { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<SubCategoryDetail> SubCategoryDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductOption> ProductOption { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }
        public virtual DbSet<HistoryLog> HistoryLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(b => b.Customer)
                .WithOne(i => i.Account)
                .HasForeignKey<Customer>(b => b.Account_Id);
            modelBuilder.Entity<Account>()
                .HasOne(b => b.Employee)
                .WithOne(i => i.Account)
                .HasForeignKey<Employee>(b => b.Account_Id);
        }


    }
}
