using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace MarkDav.Splore.Migrations.EntityBuilders
{
    public class SploreEntityBuilder : AuditableBaseEntityBuilder<SploreEntityBuilder>
    {
        private const string _entityTableName = "MarkDavSplore";
        private readonly PrimaryKey<SploreEntityBuilder> _primaryKey = new("PK_MarkDavSplore", x => x.SploreId);
        private readonly ForeignKey<SploreEntityBuilder> _moduleForeignKey = new("FK_MarkDavSplore_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public SploreEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override SploreEntityBuilder BuildTable(ColumnsBuilder table)
        {
            SploreId = AddAutoIncrementColumn(table,"SploreId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> SploreId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
