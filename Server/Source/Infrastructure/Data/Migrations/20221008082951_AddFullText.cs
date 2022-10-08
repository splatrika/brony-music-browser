using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Migrations
{
    public partial class AddFullText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT CATALOG BrowserFTCat AS DEFAULT",
                suppressTransaction: true);
            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT INDEX ON dbo.Songs(Title) " +
                     "KEY INDEX PK_Songs",
                suppressTransaction: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                sql: "DROP FULLTEXT INDEX ON dbo.Songs",
                suppressTransaction: true);
            migrationBuilder.Sql(
                sql: "DROP FULLTEXT CATALOG BrowserFTCat",
                suppressTransaction: true);
        }
    }
}
