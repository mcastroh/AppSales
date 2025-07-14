using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.API.Migrations
{
    /// <inheritdoc />
    public partial class Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsActivo",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Categorias");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Categorias",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "Categorias",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Categorias_Descripcion",
                table: "Categorias",
                newName: "IX_Categorias_Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categorias",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categorias",
                newName: "IdCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_Categorias_Name",
                table: "Categorias",
                newName: "IX_Categorias_Descripcion");

            migrationBuilder.AddColumn<bool>(
                name: "EsActivo",
                table: "Categorias",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Categorias",
                type: "datetime2",
                nullable: true);
        }
    }
}
