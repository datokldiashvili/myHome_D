
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDateOfBirthColumnType : Migration
    {
       protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.AlterColumn<DateTime>(
        name: "DateOfBirth",
        table: "AspNetUsers",
        type: "TEXT",
        nullable: false,
        defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
        oldClrType: typeof(string),
        oldType: "TEXT",
        oldNullable: true);

    migrationBuilder.AlterColumn<string>(
        name: "City",
        table: "AspNetUsers",
        type: "VARCHAR(255)", 
        nullable: true,
        oldClrType: typeof(string),
        oldType: "TEXT");

    migrationBuilder.AlterColumn<string>(
        name: "Country",
        table: "AspNetUsers",
        type: "VARCHAR(255)", 
        nullable: true,
        oldClrType: typeof(string),
        oldType: "TEXT");

    migrationBuilder.AlterColumn<DateTime>(
        name: "LastActive",
        table: "AspNetUsers",
        type: "DATETIME", 
        nullable: false,
        oldClrType: typeof(DateTime),
        oldType: "TEXT");
}

    }
}

