using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marvin.IDP.Migrations
{
    /// <inheritdoc />
    public partial class AssUserLogins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("0d46b8ae-c923-4692-b67e-2bf6e45262e9"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2e6a02af-4985-43b4-96b5-4f7210438bb5"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("3d6b9eab-581c-4b90-ad17-8784c341e28a"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("835a2e91-fd26-4c31-9976-a0f0dabda4d8"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("84a32f99-c8e2-4d21-9c71-e05e25792a9c"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("97baca18-210c-4059-b1d4-40593f5a6164"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("ec2dd9f7-4e3d-48a0-b84f-a69a5b4af7da"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("fcedd002-a978-47c3-84f9-d1b9c19b9bef"));

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Provider = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ProviderIdentityKey = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("2175a7b0-3063-4434-ad25-71effbea083d"), "9247f6f8-1bc3-4c96-ba53-e0fc15a527e5", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("32bc35c8-b0f4-4426-affc-8dfe5a718171"), "c236016b-9f3f-45e9-941c-addceb4f1b4a", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("3de3482c-c877-40df-91f6-fb963ab631c8"), "60574319-a3c0-45ec-abb0-cce212abf302", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("607cfb5d-0061-4698-9cf1-98fbeede56c7"), "1444ca69-820c-4dbe-9f62-a0e6ea7660b2", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("ab9c628b-9f55-4746-93b4-d0d9b8c4e32b"), "8a1c536d-34f6-4869-87e4-00e77cddef7e", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("d10bfea9-6433-498e-aa8b-06cd3bd3c68e"), "4319777d-6620-4707-92dc-df107d4dd5e2", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("e1481e45-69dc-4c70-8a21-b765d0fe296e"), "980ec780-d648-43fb-a3c2-24abc7871d3d", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("e65c8167-723d-4445-adda-6b426fd26f85"), "3cf30017-adcc-40b0-97e1-720726b9cec2", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "f44f5c36-42e8-462c-abcf-f8eb881cea4a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                columns: new[] { "ConcurrencyStamp", "Email" },
                values: new object[] { "6db2b253-c325-4538-a412-186c7371cb79", "grafvonmc@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2175a7b0-3063-4434-ad25-71effbea083d"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("32bc35c8-b0f4-4426-affc-8dfe5a718171"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("3de3482c-c877-40df-91f6-fb963ab631c8"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("607cfb5d-0061-4698-9cf1-98fbeede56c7"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("ab9c628b-9f55-4746-93b4-d0d9b8c4e32b"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d10bfea9-6433-498e-aa8b-06cd3bd3c68e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e1481e45-69dc-4c70-8a21-b765d0fe296e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e65c8167-723d-4445-adda-6b426fd26f85"));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("0d46b8ae-c923-4692-b67e-2bf6e45262e9"), "b9b4edf6-98b2-4333-852c-c8f6746d3ebf", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("2e6a02af-4985-43b4-96b5-4f7210438bb5"), "833489af-94fe-4561-a481-bdbdf3768186", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("3d6b9eab-581c-4b90-ad17-8784c341e28a"), "296cc7d8-7cf1-467c-bf0c-ad40529c80dd", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("835a2e91-fd26-4c31-9976-a0f0dabda4d8"), "c329d10e-e5ff-4f26-8a2e-d8a2ec528653", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("84a32f99-c8e2-4d21-9c71-e05e25792a9c"), "41790e07-d7eb-41c8-a9cb-942ec3e29d90", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("97baca18-210c-4059-b1d4-40593f5a6164"), "352ca4c1-3b2c-4179-975f-cff9d39ea27c", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("ec2dd9f7-4e3d-48a0-b84f-a69a5b4af7da"), "c47c28b3-3fb9-45d9-92a1-e83ed51feb41", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("fcedd002-a978-47c3-84f9-d1b9c19b9bef"), "1d143488-3afc-4230-bbc0-f4320eab5e82", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "7ef62f7e-be2a-450f-8682-b591a9eafedb");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                columns: new[] { "ConcurrencyStamp", "Email" },
                values: new object[] { "1545798c-a030-413f-8ea4-588c11336bcb", "gvonmc@gmail.com" });
        }
    }
}
