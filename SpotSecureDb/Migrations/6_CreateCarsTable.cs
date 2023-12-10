using FluentMigrator;
using FluentMigrator.Postgres;

namespace SpotSecureDB.Migrations;

[Migration(20231210000006)]
public class CreateCarsTable : Migration
{
    private const string TableName = "Cars";
    
    public override void Up()
    {
        Create.Table(TableName)
            .WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
            .WithColumn("LicensePlate").AsString().Unique().NotNullable()
            .WithColumn("DriverId").AsInt64().NotNullable().ForeignKey("Drivers", "Id")
            .WithColumn("CreatedOn").AsDateTime2().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
            .WithColumn("CreatedBy").AsInt64().NotNullable().ForeignKey("Users", "Id")
            .WithColumn("UpdatedOn").AsDateTime2().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
            .WithColumn("UpdatedBy").AsInt32().NotNullable().ForeignKey("Users", "Id");
    }

    public override void Down()
    {
        Delete.Table(TableName);
    }
}