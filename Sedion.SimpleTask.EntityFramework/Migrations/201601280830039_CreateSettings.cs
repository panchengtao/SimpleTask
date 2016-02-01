namespace Sedion.SimpleTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
            "dbo.AbpSettings",
            c => new
            {
                Id = c.Long(nullable: false, identity: true),
                TenantId = c.Int(),
                UserId = c.Long(),
                Name = c.String(nullable: false, maxLength: 256),
                Value = c.String(maxLength: 2000),
                LastModificationTime = c.DateTime(),
                LastModifierUserId = c.Long(),
                CreationTime = c.DateTime(nullable: false),
                CreatorUserId = c.Long(),
            })
            .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.AbpUsers", t => t.UserId)
            .ForeignKey("dbo.AbpTenants", t => t.TenantId)
            .Index(t => t.TenantId)
            .Index(t => t.UserId);

        }
        
        public override void Down()
        {
        }
    }
}
