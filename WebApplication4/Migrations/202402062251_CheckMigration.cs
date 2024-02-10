using Microsoft.EntityFrameworkCore.Migrations;
using Migration = FluentMigrator.Migration;

namespace WebApplication4.Migrations;
  [FluentMigrator.Migration(202402062251)]
public class _202402062251_CheckMigration : Migration
{
    public override void Up()
    {
        Create.Table("Book")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(50).WithDefaultValue("none").Nullable()
            .WithColumn("Category").AsString(40).WithDefaultValue("none").Nullable()
            .WithColumn("Author").AsString(50).WithDefaultValue(1000).NotNullable()
            .WithColumn("PrintYear").AsDateTime().NotNullable()
            .WithColumn("Count").AsInt32().Nullable()
            .WithColumn("RentBookDate").AsDateTime().NotNullable()
            .WithColumn("RentedBookCount").AsInt32().NotNullable();
        
        Create.Table("User")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(50).WithDefaultValue("none").Nullable()
            .WithColumn("Email").AsString(40).WithDefaultValue("none").Nullable()
            .WithColumn("Books").AsString().WithDefaultValue(1000).NotNullable()
            .WithColumn("JoinDate").AsDateTime().NotNullable()
            .WithColumn("RentedBookCount").AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Book");
        Delete.Table("User");
    }
}