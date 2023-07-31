using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmegaGymServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_UserSubscriptions_UserSubscriptionId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_UserSubscriptionId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "UserSubscriptionId",
                table: "Subscriptions");

            migrationBuilder.CreateTable(
                name: "SubscriptionUserSubscription",
                columns: table => new
                {
                    SubscriptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserSubscriptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionUserSubscription", x => new { x.SubscriptionsId, x.UserSubscriptionsId });
                    table.ForeignKey(
                        name: "FK_SubscriptionUserSubscription_Subscriptions_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionUserSubscription_UserSubscriptions_UserSubscriptionsId",
                        column: x => x.UserSubscriptionsId,
                        principalTable: "UserSubscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionUserSubscription_UserSubscriptionsId",
                table: "SubscriptionUserSubscription",
                column: "UserSubscriptionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionUserSubscription");

            migrationBuilder.AddColumn<Guid>(
                name: "UserSubscriptionId",
                table: "Subscriptions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserSubscriptionId",
                table: "Subscriptions",
                column: "UserSubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_UserSubscriptions_UserSubscriptionId",
                table: "Subscriptions",
                column: "UserSubscriptionId",
                principalTable: "UserSubscriptions",
                principalColumn: "Id");
        }
    }
}
