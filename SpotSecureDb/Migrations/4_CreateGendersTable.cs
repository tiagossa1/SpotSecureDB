using FluentMigrator;

namespace SpotSecureDB.Migrations;

[Migration(20231210000004)]
public class CreateGendersTable : Migration
{
    private const string TableName = "Genders";
    
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