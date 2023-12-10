using FluentMigrator;

namespace SpotSecureDB.Migrations;

[Migration(20231210000003)]
public class CreateUserRolesTable : Migration
{
    private const string TableName = "UserRoles";
    
    public override void Up()
    {
        Create.Table(TableName)
            .WithColumn("UserId").AsInt64().ForeignKey("Users", "Id")
            .WithColumn("RoleId").AsInt64().ForeignKey("Roles", "Id")
            .WithColumn("UpdatedOn").AsDateTime2().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
            .WithColumn("UpdatedBy").AsInt32().NotNullable().ForeignKey("Users", "Id");
    }

    public override void Down()
    {
        Delete.Table(TableName);
    }
}