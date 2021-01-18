using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class changedpizzamodelnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaModels_PizzaCrust_CrustEntityId",
                table: "PizzaModels");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaModels_PizzaSize_SizeEntityId",
                table: "PizzaModels");

            migrationBuilder.RenameColumn(
                name: "SizeEntityId",
                table: "PizzaModels",
                newName: "PizzaSizeEntityId");

            migrationBuilder.RenameColumn(
                name: "CrustEntityId",
                table: "PizzaModels",
                newName: "PizzaCrustEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PizzaModels_SizeEntityId",
                table: "PizzaModels",
                newName: "IX_PizzaModels_PizzaSizeEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PizzaModels_CrustEntityId",
                table: "PizzaModels",
                newName: "IX_PizzaModels_PizzaCrustEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaModels_PizzaCrust_PizzaCrustEntityId",
                table: "PizzaModels",
                column: "PizzaCrustEntityId",
                principalTable: "PizzaCrust",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaModels_PizzaSize_PizzaSizeEntityId",
                table: "PizzaModels",
                column: "PizzaSizeEntityId",
                principalTable: "PizzaSize",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaModels_PizzaCrust_PizzaCrustEntityId",
                table: "PizzaModels");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaModels_PizzaSize_PizzaSizeEntityId",
                table: "PizzaModels");

            migrationBuilder.RenameColumn(
                name: "PizzaSizeEntityId",
                table: "PizzaModels",
                newName: "SizeEntityId");

            migrationBuilder.RenameColumn(
                name: "PizzaCrustEntityId",
                table: "PizzaModels",
                newName: "CrustEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PizzaModels_PizzaSizeEntityId",
                table: "PizzaModels",
                newName: "IX_PizzaModels_SizeEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PizzaModels_PizzaCrustEntityId",
                table: "PizzaModels",
                newName: "IX_PizzaModels_CrustEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaModels_PizzaCrust_CrustEntityId",
                table: "PizzaModels",
                column: "CrustEntityId",
                principalTable: "PizzaCrust",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaModels_PizzaSize_SizeEntityId",
                table: "PizzaModels",
                column: "SizeEntityId",
                principalTable: "PizzaSize",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
