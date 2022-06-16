﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaVolume.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armario",
                columns: table => new
                {
                    ArmarioId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Regiao = table.Column<string>(nullable: true),
                    PontoY = table.Column<string>(nullable: true),
                    PontoX = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armario", x => x.ArmarioId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Compartimento",
                columns: table => new
                {
                    CompartimentoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(nullable: false),
                    Tamanho = table.Column<string>(nullable: true),
                    Disponivel = table.Column<bool>(nullable: false),
                    Trancado = table.Column<bool>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true),
                    ArmarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compartimento", x => x.CompartimentoId);
                    table.ForeignKey(
                        name: "FK_Compartimento_Armario_ArmarioId",
                        column: x => x.ArmarioId,
                        principalTable: "Armario",
                        principalColumn: "ArmarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compartimento_ArmarioId",
                table: "Compartimento",
                column: "ArmarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compartimento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Armario");
        }
    }
}
