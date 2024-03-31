using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class test03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanViens_ChucVus_chucVuID",
                table: "NhanViens");

            migrationBuilder.RenameColumn(
                name: "chucVuID",
                table: "NhanViens",
                newName: "ChucVuID");

            migrationBuilder.RenameIndex(
                name: "IX_NhanViens_chucVuID",
                table: "NhanViens",
                newName: "IX_NhanViens_ChucVuID");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChucVuID",
                table: "NhanViens",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanViens_ChucVus_ChucVuID",
                table: "NhanViens",
                column: "ChucVuID",
                principalTable: "ChucVus",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanViens_ChucVus_ChucVuID",
                table: "NhanViens");

            migrationBuilder.RenameColumn(
                name: "ChucVuID",
                table: "NhanViens",
                newName: "chucVuID");

            migrationBuilder.RenameIndex(
                name: "IX_NhanViens_ChucVuID",
                table: "NhanViens",
                newName: "IX_NhanViens_chucVuID");

            migrationBuilder.AlterColumn<Guid>(
                name: "chucVuID",
                table: "NhanViens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanViens_ChucVus_chucVuID",
                table: "NhanViens",
                column: "chucVuID",
                principalTable: "ChucVus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
