namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Polizas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Polizas",
                c => new
                    {
                        NO_POLIZAS = c.Int(nullable: false, identity: true),
                        FECHA_INI_POL = c.String(),
                        FECHA_FINAL_POL = c.String(),
                        ASEGURADORA = c.String(),
                        VALOR_POLIZA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TIPO_POLIZA = c.String(),
                        VALOR_ASEGURADO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OFERTAMERCANTIL = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NO_POLIZAS);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Polizas");
        }
    }
}
