using Microsoft.EntityFrameworkCore.Migrations;

namespace HrCRUDWebApp.Migrations
{
    public partial class mToN2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidatesSkill",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesSkill", x => new { x.CandidateId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CandidatesSkill_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatesSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesSkill_SkillId",
                table: "CandidatesSkill",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatesSkill");
        }
    }
}
