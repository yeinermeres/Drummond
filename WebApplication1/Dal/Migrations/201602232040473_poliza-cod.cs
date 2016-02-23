namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class polizacod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polizas", "COD_POLIZA", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Polizas", "COD_POLIZA");
        }
    }
}
