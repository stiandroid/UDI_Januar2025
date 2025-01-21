using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDI_Januar2025.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personer",
                columns: table => new
                {
                    Personnummer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reisedokumentnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fornavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etternavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mellomnavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fødselsdato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mobilnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Epost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poststed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personer", x => x.Personnummer);
                });

            migrationBuilder.CreateTable(
                name: "Vedtak",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Authority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GyldigFra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GyldigTil = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vedtak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saker",
                columns: table => new
                {
                    SakId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RefNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecNo = table.Column<int>(type: "int", nullable: false),
                    SendtSms = table.Column<bool>(type: "bit", nullable: false),
                    KontaktPersonnummer = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FullmektigPersonnummer = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SoekerPersonnummer = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VedtakId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saker", x => x.SakId);
                    table.ForeignKey(
                        name: "FK_Saker_Personer_FullmektigPersonnummer",
                        column: x => x.FullmektigPersonnummer,
                        principalTable: "Personer",
                        principalColumn: "Personnummer");
                    table.ForeignKey(
                        name: "FK_Saker_Personer_KontaktPersonnummer",
                        column: x => x.KontaktPersonnummer,
                        principalTable: "Personer",
                        principalColumn: "Personnummer");
                    table.ForeignKey(
                        name: "FK_Saker_Personer_SoekerPersonnummer",
                        column: x => x.SoekerPersonnummer,
                        principalTable: "Personer",
                        principalColumn: "Personnummer");
                    table.ForeignKey(
                        name: "FK_Saker_Vedtak_VedtakId",
                        column: x => x.VedtakId,
                        principalTable: "Vedtak",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Saker_FullmektigPersonnummer",
                table: "Saker",
                column: "FullmektigPersonnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Saker_KontaktPersonnummer",
                table: "Saker",
                column: "KontaktPersonnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Saker_SoekerPersonnummer",
                table: "Saker",
                column: "SoekerPersonnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Saker_VedtakId",
                table: "Saker",
                column: "VedtakId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saker");

            migrationBuilder.DropTable(
                name: "Personer");

            migrationBuilder.DropTable(
                name: "Vedtak");
        }
    }
}
