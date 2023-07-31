using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmegaGymServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SubscriptionCategories_SubscriptionCategoryId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_SubscriptionCategoryId",
                table: "Subscriptions");

            migrationBuilder.AddColumn<Guid>(
                name: "SubscriptionId",
                table: "SubscriptionCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionCategories_SubscriptionId",
                table: "SubscriptionCategories",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionCategories_Subscriptions_SubscriptionId",
                table: "SubscriptionCategories",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionCategories_Subscriptions_SubscriptionId",
                table: "SubscriptionCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionCategories_SubscriptionId",
                table: "SubscriptionCategories");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "SubscriptionCategories");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriptionCategoryId",
                table: "Subscriptions",
                column: "SubscriptionCategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SubscriptionCategories_SubscriptionCategoryId",
                table: "Subscriptions",
                column: "SubscriptionCategoryId",
                principalTable: "SubscriptionCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
