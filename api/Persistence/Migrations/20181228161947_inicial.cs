using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FigureExchangeTotal = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Figure",
                columns: table => new
                {
                    FigureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Figure", x => x.FigureId);
                    table.ForeignKey(
                        name: "FK_Figure_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FigureUser",
                columns: table => new
                {
                    FigureUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FigureId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    UserOwnerId = table.Column<int>(nullable: false),
                    UserRequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FigureUser", x => x.FigureUserId);
                    table.ForeignKey(
                        name: "FK_FigureUser_Figure_FigureId",
                        column: x => x.FigureId,
                        principalTable: "Figure",
                        principalColumn: "FigureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FigureUser_Users_UserOwnerId",
                        column: x => x.UserOwnerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FigureUser_Users_UserRequestId",
                        column: x => x.UserRequestId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Figure_UserId",
                table: "Figure",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FigureUser_FigureId",
                table: "FigureUser",
                column: "FigureId");

            migrationBuilder.CreateIndex(
                name: "IX_FigureUser_UserOwnerId",
                table: "FigureUser",
                column: "UserOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FigureUser_UserRequestId",
                table: "FigureUser",
                column: "UserRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FigureUser");

            migrationBuilder.DropTable(
                name: "Figure");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
