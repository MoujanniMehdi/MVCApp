using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoUniversity.Migrations
{
    public partial class AjouterProjetcID2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "projetID",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Projet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameProjet = table.Column<string>(nullable: true),
                    theme = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    EncadrantID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projet_Person_EncadrantID",
                        column: x => x.EncadrantID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_projetID",
                table: "Person",
                column: "projetID");

            migrationBuilder.CreateIndex(
                name: "IX_Projet_EncadrantID",
                table: "Projet",
                column: "EncadrantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Projet_projetID",
                table: "Person",
                column: "projetID",
                principalTable: "Projet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Projet_projetID",
                table: "Person");

            migrationBuilder.DropTable(
                name: "Projet");

            migrationBuilder.DropIndex(
                name: "IX_Person_projetID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "projetID",
                table: "Person");
        }
    }
}
