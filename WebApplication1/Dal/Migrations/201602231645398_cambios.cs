namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AspiranteProcesoes", "ID_PROCESO");
            AddForeignKey("dbo.AspiranteProcesoes", "ID_PROCESO", "dbo.Proceso_Competitivo", "ID_COMPETITIVO", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspiranteProcesoes", "ID_PROCESO", "dbo.Proceso_Competitivo");
            DropIndex("dbo.AspiranteProcesoes", new[] { "ID_PROCESO" });
        }
    }
}
