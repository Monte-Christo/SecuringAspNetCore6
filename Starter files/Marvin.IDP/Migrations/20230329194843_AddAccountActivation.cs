using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marvin.IDP.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountActivation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("391dd6eb-fa7a-4025-a4c5-d2d87f8ed901"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("662b9344-9f0a-42b8-8bdd-f9f7e0e82875"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("6cbc6a34-29ad-4037-be53-74eb5945099a"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("82be2b0d-6543-43a5-8753-97a32c741edb"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a3ce325b-3074-4fea-851c-73d7559fd1ae"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("de0f1428-b0cc-4b1c-8fe2-dee6832a65fa"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("df6380d0-09fb-43b4-9922-2c010202c6f6"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("eb6cd2a2-aea4-44b6-8891-d4fa7527c76b"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                maxLength: 400,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecurityCodeExpirationDate",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityCode", "SecurityCodeExpirationDate" },
                values: new object[] { "7ef62f7e-be2a-450f-8682-b591a9eafedb", "gvonmc@gmail.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityCode", "SecurityCodeExpirationDate" },
                values: new object[] { "1545798c-a030-413f-8ea4-588c11336bcb", "gvonmc@gmail.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCodeExpirationDate",
                table: "Users");

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("391dd6eb-fa7a-4025-a4c5-d2d87f8ed901"), "235886bd-bfc7-40a0-8e65-a127911b20c5", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("662b9344-9f0a-42b8-8bdd-f9f7e0e82875"), "2e03fdf2-91e6-4b21-a43e-2bd047d5e8ce", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("6cbc6a34-29ad-4037-be53-74eb5945099a"), "e6ac3a92-35a1-494a-b398-2410e7ed18fe", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("82be2b0d-6543-43a5-8753-97a32c741edb"), "4edd88ee-9824-4314-8905-4efb2f76836e", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("a3ce325b-3074-4fea-851c-73d7559fd1ae"), "b70ab07d-fefe-4051-a023-d192c2b87f36", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("de0f1428-b0cc-4b1c-8fe2-dee6832a65fa"), "a8f8e9d9-6778-4a7b-877e-269e92ed2734", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("df6380d0-09fb-43b4-9922-2c010202c6f6"), "5ac3436f-9b09-4d7d-a92b-f1bdfd49ede3", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("eb6cd2a2-aea4-44b6-8891-d4fa7527c76b"), "9cc74edd-6efc-49dc-8281-2c1aceb5f635", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "f9f1def3-1b5b-4ea5-b533-a5a6f1e0a9c4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "e97cafed-adc0-4a70-a352-a68f26b8c466");
        }
    }
}
