using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace ToSic.Module.AnalyzeServiceLifetimes.Migrations.EntityBuilders
{
    public class AnalyzeServiceLifetimesEntityBuilder : AuditableBaseEntityBuilder<AnalyzeServiceLifetimesEntityBuilder>
    {
        private const string _entityTableName = "ToSicAnalyzeServiceLifetimes";
        private readonly PrimaryKey<AnalyzeServiceLifetimesEntityBuilder> _primaryKey = new("PK_ToSicAnalyzeServiceLifetimes", x => x.AnalyzeServiceLifetimesId);
        private readonly ForeignKey<AnalyzeServiceLifetimesEntityBuilder> _moduleForeignKey = new("FK_ToSicAnalyzeServiceLifetimes_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public AnalyzeServiceLifetimesEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override AnalyzeServiceLifetimesEntityBuilder BuildTable(ColumnsBuilder table)
        {
            AnalyzeServiceLifetimesId = AddAutoIncrementColumn(table,"AnalyzeServiceLifetimesId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> AnalyzeServiceLifetimesId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
