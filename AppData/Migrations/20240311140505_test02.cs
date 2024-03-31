using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class test02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_ChucVu_chucVuID",
                table: "NhanVien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhanVien",
                table: "NhanVien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChucVu",
                table: "ChucVu");

            migrationBuilder.DropColumn(
                name: "ChucVu",
                table: "NhanVien");

            migrationBuilder.RenameTable(
                name: "NhanVien",
                newName: "NhanViens");

            migrationBuilder.RenameTable(
                name: "ChucVu",
                newName: "ChucVus");

            migrationBuilder.RenameIndex(
                name: "IX_NhanVien_chucVuID",
                table: "NhanViens",
                newName: "IX_NhanViens_chucVuID");

            migrationBuilder.AddColumn<Guid>(
                name: "IDChucVu",
                table: "NhanViens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhanViens",
                table: "NhanViens",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChucVus",
                table: "ChucVus",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanViens_ChucVus_chucVuID",
                table: "NhanViens",
                column: "chucVuID",
                principalTable: "ChucVus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanViens_ChucVus_chucVuID",
                table: "NhanViens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhanViens",
                table: "NhanViens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChucVus",
                table: "ChucVus");

            migrationBuilder.DropColumn(
                name: "IDChucVu",
                table: "NhanViens");

            migrationBuilder.RenameTable(
                name: "NhanViens",
                newName: "NhanVien");

            migrationBuilder.RenameTable(
                name: "ChucVus",
                newName: "ChucVu");

            migrationBuilder.RenameIndex(
                name: "IX_NhanViens_chucVuID",
                table: "NhanVien",
                newName: "IX_NhanVien_chucVuID");

            migrationBuilder.AddColumn<int>(
                name: "ChucVu",
                table: "NhanVien",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhanVien",
                table: "NhanVien",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChucVu",
                table: "ChucVu",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_ChucVu_chucVuID",
                table: "NhanVien",
                column: "chucVuID",
                principalTable: "ChucVu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
