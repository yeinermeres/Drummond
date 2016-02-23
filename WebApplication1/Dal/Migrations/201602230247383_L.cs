namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class L : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archivo_Ruta",
                c => new
                    {
                        ID_RUTA = c.Int(nullable: false, identity: true),
                        RUTA = c.String(),
                        PROCESO_ARCHIVO = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_RUTA)
                .ForeignKey("dbo.Proceso_Competitivo", t => t.PROCESO_ARCHIVO, cascadeDelete: true)
                .Index(t => t.PROCESO_ARCHIVO);
            
            
            
            
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Archivo_Ruta", "PROCESO_ARCHIVO", "dbo.Proceso_Competitivo");
            DropIndex("dbo.Archivo_Ruta", new[] { "PROCESO_ARCHIVO" });
            DropTable("dbo.Archivo_Ruta");
        }
    }
}
