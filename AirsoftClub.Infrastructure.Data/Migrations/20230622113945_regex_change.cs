using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirsoftClub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class regex_change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6f8e30bc-5cbd-4116-9587-e1620df6647f"),
                column: "Password",
                value: "6bfae28465b2ef635dae77260160f27c5a555efdf099a15012201d173e634557");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("960cb14e-d653-46ed-96ba-c75cd8703f4a"),
                column: "Password",
                value: "6bfae28465b2ef635dae77260160f27c5a555efdf099a15012201d173e634557");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a16ca84c-196a-412d-b2f7-99eadcd5ef54"),
                column: "Password",
                value: "6bfae28465b2ef635dae77260160f27c5a555efdf099a15012201d173e634557");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c10b956d-2cf4-4f55-8773-695e94fdcb07"),
                column: "Password",
                value: "6bfae28465b2ef635dae77260160f27c5a555efdf099a15012201d173e634557");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e4001e95-3efb-4e74-add8-9b70ec190b5a"),
                column: "Password",
                value: "6bfae28465b2ef635dae77260160f27c5a555efdf099a15012201d173e634557");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6f8e30bc-5cbd-4116-9587-e1620df6647f"),
                column: "Password",
                value: "ee79976c9380d5e337fc1c095ece8c8f22f91f306ceeb161fa51fecede2c4ba1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("960cb14e-d653-46ed-96ba-c75cd8703f4a"),
                column: "Password",
                value: "ee79976c9380d5e337fc1c095ece8c8f22f91f306ceeb161fa51fecede2c4ba1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a16ca84c-196a-412d-b2f7-99eadcd5ef54"),
                column: "Password",
                value: "ee79976c9380d5e337fc1c095ece8c8f22f91f306ceeb161fa51fecede2c4ba1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c10b956d-2cf4-4f55-8773-695e94fdcb07"),
                column: "Password",
                value: "ee79976c9380d5e337fc1c095ece8c8f22f91f306ceeb161fa51fecede2c4ba1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e4001e95-3efb-4e74-add8-9b70ec190b5a"),
                column: "Password",
                value: "ee79976c9380d5e337fc1c095ece8c8f22f91f306ceeb161fa51fecede2c4ba1");
        }
    }
}
