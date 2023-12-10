using FluentMigrator;

namespace SpotSecureDB.Migrations;

[Migration(20231210000001)]
public class CreateUsersTable : Migration
{
    public override void Up()
    {
        Create.Table("Users")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Username").AsString().NotNullable()
            .WithColumn("PasswordHash").AsString().NotNullable()
            .WithColumn("Email").AsString().NotNullable()
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("TimeZone").AsString().NotNullable()
            .WithColumn("CreatedOn").AsDateTime2().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
            .WithColumn("CreatedBy").AsInt32().ForeignKey("Users", "Id")
            .WithColumn("UpdatedOn").AsDateTime2().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
            .WithColumn("UpdatedBy").AsInt32().NotNullable().ForeignKey("Users", "Id");
    }

    public override void Down()
    {
        Delete.Table("Users");
    }
}