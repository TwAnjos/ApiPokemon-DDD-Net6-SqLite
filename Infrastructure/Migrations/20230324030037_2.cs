using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_USER_ENDERECO_END_USR_ID",
                table: "TB_USER_ENDERECO");

            migrationBuilder.DropIndex(
                name: "IX_TB_TELEFONE_TLF_USR_ID",
                table: "TB_TELEFONE");

            migrationBuilder.AddColumn<int>(
                name: "TB_TELEFONE",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TB_USER_ENDERECO",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_USER_ENDERECO_END_USR_ID",
                table: "TB_USER_ENDERECO",
                column: "END_USR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TELEFONE_TLF_USR_ID",
                table: "TB_TELEFONE",
                column: "TLF_USR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TB_TELEFONE",
                table: "AspNetUsers",
                column: "TB_TELEFONE");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TB_USER_ENDERECO",
                table: "AspNetUsers",
                column: "TB_USER_ENDERECO");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TB_TELEFONE_TB_TELEFONE",
                table: "AspNetUsers",
                column: "TB_TELEFONE",
                principalTable: "TB_TELEFONE",
                principalColumn: "TLF_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TB_USER_ENDERECO_TB_USER_ENDERECO",
                table: "AspNetUsers",
                column: "TB_USER_ENDERECO",
                principalTable: "TB_USER_ENDERECO",
                principalColumn: "END_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TB_TELEFONE_TB_TELEFONE",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TB_USER_ENDERECO_TB_USER_ENDERECO",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_TB_USER_ENDERECO_END_USR_ID",
                table: "TB_USER_ENDERECO");

            migrationBuilder.DropIndex(
                name: "IX_TB_TELEFONE_TLF_USR_ID",
                table: "TB_TELEFONE");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TB_TELEFONE",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TB_USER_ENDERECO",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TB_TELEFONE",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TB_USER_ENDERECO",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USER_ENDERECO_END_USR_ID",
                table: "TB_USER_ENDERECO",
                column: "END_USR_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_TELEFONE_TLF_USR_ID",
                table: "TB_TELEFONE",
                column: "TLF_USR_ID",
                unique: true);
        }
    }
}
