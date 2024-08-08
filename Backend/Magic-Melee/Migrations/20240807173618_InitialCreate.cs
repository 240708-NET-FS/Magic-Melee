using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magic_Melee.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbilityScoreArr",
                columns: table => new
                {
                    AbilityScoreArrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Str = table.Column<int>(type: "int", nullable: false),
                    Dex = table.Column<int>(type: "int", nullable: false),
                    Con = table.Column<int>(type: "int", nullable: false),
                    Int = table.Column<int>(type: "int", nullable: false),
                    Wis = table.Column<int>(type: "int", nullable: false),
                    Cha = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityScoreArr", x => x.AbilityScoreArrId);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClasses",
                columns: table => new
                {
                    CharacterClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClasses", x => x.CharacterClassId);
                });

            migrationBuilder.CreateTable(
                name: "CharacterRaces",
                columns: table => new
                {
                    CharacterRaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterRaces", x => x.CharacterRaceId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Athletics = table.Column<int>(type: "int", nullable: false),
                    Acrobatics = table.Column<int>(type: "int", nullable: false),
                    SleightOfHand = table.Column<int>(type: "int", nullable: false),
                    Stealth = table.Column<int>(type: "int", nullable: false),
                    Deception = table.Column<int>(type: "int", nullable: false),
                    AnimalHandling = table.Column<int>(type: "int", nullable: false),
                    Survival = table.Column<int>(type: "int", nullable: false),
                    History = table.Column<int>(type: "int", nullable: false),
                    Religion = table.Column<int>(type: "int", nullable: false),
                    Medicine = table.Column<int>(type: "int", nullable: false),
                    Perception = table.Column<int>(type: "int", nullable: false),
                    Insight = table.Column<int>(type: "int", nullable: false),
                    Performance = table.Column<int>(type: "int", nullable: false),
                    Intimidation = table.Column<int>(type: "int", nullable: false),
                    Persuasion = table.Column<int>(type: "int", nullable: false),
                    Arcana = table.Column<int>(type: "int", nullable: false),
                    Investigation = table.Column<int>(type: "int", nullable: false),
                    Nature = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillsId);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    SpellId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpellName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpellRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpellLevel = table.Column<int>(type: "int", nullable: false),
                    SpellDamageType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.SpellId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "DndCharacters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    MaxHitPoints = table.Column<int>(type: "int", nullable: false),
                    CharacterLevel = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CharacterRaceId = table.Column<int>(type: "int", nullable: false),
                    CharacterClassId = table.Column<int>(type: "int", nullable: false),
                    AbilityScoreArrId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DndCharacters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_DndCharacters_AbilityScoreArr_AbilityScoreArrId",
                        column: x => x.AbilityScoreArrId,
                        principalTable: "AbilityScoreArr",
                        principalColumn: "AbilityScoreArrId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DndCharacters_CharacterClasses_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "CharacterClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DndCharacters_CharacterRaces_CharacterRaceId",
                        column: x => x.CharacterRaceId,
                        principalTable: "CharacterRaces",
                        principalColumn: "CharacterRaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DndCharacters_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "SkillsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DndCharacters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginId);
                    table.ForeignKey(
                        name: "FK_Logins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSpells",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    SpellId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSpells", x => new { x.CharacterId, x.SpellId });
                    table.ForeignKey(
                        name: "FK_CharacterSpells_DndCharacters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "DndCharacters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSpells_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "SpellId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpells_SpellId",
                table: "CharacterSpells",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_DndCharacters_AbilityScoreArrId",
                table: "DndCharacters",
                column: "AbilityScoreArrId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DndCharacters_CharacterClassId",
                table: "DndCharacters",
                column: "CharacterClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DndCharacters_CharacterRaceId",
                table: "DndCharacters",
                column: "CharacterRaceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DndCharacters_SkillsId",
                table: "DndCharacters",
                column: "SkillsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DndCharacters_UserId",
                table: "DndCharacters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserId",
                table: "Logins",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSpells");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "DndCharacters");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "AbilityScoreArr");

            migrationBuilder.DropTable(
                name: "CharacterClasses");

            migrationBuilder.DropTable(
                name: "CharacterRaces");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
