using FibiList.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FibiList.Infrastructure.Migrations
{
    public partial class PopulateUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO Units (Id, ShortDescriptor, SingularDescriptor, PluralDescriptor) VALUES ({(int)Units.gram}, 'g', 'gram', 'grams')");
            migrationBuilder.Sql($"INSERT INTO Units (Id, ShortDescriptor, SingularDescriptor, PluralDescriptor) VALUES ({(int)Units.kilogram}, 'kg', 'kilogram', 'kilograms')");
            migrationBuilder.Sql($"INSERT INTO Units (Id, ShortDescriptor, SingularDescriptor, PluralDescriptor) VALUES ({(int)Units.millilitre}, 'mL', 'millilitre', 'millilitres')");
            migrationBuilder.Sql($"INSERT INTO Units (Id, ShortDescriptor, SingularDescriptor, PluralDescriptor) VALUES ({(int)Units.litre}, 'L', 'litre', 'litres')");
            migrationBuilder.Sql($"INSERT INTO Units (Id, ShortDescriptor, SingularDescriptor, PluralDescriptor) VALUES ({(int)Units.teaspoon}, 'tsp', 'teaspoon', 'teaspoons')");
            migrationBuilder.Sql($"INSERT INTO Units (Id, ShortDescriptor, SingularDescriptor, PluralDescriptor) VALUES ({(int)Units.tablespoon}, 'tbsp', 'tablespoon', 'tablespoons')");
            migrationBuilder.Sql($"INSERT INTO Units (Id, ShortDescriptor, SingularDescriptor, PluralDescriptor) VALUES ({(int)Units.cup}, 'cup', 'cup', 'cups')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Units");
        }
    }
}
