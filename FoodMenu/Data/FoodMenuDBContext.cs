using FoodMenu.Data.Entitie;
using Microsoft.EntityFrameworkCore;

namespace FoodMenu.Data
{
    public class FoodMenuDBContext : DbContext
    {
        public FoodMenuDBContext(DbContextOptions<FoodMenuDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });
            modelBuilder.Entity<DishIngredient>()
                .HasOne(d => d.Dish)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(di => di.DishId);
            modelBuilder.Entity<DishIngredient>()
                .HasOne(i => i.Ingredient)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(i => i.IngredientId);
            
            modelBuilder.Entity<DishTag>().HasKey(di => new
            {
                di.DishId,
                di.TagId
            });
            modelBuilder.Entity<DishTag>()
                .HasOne(d => d.Dish)
                .WithMany(di => di.DishTags)
                .HasForeignKey(di => di.DishId);
            modelBuilder.Entity<DishTag>()
                .HasOne(i => i.Tag)
                .WithMany(di => di.DishTags)
                .HasForeignKey(i => i.TagId);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set;}
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<DishTag> DishTags { get; set; }
        public virtual DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
