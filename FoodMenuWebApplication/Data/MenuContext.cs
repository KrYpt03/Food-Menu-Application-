using FoodMenuWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using FoodMenuWebApplication.Models;

namespace FoodMenuWebApplication.Data;

public class MenuContext : DbContext
{
    public MenuContext(DbContextOptions<MenuContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DishIngredients>()
            .HasKey(di => new 
            {
                di.DishId,
                di.IngredientId
            });
        modelBuilder.Entity<DishIngredients>().HasOne(d =>d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
        modelBuilder.Entity<DishIngredients>().HasOne(i =>i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientId);
        modelBuilder.Entity<Dish>().HasData(
            new Dish { Id = 1, Name = "Spaghetti Bolognese", ImageUrl = "https://supervalu.ie/thumbnail/800x600/var/files/real-food/recipes/Uploaded-2020/spaghetti-bolognese-recipe.jpg", Price = 12.99 }
        );
        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient {Id = 1, Name = "Tomato Sauce"},
            new Ingredient {Id = 2, Name = "Spaghetti"}
            );
        modelBuilder.Entity<DishIngredients>().HasData(
            new DishIngredients { DishId = 1, IngredientId = 1 },
            new DishIngredients { DishId = 1, IngredientId = 2 }
        );
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<DishIngredients> DishIngredients { get; set; }
}