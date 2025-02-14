using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace testMigration.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TABLE products (
                id SERIAL PRIMARY KEY,
                name VARCHAR(150) NOT NULL,
                description TEXT NULL,
                price DECIMAL(18,2) NOT NULL CHECK (price >= 0),
                stock_quantity INT NOT NULL CHECK (stock_quantity >= 0),
                created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
            );
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE IF EXISTS products;");
        }
    }
}
