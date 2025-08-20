namespace FoodMenuWebApplication.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<DishIngredients>? DishIngredients { get; set; }
}