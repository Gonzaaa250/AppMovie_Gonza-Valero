using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMovie.Migrations
{
    public partial class ultimaprueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Return",
                columns: table => new
                {
                    ReturnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Return", x => x.ReturnID);
                    table.ForeignKey(
                        name: "FK_Return_Partner_PartnerID",
                        column: x => x.PartnerID,
                        principalTable: "Partner",
                        principalColumn: "PartnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturndetailTemp",
                columns: table => new
                {
                    ReturndetailTempID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturndetailTemp", x => x.ReturndetailTempID);
                });

            migrationBuilder.CreateTable(
                name: "ReturnlDetail",
                columns: table => new
                {
                    ReturnDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnID = table.Column<int>(type: "int", nullable: false),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnlDetail", x => x.ReturnDetailID);
                    table.ForeignKey(
                        name: "FK_ReturnlDetail_Movie_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movie",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnlDetail_Return_ReturnID",
                        column: x => x.ReturnID,
                        principalTable: "Return",
                        principalColumn: "ReturnID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Return_PartnerID",
                table: "Return",
                column: "PartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnlDetail_MovieID",
                table: "ReturnlDetail",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnlDetail_ReturnID",
                table: "ReturnlDetail",
                column: "ReturnID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturndetailTemp");

            migrationBuilder.DropTable(
                name: "ReturnlDetail");

            migrationBuilder.DropTable(
                name: "Return");
        }
    }
}
