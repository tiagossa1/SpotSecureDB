using FluentMigrator;

namespace SpotSecureDB.Migrations;

[Migration(20231210000007)]
public class CreateSpotReservationsTable : Migration
{
    public override void Up()
    {
        Create.Table("SpotReservations")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("CarId").AsInt64().NotNullable().ForeignKey("Cars", "Id")
            .WithColumn("ReservationFromDateTimeUtc").AsDateTime2().NotNullable()
            .WithColumn("ReservationToDateTimeUtc").AsDateTime2().NotNullable()
            .WithColumn("CreatedOn").AsDateTime2().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
            .WithColumn("CreatedBy").AsInt32().NotNullable().ForeignKey("Users", "Id")
            .WithColumn("UpdatedOn").AsDateTime2().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
            .WithColumn("UpdatedBy").AsInt32().NotNullable().ForeignKey("Users", "Id");
    }

    public override void Down()
    {
        Delete.Table("SpotReservations");
    }
}