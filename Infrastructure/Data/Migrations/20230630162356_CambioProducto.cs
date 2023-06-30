using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CambioProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductoValido",
                schema: "Viaticos",
                table: "ProductoValido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogoProducto",
                schema: "Viaticos",
                table: "CatalogoProducto");

            migrationBuilder.RenameTable(
                name: "ProductoValido",
                schema: "Viaticos",
                newName: "ProductoOServicio",
                newSchema: "Viaticos");

            migrationBuilder.RenameTable(
                name: "CatalogoProducto",
                schema: "Viaticos",
                newName: "CatalogoProdServ",
                newSchema: "Viaticos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductoOServicio",
                schema: "Viaticos",
                table: "ProductoOServicio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogoProdServ",
                schema: "Viaticos",
                table: "CatalogoProdServ",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductoOServicio",
                schema: "Viaticos",
                table: "ProductoOServicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogoProdServ",
                schema: "Viaticos",
                table: "CatalogoProdServ");

            migrationBuilder.RenameTable(
                name: "ProductoOServicio",
                schema: "Viaticos",
                newName: "ProductoValido",
                newSchema: "Viaticos");

            migrationBuilder.RenameTable(
                name: "CatalogoProdServ",
                schema: "Viaticos",
                newName: "CatalogoProducto",
                newSchema: "Viaticos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductoValido",
                schema: "Viaticos",
                table: "ProductoValido",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogoProducto",
                schema: "Viaticos",
                table: "CatalogoProducto",
                column: "Id");
        }
    }
}
