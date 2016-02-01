namespace Sedion.SimpleTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTables : DbMigration
    {
        public override void Up()
        {
            /* 删除一些无用表 */
            DropTable("dbo.AbpFeatures");
            DropTable("dbo.AbpOrganizationUnits");
            DropTable("dbo.AbpSettings");
            DropTable("dbo.AbpUserOrganizationUnits");
            DropTable("dbo.AbpUserLogins");
        }
        
        public override void Down()
        {
        }
    }
}
