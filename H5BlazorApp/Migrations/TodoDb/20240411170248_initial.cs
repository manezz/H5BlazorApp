using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H5BlazorApp.Migrations.TodoDb
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cpr",
                columns: table => new
                {
                    CprId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    CprNr = table.Column<string>(type: "nvarchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cpr", x => x.CprId);
                });

            migrationBuilder.CreateTable(
                name: "Todolist",
                columns: table => new
                {
                    TodolistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CprId = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todolist", x => x.TodolistId);
                    table.ForeignKey(
                        name: "FK_Todolist_Cpr_CprId",
                        column: x => x.CprId,
                        principalTable: "Cpr",
                        principalColumn: "CprId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todolist_CprId",
                table: "Todolist",
                column: "CprId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todolist");

            migrationBuilder.DropTable(
                name: "Cpr");
        }
    }
}
