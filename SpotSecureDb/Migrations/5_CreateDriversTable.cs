using FluentMigrator;
using FluentMigrator.Postgres;

namespace SpotSecureDB.Migrations;

[Migration(20231210000005)]
public class CreateDriversTable : Migration
{
    private const string TableName = "Drivers";
    
    public override void Up()
    {
        Create.Table(TableName)
            .WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
            .WithColumn("UserId").AsInt64().NotNullable().ForeignKey("Users", "Id")
            .WithColumn("IdentificationNumber").AsString().NotNullable()
            .WithColumn("DriversLicenceId").AsString().NotNullable()
            .WithColumn("DateOfBirth").AsDateTime2().NotNullable()
            .WithColumn("PhoneNumber").AsString().NotNullable()
            .WithColumn("GenderId").AsInt64().NotNullable().ForeignKey("Genders", "Id")
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