using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class _16042021_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildMenu_Application_ApplicationId",
                table: "ChildMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildMenu_ParentMenu_ParentMenuId",
                table: "ChildMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParentMenu",
                table: "ParentMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildMenu",
                table: "ChildMenu");

            migrationBuilder.RenameTable(
                name: "ParentMenu",
                newName: "ParentMenus");

            migrationBuilder.RenameTable(
                name: "ChildMenu",
                newName: "ChildMenus");

            migrationBuilder.RenameIndex(
                name: "IX_ChildMenu_ParentMenuId",
                table: "ChildMenus",
                newName: "IX_ChildMenus_ParentMenuId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildMenu_ApplicationId",
                table: "ChildMenus",
                newName: "IX_ChildMenus_ApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParentMenus",
                table: "ParentMenus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildMenus",
                table: "ChildMenus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RightsDistributions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    ChildMenuId = table.Column<int>(type: "int", nullable: true),
                    AllowView = table.Column<bool>(type: "bit", nullable: false),
                    AllowAdd = table.Column<bool>(type: "bit", nullable: false),
                    AllowUpdate = table.Column<bool>(type: "bit", nullable: false),
                    AllowDelete = table.Column<bool>(type: "bit", nullable: false),
                    AllowPrint = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RightsDistributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RightsDistributions_ChildMenus_ChildMenuId",
                        column: x => x.ChildMenuId,
                        principalTable: "ChildMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RightsDistributions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RightsDistributions_ChildMenuId",
                table: "RightsDistributions",
                column: "ChildMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_RightsDistributions_RoleId",
                table: "RightsDistributions",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildMenus_Application_ApplicationId",
                table: "ChildMenus",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildMenus_ParentMenus_ParentMenuId",
                table: "ChildMenus",
                column: "ParentMenuId",
                principalTable: "ParentMenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildMenus_Application_ApplicationId",
                table: "ChildMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildMenus_ParentMenus_ParentMenuId",
                table: "ChildMenus");

            migrationBuilder.DropTable(
                name: "RightsDistributions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParentMenus",
                table: "ParentMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildMenus",
                table: "ChildMenus");

            migrationBuilder.RenameTable(
                name: "ParentMenus",
                newName: "ParentMenu");

            migrationBuilder.RenameTable(
                name: "ChildMenus",
                newName: "ChildMenu");

            migrationBuilder.RenameIndex(
                name: "IX_ChildMenus_ParentMenuId",
                table: "ChildMenu",
                newName: "IX_ChildMenu_ParentMenuId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildMenus_ApplicationId",
                table: "ChildMenu",
                newName: "IX_ChildMenu_ApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParentMenu",
                table: "ParentMenu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildMenu",
                table: "ChildMenu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildMenu_Application_ApplicationId",
                table: "ChildMenu",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildMenu_ParentMenu_ParentMenuId",
                table: "ChildMenu",
                column: "ParentMenuId",
                principalTable: "ParentMenu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
