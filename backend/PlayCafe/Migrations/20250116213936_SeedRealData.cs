using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlayCafe.Migrations
{
    /// <inheritdoc />
    public partial class SeedRealData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "All food items including appetizers, desserts, and more", "Food" },
                    { 2, "All drink items including hot drinks, juices, and more", "Drinks" },
                    { 3, "Add-ons and extras for food and beverages", "Extras" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Tasty starters to enjoy before your meal", "Appetizers" },
                    { 2, 1, "A variety of sweet treats and pastries", "Desserts" },
                    { 3, 1, "Freshly baked croissants", "Croissant" },
                    { 4, 1, "Main dishes including sandwiches, burgers, and more", "Main Course" },
                    { 5, 1, "Healthy salads including vegetarian and non-vegetarian options", "Salads" },
                    { 6, 1, "Side dishes such as fries, rice, or bread", "Sides" },
                    { 7, 1, "Vegetarian-friendly food options", "Vegetarian" },
                    { 8, 1, "Vegan food options", "Vegan" },
                    { 9, 1, "Gluten-free food options", "Gluten-Free" },
                    { 10, 2, "Coffee, tea, and other hot beverages", "Hot Drinks" },
                    { 11, 2, "Naturally squeezed fresh juices", "Fresh Juices" },
                    { 12, 2, "Non-alcoholic beverages", "Soft Drinks" },
                    { 13, 2, "Shot drinks and cocktails", "Shots" },
                    { 14, 2, "Premium tequila selection", "Tequila" },
                    { 15, 2, "Various liqueurs", "Liqueurs" },
                    { 16, 2, "Still and sparkling water", "Water" },
                    { 17, 2, "Blended drinks made from fruits and vegetables", "Smoothies" },
                    { 18, 2, "A selection of beers", "Beer" },
                    { 19, 2, "Various types of wines", "Wine" },
                    { 20, 2, "Mixed drinks and unique beverages", "Cocktails" },
                    { 21, 2, "Mixed drinks and unique beverages", "Milkshakes" },
                    { 22, 3, "Extras for beverages and food", "Add-ons" },
                    { 23, 3, "Sauces, dips, and seasonings", "Condiments" },
                    { 24, 3, "Various sweeteners like sugar, honey, stevia", "Sweeteners" },
                    { 25, 3, "Toppings for ice cream like sprinkles, syrups, etc.", "Ice Cream Toppings" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8771), "Strong brewed coffee", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599748959.689.png", true, "Espresso", 100m, 10 },
                    { 2, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8774), "Espresso with flavor (hazelnut, chocolate, caramel, banana, coconut, almond)", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986218.833.png", true, "Flavored Espresso", 120m, 10 },
                    { 3, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8776), "Chilled espresso", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599982240.442.png", true, "Espresso Freddo", 140m, 10 },
                    { 4, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8778), "Espresso with Baileys Irish Cream", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986191.41.png", true, "Baileys Espresso", 130m, 10 },
                    { 5, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8779), "Small espresso with milk foam", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986262.623.png", true, "Small Macchiato", 120m, 10 },
                    { 6, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8781), "Large espresso with milk foam", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986350.217.png", true, "Large Macchiato", 140m, 10 },
                    { 7, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8782), "Macchiato with flavor (hazelnut, chocolate, caramel, banana, coconut, almond)", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599981983.377.png", true, "Flavored Macchiato", 160m, 10 },
                    { 8, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8784), "Espresso with steamed milk foam", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986403.502.png", true, "Cappuccino", 150m, 10 },
                    { 9, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8786), "Cappuccino with flavor (hazelnut, chocolate, caramel, banana, coconut, almond)", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986419.988.png", true, "Flavored Cappuccino", 170m, 10 },
                    { 10, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8788), "Chilled cappuccino", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599982253.047.png", true, "Cappuccino Freddo", 170m, 10 },
                    { 11, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8789), "Cappuccino with Baileys Irish Cream", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986567.476.png", true, "Baileys Cappuccino", 180m, 10 },
                    { 12, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8791), "Instant coffee", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986622.472.png", true, "Nescafe", 150m, 10 },
                    { 13, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8793), "Nescafe with ice cream", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986685.036.png", true, "Ice Coffee", 200m, 10 },
                    { 14, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8795), "Coffee with steamed milk", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986749.039.png", true, "Latte", 150m, 10 },
                    { 15, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8797), "Latte with syrup (espresso, milk, syrup)", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599982181.792.png", true, "Flavored Latte", 170m, 10 },
                    { 16, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8798), "Coffee with cream", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599982216.374.png", true, "Cream Coffee", 160m, 10 },
                    { 17, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8800), "Espresso with gelato and chocolate sauce", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986817.099.png", true, "Affogato", 190m, 10 },
                    { 18, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8801), "Espresso with Irish whiskey and milk foam", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986909.025.png", true, "Irish Coffee", 220m, 10 },
                    { 19, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8803), "Baileys, Kahlua, hazelnut syrup, espresso and milk foam", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604074720.172.png", true, "Aspen Coffee", 220m, 10 },
                    { 22, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8805), "Traditional hot drink", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1603471143.369.png", true, "Salep", 170m, 10 },
                    { 23, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8806), "Rich hot chocolate drink", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599986998.265.png", true, "Hot Chocolate", 170m, 10 },
                    { 24, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8808), "Selection of premium teas", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599987035.06.png", true, "Tea", 140m, 10 },
                    { 25, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8809), "Tea with rum", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599987050.874.png", true, "Rum Tea", 180m, 10 },
                    { 26, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8811), "Still water", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599987439.843.png", true, "Rosa 0.33L", 80m, 16 },
                    { 27, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8813), "Still mineral water", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599987475.69.png", true, "Gorska Still 0.25L", 80m, 16 },
                    { 28, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8814), "Sparkling mineral water", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599987493.138.png", true, "Gorska Sparkling 0.25L", 90m, 16 },
                    { 29, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8817), "Soft drink", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075106.138.png", true, "Sprite", 130m, 12 },
                    { 30, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8819), "Soft drink", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1599987651.879.png", true, "Coca Cola", 130m, 12 },
                    { 31, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8820), "Soft drink", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075306.334.png", true, "Fanta", 130m, 12 },
                    { 32, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8822), "Fresh watermelon juice", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075361.788.png", true, "Watermelon Juice", 150m, 12 },
                    { 33, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8823), "Freshly squeezed orange juice", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075410.808.png", true, "Orange Juice", 160m, 12 },
                    { 34, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8825), "Fresh apple juice", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075456.084.png", true, "Apple Juice", 160m, 12 },
                    { 35, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8826), "Fresh grape juice", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075502.059.png", true, "Grape Juice", 170m, 12 },
                    { 36, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8828), "Fresh carrot juice", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075545.62.png", true, "Carrot Juice", 180m, 12 },
                    { 37, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8829), "Fresh pineapple juice", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075588.962.png", true, "Pineapple Juice", 190m, 12 },
                    { 38, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8831), "Fresh peach juice", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075632.62.png", true, "Peach Juice", 190m, 12 },
                    { 39, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8832), "Fresh mango juice", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075685.587.png", true, "Mango Juice", 200m, 12 },
                    { 40, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8834), "Fresh strawberry juice", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075727.692.png", true, "Strawberry Juice", 210m, 12 },
                    { 41, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8836), "Fresh banana smoothie", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075771.576.png", true, "Banana Smoothie", 220m, 17 },
                    { 42, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8838), "Fresh berry smoothie", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075809.324.png", true, "Berry Smoothie", 220m, 17 },
                    { 43, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8839), "Fresh avocado smoothie", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075852.387.png", true, "Avocado Smoothie", 230m, 17 },
                    { 44, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8841), "Fresh coconut smoothie", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075903.935.png", true, "Coconut Smoothie", 230m, 17 },
                    { 45, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8842), "Chocolate milkshake with whipped cream", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075937.373.png", true, "Chocolate Milkshake", 240m, 21 },
                    { 46, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8845), "Vanilla milkshake with whipped cream", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604075982.251.png", true, "Vanilla Milkshake", 240m, 21 },
                    { 47, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8846), "Strawberry milkshake with whipped cream", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076018.075.png", true, "Strawberry Milkshake", 240m, 7 },
                    { 48, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8848), "Caramel milkshake with whipped cream", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076062.604.png", true, "Caramel Milkshake", 250m, 7 },
                    { 49, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8850), "Fresh lemonade", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076102.035.png", true, "Lemonade", 170m, 7 },
                    { 50, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8851), "Fresh limeade", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076143.772.png", true, "Limeade", 170m, 7 },
                    { 51, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8853), "Fruit punch with mixed juices", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076180.075.png", true, "Fruit Punch", 180m, 7 },
                    { 52, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8854), "Fresh iced tea", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076215.472.png", true, "Iced Tea", 160m, 7 },
                    { 53, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8855), "Pineapple lemonade", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076253.57.png", true, "Pineapple Lemonade", 180m, 7 },
                    { 54, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8857), "Coconut lemonade", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076290.357.png", true, "Coconut Lemonade", 180m, 7 },
                    { 55, new DateTime(2025, 1, 16, 21, 39, 36, 128, DateTimeKind.Utc).AddTicks(8859), "Cucumber lemonade", "https://menu-images-bucket.s3.eu-central-1.amazonaws.com/test1604076345.347.png", true, "Cucumber Lemonade", 190m, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
