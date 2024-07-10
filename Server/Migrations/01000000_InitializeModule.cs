using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using ToSic.Module.AnalyzeServiceLifetimes.Migrations.EntityBuilders;
using ToSic.Module.AnalyzeServiceLifetimes.Repository;

namespace ToSic.Module.AnalyzeServiceLifetimes.Migrations
{
    [DbContext(typeof(AnalyzeServiceLifetimesContext))]
    [Migration("ToSic.Module.AnalyzeServiceLifetimes.01.00.00.00")]
    public class InitializeModule : MultiDatabaseMigration
    {
        public InitializeModule(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new AnalyzeServiceLifetimesEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Create();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new AnalyzeServiceLifetimesEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Drop();
        }
    }
}
