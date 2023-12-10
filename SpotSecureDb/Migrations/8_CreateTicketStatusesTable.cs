using FluentMigrator;

namespace SpotSecureDB.Migrations;

[Migration(20231210000008)]
public class CreateTicketStatusesTable : Migration
{
    private const string TableName = "TicketStatuses";
    
    public override void Up()
    {
        Create.Table(TableName)
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Code").AsString().Unique().NotNullable()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("CreatedOn").AsDateTime2().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
            .WithColumn("CreatedBy").AsInt32().NotNullable().ForeignKey("Users", "Id")
            .WithColumn("UpdatedOn").AsDateTime2().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
            .WithColumn("UpdatedBy").AsInt32().NotNullable().ForeignKey("Users", "Id");
    }

    public override void Down()
    {
        Delete.Table(TableName);
    }
}