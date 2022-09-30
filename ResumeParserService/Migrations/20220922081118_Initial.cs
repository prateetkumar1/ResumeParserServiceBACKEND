using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeParserService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    EmailID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateDetail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResumeStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(nullable: true),
                    StatusCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResumeSaves",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateDetailID = table.Column<int>(nullable: true),
                    ResumePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSaves", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ResumeSaves_CandidateDetail_CandidateDetailID",
                        column: x => x.CandidateDetailID,
                        principalTable: "CandidateDetail",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSaves_CandidateDetailID",
                table: "ResumeSaves",
                column: "CandidateDetailID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResumeSaves");

            migrationBuilder.DropTable(
                name: "ResumeStatuses");

            migrationBuilder.DropTable(
                name: "CandidateDetail");
        }
    }
}
