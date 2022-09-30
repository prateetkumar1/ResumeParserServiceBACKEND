using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeParserService.Migrations
{
    public partial class REWRITE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResumeSaves_CandidateDetail_CandidateDetailID",
                table: "ResumeSaves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateDetail",
                table: "CandidateDetail");

            migrationBuilder.RenameTable(
                name: "CandidateDetail",
                newName: "CandidateDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateDetails",
                table: "CandidateDetails",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeSaves_CandidateDetails_CandidateDetailID",
                table: "ResumeSaves",
                column: "CandidateDetailID",
                principalTable: "CandidateDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResumeSaves_CandidateDetails_CandidateDetailID",
                table: "ResumeSaves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateDetails",
                table: "CandidateDetails");

            migrationBuilder.RenameTable(
                name: "CandidateDetails",
                newName: "CandidateDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateDetail",
                table: "CandidateDetail",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeSaves_CandidateDetail_CandidateDetailID",
                table: "ResumeSaves",
                column: "CandidateDetailID",
                principalTable: "CandidateDetail",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
