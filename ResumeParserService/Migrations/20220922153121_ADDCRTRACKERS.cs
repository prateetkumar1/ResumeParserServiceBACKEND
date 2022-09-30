using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeParserService.Migrations
{
    public partial class ADDCRTRACKERS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateResumeTrackers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CandidateDetailID = table.Column<int>(nullable: true),
                    ResumeStatusID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateResumeTrackers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CandidateResumeTrackers_CandidateDetails_CandidateDetailID",
                        column: x => x.CandidateDetailID,
                        principalTable: "CandidateDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateResumeTrackers_ResumeStatuses_ResumeStatusID",
                        column: x => x.ResumeStatusID,
                        principalTable: "ResumeStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateResumeTrackers_CandidateDetailID",
                table: "CandidateResumeTrackers",
                column: "CandidateDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateResumeTrackers_ResumeStatusID",
                table: "CandidateResumeTrackers",
                column: "ResumeStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateResumeTrackers");
        }
    }
}
