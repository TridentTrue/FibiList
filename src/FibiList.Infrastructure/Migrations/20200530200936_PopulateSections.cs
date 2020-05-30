using FibiList.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FibiList.Infrastructure.Migrations
{
    public partial class PopulateSections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO Sections (Id, Name) VALUES ({(int)Sections.FruitAndVegetables}, 'Fruit and Vegetables')");
            migrationBuilder.Sql($"INSERT INTO Sections (Id, Name) VALUES ({(int)Sections.MeatAndFish}, 'Meat and Fish')");
            migrationBuilder.Sql($"INSERT INTO Sections (Id, Name) VALUES ({(int)Sections.Bakery}, 'Bakery')");
            migrationBuilder.Sql($"INSERT INTO Sections (Id, Name) VALUES ({(int)Sections.DairyEggsAndChilled}, 'Dairy, Eggs, and Chilled')");
            migrationBuilder.Sql($"INSERT INTO Sections (Id, Name) VALUES ({(int)Sections.Frozen}, 'Frozen')");
            migrationBuilder.Sql($"INSERT INTO Sections (Id, Name) VALUES ({(int)Sections.Baking}, 'Baking')");
            migrationBuilder.Sql($"INSERT INTO Sections (Id, Name) VALUES ({(int)Sections.JamsHoneyAndSpreads}, 'Jams, Honey, and Spreads')");
            migrationBuilder.Sql($"INSERT INTO Sections (Id, Name) VALUES ({(int)Sections.Cereals}, 'Cereals')");
            migrationBuilder.Sql($"INSERT INTO Sections (Id, Name) VALUES ({(int)Sections.CookingSaucesAndOils}, 'Cooking Sauces and Oils')");
            migrationBuilder.Sql($"INSERT INTO Sections (Id, Name) VALUES ({(int)Sections.RicePastaAndNoodles}, 'Rice, Pasta, and Noodles')");
            migrationBuilder.Sql($"INSERT INTO Sections (Id, Name) VALUES ({(int)Sections.CannedTinnedAndPackagedFoods}, 'Canned, Tinned, and Packaged Foods')");
            migrationBuilder.Sql($"INSERT INTO Sections (Id, Name) VALUES ({(int)Sections.Drinks}, 'Drinks')");
            migrationBuilder.Sql($"INSERT INTO Sections (Id, Name) VALUES ({(int)Sections.Snacks}, 'Snacks')");
            migrationBuilder.Sql($"INSERT INTO Sections (Id, Name) VALUES ({(int)Sections.HerbsAndSpices}, 'Herbs and Spices')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Sections");
        }
    }
}
