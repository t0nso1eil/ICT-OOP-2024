#pragma warning disable SA1210
#pragma warning disable IDE0005
#pragma warning disable IDE0161

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MentallHealthSupport.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "psychologist",
                columns: table => new
                {
                    psychologist_id = table.Column<string>(type: "character varying", nullable: false),
                    UserId = table.Column<string>(type: "character varying", nullable: false),
                    specialization = table.Column<string>(type: "character varying", nullable: false),
                    experience_start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    experience_years = table.Column<int>(type: "int", nullable: false),
                    price_per_hour = table.Column<decimal>(type: "numeric", nullable: false),
                    rate = table.Column<float>(type: "numeric", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("psychologist_pkey", x => x.psychologist_id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "character varying", nullable: false),
                    first_name = table.Column<string>(type: "character varying", nullable: false),
                    last_name = table.Column<string>(type: "character varying", nullable: false),
                    email = table.Column<string>(type: "character varying", nullable: false),
                    phone_number = table.Column<string>(type: "character varying", nullable: false),
                    password = table.Column<string>(type: "character varying", nullable: false),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    sex = table.Column<string>(type: "character varying", nullable: false),
                    additional_info = table.Column<string>(type: "text", nullable: false),
                    registration_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    is_psychologist = table.Column<bool>(type: "boolean", nullable: false),
                    PsychologistId = table.Column<string>(type: "character varying", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    review_id = table.Column<string>(type: "character varying", nullable: false),
                    user_id = table.Column<string>(type: "character varying", nullable: false),
                    psychologist_id = table.Column<string>(type: "character varying", nullable: false),
                    rate = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    PostTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("review_pkey", x => x.review_id);
                    table.ForeignKey(
                        name: "review_psychologist_psychologist_id_fk",
                        column: x => x.psychologist_id,
                        principalTable: "psychologist",
                        principalColumn: "psychologist_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "review_user_user_id_fk",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "session",
                columns: table => new
                {
                    session_id = table.Column<string>(type: "character varying", nullable: false),
                    user_id = table.Column<string>(type: "character varying", nullable: false),
                    spot_id = table.Column<string>(type: "character varying", nullable: false),
                    status = table.Column<string>(type: "character varying", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("sessions_pkey", x => x.session_id);
                    table.ForeignKey(
                        name: "session_user_user_id_fk",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "spot",
                columns: table => new
                {
                    spot_id = table.Column<string>(type: "character varying", nullable: false),
                    PsychologistId = table.Column<string>(type: "character varying", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    hour_start = table.Column<DateTime>(type: "time without timezone", nullable: false),
                    hour_end = table.Column<DateTime>(type: "time without timezone", nullable: false),
                    status = table.Column<string>(type: "character varying", nullable: false),
                    SessionId = table.Column<string>(type: "character varying", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("spots_pkey", x => x.spot_id);
                    table.ForeignKey(
                        name: "session_spot_spot_id_fk",
                        column: x => x.SessionId,
                        principalTable: "session",
                        principalColumn: "session_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "spot_psychologist_psychologist_id_fk",
                        column: x => x.PsychologistId,
                        principalTable: "psychologist",
                        principalColumn: "psychologist_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_psychologist_UserId",
                table: "psychologist",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_review_psychologist_id",
                table: "review",
                column: "psychologist_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_user_id",
                table: "review",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_session_user_id",
                table: "session",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_spot_PsychologistId",
                table: "spot",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_spot_SessionId",
                table: "spot",
                column: "SessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_PsychologistId",
                table: "user",
                column: "PsychologistId");

            migrationBuilder.AddForeignKey(
                name: "psychologist_user_user_id_fk",
                table: "psychologist",
                column: "UserId",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "psychologist_user_user_id_fk",
                table: "psychologist");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "spot");

            migrationBuilder.DropTable(
                name: "session");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "psychologist");
        }
    }
}
