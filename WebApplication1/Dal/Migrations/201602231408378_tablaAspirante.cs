namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablaAspirante : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspiranteProcesoes",
                c => new
                    {
                        ID_ASPIRANTEPROCESO = c.Int(nullable: false, identity: true),
                        ID_ASPIRANTE = c.Int(nullable: false),
                        ID_PROCESO = c.Int(nullable: false),
                        RUTA = c.String(),
                    })
                .PrimaryKey(t => t.ID_ASPIRANTEPROCESO)
                .ForeignKey("dbo.Aspirantes", t => t.ID_ASPIRANTE, cascadeDelete: true)
                .Index(t => t.ID_ASPIRANTE);
            
            CreateTable(
                "dbo.Aspirantes",
                c => new
                    {
                        ASPIRANTE_ID = c.Int(nullable: false, identity: true),
                        NIT_CEDULA = c.String(),
                        NOM_RAZONSOCIAL = c.String(),
                        CORREO = c.String(),
                        DIRECCION = c.String(),
                        CIUDAD = c.String(),
                        DEPARTAMENTO = c.String(),
                        TELEFONO = c.String(),
                    })
                .PrimaryKey(t => t.ASPIRANTE_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspiranteProcesoes", "ID_ASPIRANTE", "dbo.Aspirantes");
            DropIndex("dbo.AspiranteProcesoes", new[] { "ID_ASPIRANTE" });
            DropTable("dbo.Aspirantes");
            DropTable("dbo.AspiranteProcesoes");
        }
    }
}
