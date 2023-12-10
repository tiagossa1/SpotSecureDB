using FluentMigrator;

namespace SpotSecureDB.Migrations;

[Migration(20231210000010)]
public class CreateTicketsTable : Migration
{
    private const string TableName = "Tickets";
    
    public override void Up()
    {
        Create.Table(TableName)
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("TicketStatusId").AsInt64().NotNullable().ForeignKey("TicketStatuses", "Id")
            .WithColumn("TicketTypeId").AsInt64().NotNullable().ForeignKey("TicketTypes", "Id")
            .WithColumn("UserId").AsInt64().Nullable().ForeignKey("Users", "Id")
            .WithColumn("DriverId").AsInt64().NotNullable().ForeignKey("Drivers", "Id")
            .WithColumn("Title").AsString().NotNullable()
            .WithColumn("Description").AsString().NotNullable()
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