namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopularTipoAssinatura : DbMigration
    {
        public override void Up()
        {
            RenameTable("TipoAssinaturas", "TipoAssinatura");
            AddColumn("dbo.TipoAssinatura", "PorcentagemDesconto", c => c.Byte(nullable: false));
            DropColumn("dbo.TipoAssinatura", "PorcentagemDisconto");
            Sql("INSERT INTO TipoAssinatura (Id, ValorInicial, DuracaoEmMeses, PorcentagemDesconto) VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO TipoAssinatura (Id, ValorInicial, DuracaoEmMeses, PorcentagemDesconto) VALUES (2, 30, 1, 10)");
            Sql("INSERT INTO TipoAssinatura (Id, ValorInicial, DuracaoEmMeses, PorcentagemDesconto) VALUES (3, 90, 3, 15)");
            Sql("INSERT INTO TipoAssinatura (Id, ValorInicial, DuracaoEmMeses, PorcentagemDesconto) VALUES (4, 300, 12, 20)");
        }

        public override void Down()
        {
            AddColumn("dbo.TipoAssinatura", "PorcentagemDisconto", c => c.Byte(nullable: false));
            DropColumn("dbo.TipoAssinatura", "PorcentagemDesconto");
            Sql("DELETE FROM TipoAssinatura");
        }
    }
}
