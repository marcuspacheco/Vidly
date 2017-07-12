namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarTipoAssinatura : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoAssinaturas",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        ValorInicial = c.Short(nullable: false),
                        DuracaoEmMeses = c.Byte(nullable: false),
                        PorcentagemDisconto = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clientes", "TipoAssinaturaId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Clientes", "TipoAssinaturaId");
            AddForeignKey("dbo.Clientes", "TipoAssinaturaId", "dbo.TipoAssinaturas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "TipoAssinaturaId", "dbo.TipoAssinaturas");
            DropIndex("dbo.Clientes", new[] { "TipoAssinaturaId" });
            DropColumn("dbo.Clientes", "TipoAssinaturaId");
            DropTable("dbo.TipoAssinaturas");
        }
    }
}
