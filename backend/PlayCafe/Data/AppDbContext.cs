using PlayCafe.ViewModels.Cafe;
using PlayCafe.ViewModels.Login;
using PlayCafe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PlayCafe.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food", Description = "All food items including appetizers, desserts, and more" },
                new Category { Id = 2, Name = "Drinks", Description = "All drink items including hot drinks, juices, and more" },
                new Category { Id = 3, Name = "Extras", Description = "Add-ons and extras for food and beverages" }
            );

            // Seed SubCategories (linked to their respective parent categories)
            modelBuilder.Entity<SubCategory>().HasData(
                // Food subcategories
                new SubCategory { Id = 1, Name = "Appetizers", Description = "Tasty starters to enjoy before your meal", CategoryId = 1 },
                new SubCategory { Id = 2, Name = "Desserts", Description = "A variety of sweet treats and pastries", CategoryId = 1 },
                new SubCategory { Id = 3, Name = "Croissant", Description = "Freshly baked croissants", CategoryId = 1 },
                new SubCategory { Id = 4, Name = "Main Course", Description = "Main dishes including sandwiches, burgers, and more", CategoryId = 1 },
                new SubCategory { Id = 5, Name = "Salads", Description = "Healthy salads including vegetarian and non-vegetarian options", CategoryId = 1 },
                new SubCategory { Id = 6, Name = "Sides", Description = "Side dishes such as fries, rice, or bread", CategoryId = 1 },
                new SubCategory { Id = 7, Name = "Vegetarian", Description = "Vegetarian-friendly food options", CategoryId = 1 },
                new SubCategory { Id = 8, Name = "Vegan", Description = "Vegan food options", CategoryId = 1 },
                new SubCategory { Id = 9, Name = "Gluten-Free", Description = "Gluten-free food options", CategoryId = 1 },

                // Drinks subcategories
                new SubCategory { Id = 10, Name = "Hot Drinks", Description = "Coffee, tea, and other hot beverages", CategoryId = 2 },
                new SubCategory { Id = 11, Name = "Fresh Juices", Description = "Naturally squeezed fresh juices", CategoryId = 2 },
                new SubCategory { Id = 12, Name = "Soft Drinks", Description = "Non-alcoholic beverages", CategoryId = 2 },
                new SubCategory { Id = 13, Name = "Shots", Description = "Shot drinks and cocktails", CategoryId = 2 },
                new SubCategory { Id = 14, Name = "Tequila", Description = "Premium tequila selection", CategoryId = 2 },
                new SubCategory { Id = 15, Name = "Liqueurs", Description = "Various liqueurs", CategoryId = 2 },
                new SubCategory { Id = 16, Name = "Water", Description = "Still and sparkling water", CategoryId = 2 },
                new SubCategory { Id = 17, Name = "Smoothies", Description = "Blended drinks made from fruits and vegetables", CategoryId = 2 },
                new SubCategory { Id = 18, Name = "Beer", Description = "A selection of beers", CategoryId = 2 },
                new SubCategory { Id = 19, Name = "Wine", Description = "Various types of wines", CategoryId = 2 },
                new SubCategory { Id = 20, Name = "Cocktails", Description = "Mixed drinks and unique beverages", CategoryId = 2 },
                new SubCategory { Id = 21, Name = "Milkshakes", Description = "Mixed drinks and unique beverages", CategoryId = 2 },

                // Extras subcategories
                new SubCategory { Id = 22, Name = "Add-ons", Description = "Extras for beverages and food", CategoryId = 3 },
                new SubCategory { Id = 23, Name = "Condiments", Description = "Sauces, dips, and seasonings", CategoryId = 3 },
                new SubCategory { Id = 24, Name = "Sweeteners", Description = "Various sweeteners like sugar, honey, stevia", CategoryId = 3 },
                new SubCategory { Id = 25, Name = "Ice Cream Toppings", Description = "Toppings for ice cream like sprinkles, syrups, etc.", CategoryId = 3 }
            );


            modelBuilder.Entity<Product>().HasData(
                  new Product { Id = 1, Name = "Espresso", Description = "Strong brewed coffee", Price = 100M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599748959.689.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 2, Name = "Flavored Espresso", Description = "Espresso with flavor (hazelnut, chocolate, caramel, banana, coconut, almond)", Price = 120M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986218.833.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 3, Name = "Espresso Freddo", Description = "Chilled espresso", Price = 140M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599982240.442.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 4, Name = "Baileys Espresso", Description = "Espresso with Baileys Irish Cream", Price = 130M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986191.41.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 5, Name = "Small Macchiato", Description = "Small espresso with milk foam", Price = 120M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986262.623.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 6, Name = "Large Macchiato", Description = "Large espresso with milk foam", Price = 140M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986350.217.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 7, Name = "Flavored Macchiato", Description = "Macchiato with flavor (hazelnut, chocolate, caramel, banana, coconut, almond)", Price = 160M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599981983.377.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 8, Name = "Cappuccino", Description = "Espresso with steamed milk foam", Price = 150M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986403.502.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 9, Name = "Flavored Cappuccino", Description = "Cappuccino with flavor (hazelnut, chocolate, caramel, banana, coconut, almond)", Price = 170M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986419.988.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 10, Name = "Cappuccino Freddo", Description = "Chilled cappuccino", Price = 170M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599982253.047.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 11, Name = "Baileys Cappuccino", Description = "Cappuccino with Baileys Irish Cream", Price = 180M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986567.476.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 12, Name = "Nescafe", Description = "Instant coffee", Price = 150M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986622.472.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 13, Name = "Ice Coffee", Description = "Nescafe with ice cream", Price = 200M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986685.036.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 14, Name = "Latte", Description = "Coffee with steamed milk", Price = 150M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986749.039.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 15, Name = "Flavored Latte", Description = "Latte with syrup (espresso, milk, syrup)", Price = 170M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599982181.792.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 16, Name = "Cream Coffee", Description = "Coffee with cream", Price = 160M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599982216.374.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 17, Name = "Affogato", Description = "Espresso with gelato and chocolate sauce", Price = 190M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986817.099.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 18, Name = "Irish Coffee", Description = "Espresso with Irish whiskey and milk foam", Price = 220M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986909.025.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 19, Name = "Aspen Coffee", Description = "Baileys, Kahlua, hazelnut syrup, espresso and milk foam", Price = 220M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604074720.172.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  // Hot Drinks - Tea & Others (SubCategory 2)
                  new Product { Id = 22, Name = "Salep", Description = "Traditional hot drink", Price = 170M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1603471143.369.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 23, Name = "Hot Chocolate", Description = "Rich hot chocolate drink", Price = 170M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986998.265.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 24, Name = "Tea", Description = "Selection of premium teas", Price = 140M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599987035.06.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  new Product { Id = 25, Name = "Rum Tea", Description = "Tea with rum", Price = 180M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599987050.874.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 10 },
                  // Water Products (SubCategory 6 & 7)
                  new Product { Id = 26, Name = "Rosa 0.33L", Description = "Still water", Price = 80M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599987439.843.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 16 },
                  new Product { Id = 27, Name = "Gorska Still 0.25L", Description = "Still mineral water", Price = 80M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599987475.69.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 16 },
                  new Product { Id = 28, Name = "Gorska Sparkling 0.25L", Description = "Sparkling mineral water", Price = 90M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599987493.138.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 16 },
                 //Soft Drinks
                  new Product { Id = 29, Name = "Sprite", Description = "Soft drink", Price = 130M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075106.138.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 30, Name = "Coca Cola", Description = "Soft drink", Price = 130M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599987651.879.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 31, Name = "Fanta", Description = "Soft drink", Price = 130M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075306.334.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 32, Name = "Watermelon Juice", Description = "Fresh watermelon juice", Price = 150M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075361.788.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 33, Name = "Orange Juice", Description = "Freshly squeezed orange juice", Price = 160M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075410.808.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 34, Name = "Apple Juice", Description = "Fresh apple juice", Price = 160M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075456.084.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 35, Name = "Grape Juice", Description = "Fresh grape juice", Price = 170M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075502.059.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 36, Name = "Carrot Juice", Description = "Fresh carrot juice", Price = 180M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075545.62.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 37, Name = "Pineapple Juice", Description = "Fresh pineapple juice", Price = 190M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075588.962.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 38, Name = "Peach Juice", Description = "Fresh peach juice", Price = 190M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075632.62.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 39, Name = "Mango Juice", Description = "Fresh mango juice", Price = 200M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075685.587.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 40, Name = "Strawberry Juice", Description = "Fresh strawberry juice", Price = 210M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075727.692.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  //Smoothie
                  new Product { Id = 41, Name = "Banana Smoothie", Description = "Fresh banana smoothie", Price = 220M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075771.576.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 17 },
                  new Product { Id = 42, Name = "Berry Smoothie", Description = "Fresh berry smoothie", Price = 220M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075809.324.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 17 },
                  new Product { Id = 43, Name = "Avocado Smoothie", Description = "Fresh avocado smoothie", Price = 230M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075852.387.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 17 },
                  new Product { Id = 44, Name = "Coconut Smoothie", Description = "Fresh coconut smoothie", Price = 230M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075903.935.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 17 },
                  //Milkshake
                  new Product { Id = 45, Name = "Chocolate Milkshake", Description = "Chocolate milkshake with whipped cream", Price = 240M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075937.373.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 21 },
                  new Product { Id = 46, Name = "Vanilla Milkshake", Description = "Vanilla milkshake with whipped cream", Price = 240M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075982.251.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 21 },
                  new Product { Id = 47, Name = "Strawberry Milkshake", Description = "Strawberry milkshake with whipped cream", Price = 240M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076018.075.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 7 },
                  new Product { Id = 48, Name = "Caramel Milkshake", Description = "Caramel milkshake with whipped cream", Price = 250M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076062.604.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 7 },
                 
                  new Product { Id = 49, Name = "Lemonade", Description = "Fresh lemonade", Price = 170M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076102.035.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 50, Name = "Limeade", Description = "Fresh limeade", Price = 170M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076143.772.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 51, Name = "Fruit Punch", Description = "Fruit punch with mixed juices", Price = 180M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076180.075.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 52, Name = "Iced Tea", Description = "Fresh iced tea", Price = 160M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076215.472.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 53, Name = "Pineapple Lemonade", Description = "Pineapple lemonade", Price = 180M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076253.57.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 54, Name = "Coconut Lemonade", Description = "Coconut lemonade", Price = 180M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076290.357.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 },
                  new Product { Id = 55, Name = "Cucumber Lemonade", Description = "Cucumber lemonade", Price = 190M, ImageUrl = "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076345.347.png", IsAvailable = true, CreatedAt = DateTime.UtcNow, SubCategoryId = 12 }
            );
        }
    }
}
