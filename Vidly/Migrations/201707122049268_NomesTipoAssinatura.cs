namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class NomesTipoAssinatura : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE TipoAssinaturas SET Nome = 'Avulso' WHERE Id = 1");
            Sql("UPDATE TipoAssinaturas SET Nome = 'Mensal' WHERE Id = 2");
            Sql("UPDATE TipoAssinaturas SET Nome = 'Trimestral' WHERE Id = 3");
            Sql("UPDATE TipoAssinaturas SET Nome = 'Anual' WHERE Id = 4");
        }

        public override void Down()
        {
        }
    }
}
