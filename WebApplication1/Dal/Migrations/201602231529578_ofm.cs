namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ofm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oferta_Mercantil",
                c => new
                    {
                        ID_OFERTA = c.Int(nullable: false, identity: true),
                        N_OFM = c.String(),
                        FECHA_SUSCRIP_OFM = c.String(),
                        FECHA_INIC_OFM = c.String(),
                        VIGENCIA = c.Int(nullable: false),
                        TITULO_OFM = c.String(),
                        CONTRATISTA = c.Int(nullable: false),
                        OBJETO_OFM = c.String(),
                        LUGRA_EJECUCION_OFM = c.String(),
                        TIPO_MONEDA = c.String(),
                        VALOR_ESTIMAO_OFM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VALOR_REAL_OFM = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID_OFERTA);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Oferta_Mercantil");
        }
    }
}
