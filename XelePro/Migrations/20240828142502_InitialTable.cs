using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XelePro.Migrations
{
    /// <inheritdoc />
    public partial class InitialTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyFolders",
                columns: table => new
                {
                    MyFolderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentFolderId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyFolders", x => x.MyFolderId);
                    table.ForeignKey(
                        name: "FK_MyFolders_MyFolders_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalTable: "MyFolders",
                        principalColumn: "MyFolderId");
                });

            migrationBuilder.CreateTable(
                name: "MyFiles",
                columns: table => new
                {
                    MyFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyFolderId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyFiles", x => x.MyFileId);
                    table.ForeignKey(
                        name: "FK_MyFiles_MyFolders_MyFolderId",
                        column: x => x.MyFolderId,
                        principalTable: "MyFolders",
                        principalColumn: "MyFolderId");
                });

            migrationBuilder.InsertData(
                table: "MyFolders",
                columns: new[] { "MyFolderId", "CreatedBy", "CreatedOn", "FolderName", "Isdeleted", "ParentFolderId", "UpdatedBy", "UpdatedOn", "path" },
                values: new object[,]
                {
                    { 1, "USER ADMIN", new DateTime(2024, 8, 28, 17, 25, 2, 761, DateTimeKind.Local).AddTicks(4389), "Folder1", false, 1, null, null, "C:Users-Xele-Desktop-Folder1" },
                    { 2, "USER ADMIN", new DateTime(2024, 8, 28, 17, 25, 2, 761, DateTimeKind.Local).AddTicks(4411), "Folder2", false, 2, null, null, "C:Users-Xele-Desktop-Folder2" }
                });

            migrationBuilder.InsertData(
                table: "MyFiles",
                columns: new[] { "MyFileId", "CreatedBy", "CreatedOn", "FileExtension", "FileName", "FilePath", "Isdeleted", "MyFolderId", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "USER ADMIN", new DateTime(2024, 8, 28, 17, 25, 2, 761, DateTimeKind.Local).AddTicks(4516), "txt", "FileName1", "C:Users-Xele-Desktop-Folder1-FileName1", false, 1, null, null },
                    { 2, "USER ADMIN", new DateTime(2024, 8, 28, 17, 25, 2, 761, DateTimeKind.Local).AddTicks(4519), "PDF", "FileName2", "C:Users-Xele-Desktop-Folder2-FileName2", false, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "MyFolders",
                columns: new[] { "MyFolderId", "CreatedBy", "CreatedOn", "FolderName", "Isdeleted", "ParentFolderId", "UpdatedBy", "UpdatedOn", "path" },
                values: new object[] { 3, "USER ADMIN", new DateTime(2024, 8, 28, 17, 25, 2, 761, DateTimeKind.Local).AddTicks(4413), "Folder3", false, 2, null, null, "C:Users-Xele-Desktop-Folder3" });

            migrationBuilder.InsertData(
                table: "MyFiles",
                columns: new[] { "MyFileId", "CreatedBy", "CreatedOn", "FileExtension", "FileName", "FilePath", "Isdeleted", "MyFolderId", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 3, "USER ADMIN", new DateTime(2024, 8, 28, 17, 25, 2, 761, DateTimeKind.Local).AddTicks(4520), "DOCX", "FileName3", "C:Users-Xele-Desktop-Folder3-FileName3", false, 3, null, null });

            migrationBuilder.InsertData(
                table: "MyFolders",
                columns: new[] { "MyFolderId", "CreatedBy", "CreatedOn", "FolderName", "Isdeleted", "ParentFolderId", "UpdatedBy", "UpdatedOn", "path" },
                values: new object[] { 4, "USER ADMIN", new DateTime(2024, 8, 28, 17, 25, 2, 761, DateTimeKind.Local).AddTicks(4414), "Folder4", false, 3, null, null, "C:Users-Xele-Desktop-Folder4" });

            migrationBuilder.InsertData(
                table: "MyFiles",
                columns: new[] { "MyFileId", "CreatedBy", "CreatedOn", "FileExtension", "FileName", "FilePath", "Isdeleted", "MyFolderId", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 4, "USER ADMIN", new DateTime(2024, 8, 28, 17, 25, 2, 761, DateTimeKind.Local).AddTicks(4522), "JPG", "FileName4", "C:Users-Xele-Desktop-Folder4-FileName4", false, 4, null, null });

            migrationBuilder.InsertData(
                table: "MyFolders",
                columns: new[] { "MyFolderId", "CreatedBy", "CreatedOn", "FolderName", "Isdeleted", "ParentFolderId", "UpdatedBy", "UpdatedOn", "path" },
                values: new object[,]
                {
                    { 5, "USER ADMIN", new DateTime(2024, 8, 28, 17, 25, 2, 761, DateTimeKind.Local).AddTicks(4416), "Folder5", false, 4, null, null, "C:Users-Xele-Desktop-Folder5" },
                    { 6, "USER ADMIN", new DateTime(2024, 8, 28, 17, 25, 2, 761, DateTimeKind.Local).AddTicks(4418), "Folder6", false, 4, null, null, "C:Users-Xele-Desktop-Folder6" }
                });

            migrationBuilder.InsertData(
                table: "MyFiles",
                columns: new[] { "MyFileId", "CreatedBy", "CreatedOn", "FileExtension", "FileName", "FilePath", "Isdeleted", "MyFolderId", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 5, "USER ADMIN", new DateTime(2024, 8, 28, 17, 25, 2, 761, DateTimeKind.Local).AddTicks(4524), "XLSX", "FileName5", "C:Users-Xele-Desktop-Folder5-FileName5", false, 5, null, null },
                    { 6, "USER ADMIN", new DateTime(2024, 8, 28, 17, 25, 2, 761, DateTimeKind.Local).AddTicks(4525), "PNG", "FileName6", "C:Users-Xele-Desktop-Folder6-FileName6", false, 6, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyFiles_MyFolderId",
                table: "MyFiles",
                column: "MyFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_MyFolders_ParentFolderId",
                table: "MyFolders",
                column: "ParentFolderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyFiles");

            migrationBuilder.DropTable(
                name: "MyFolders");
        }
    }
}
