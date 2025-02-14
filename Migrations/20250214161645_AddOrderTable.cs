using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace testMigration.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TABLE orders (
                id SERIAL PRIMARY KEY,
                user_id INT NOT NULL,
                total_amount DECIMAL(10,2) NOT NULL,
                status VARCHAR(50) NOT NULL DEFAULT 'pending',
                created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                CONSTRAINT fk_orders_users FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE
            );
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE orders;");
        }
    }
}
