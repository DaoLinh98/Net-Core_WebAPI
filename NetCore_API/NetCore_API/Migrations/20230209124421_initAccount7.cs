using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class initAccount7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<int>(name: "Asset_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetName = table.Column<string>(name: "Asset_Name", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartId = table.Column<int>(name: "Depart_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartName = table.Column<string>(name: "Depart_Name", type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(name: "User_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(name: "User_Name", type: "nvarchar(max)", nullable: false),
                    NumberPhone = table.Column<string>(name: "Number_Phone", type: "nvarchar(max)", nullable: true),
                    DepartId = table.Column<int>(name: "Depart_Id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Departments_Depart_Id",
                        column: x => x.DepartId,
                        principalTable: "Departments",
                        principalColumn: "Depart_Id");
                });

            migrationBuilder.CreateTable(
                name: "Assugnments",
                columns: table => new
                {
                    AssetId = table.Column<int>(name: "Asset_Id", type: "int", nullable: false),
                    UserId = table.Column<int>(name: "User_Id", type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assugnments", x => new { x.UserId, x.AssetId });
                    table.ForeignKey(
                        name: "FK_Assugnments_Assets_Asset_Id",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Asset_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assugnments_Users_User_Id",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assugnments_Asset_Id",
                table: "Assugnments",
                column: "Asset_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Depart_Id",
                table: "Users",
                column: "Depart_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assugnments");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
