using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class mod1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_MESSAGE_AspNetUsers_UserId",
                table: "TB_MESSAGE");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_POKEMONS_CAPTURADOS_AspNetUsers_PKM_USR_ID",
                table: "TB_POKEMONS_CAPTURADOS");

            migrationBuilder.AlterColumn<string>(
                name: "PKM_USR_ID",
                table: "TB_POKEMONS_CAPTURADOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "PKM_NOME",
                table: "TB_POKEMONS_CAPTURADOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TB_MESSAGE",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "MSN_TITULO",
                table: "TB_MESSAGE",
                type: "TEXT",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "MSN_MENSAGEM",
                table: "TB_MESSAGE",
                type: "TEXT",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<int>(
                name: "USR_TIPO",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "USR_IDADE",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MESSAGE_AspNetUsers_UserId",
                table: "TB_MESSAGE",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_POKEMONS_CAPTURADOS_AspNetUsers_PKM_USR_ID",
                table: "TB_POKEMONS_CAPTURADOS",
                column: "PKM_USR_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_MESSAGE_AspNetUsers_UserId",
                table: "TB_MESSAGE");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_POKEMONS_CAPTURADOS_AspNetUsers_PKM_USR_ID",
                table: "TB_POKEMONS_CAPTURADOS");

            migrationBuilder.AlterColumn<string>(
                name: "PKM_USR_ID",
                table: "TB_POKEMONS_CAPTURADOS",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PKM_NOME",
                table: "TB_POKEMONS_CAPTURADOS",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TB_MESSAGE",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MSN_TITULO",
                table: "TB_MESSAGE",
                type: "TEXT",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MSN_MENSAGEM",
                table: "TB_MESSAGE",
                type: "TEXT",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "USR_TIPO",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "USR_IDADE",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MESSAGE_AspNetUsers_UserId",
                table: "TB_MESSAGE",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_POKEMONS_CAPTURADOS_AspNetUsers_PKM_USR_ID",
                table: "TB_POKEMONS_CAPTURADOS",
                column: "PKM_USR_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
