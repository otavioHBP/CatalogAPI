using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Nome,ImageUrl) Values ('Bebidas', 'bebidas.jpg')");
            mb.Sql("Insert into Categorias(Nome,ImageUrl) Values ('Lanches', 'lanches.jpg')");
            mb.Sql("Insert into Categorias(Nome,ImageUrl) Values ('Sobremesas', 'sobremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
        }
    }
}
