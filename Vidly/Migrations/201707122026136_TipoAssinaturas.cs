namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class TipoAssinaturas : DbMigration
    {
        public override void Up()
        {
            RenameTable("TipoAssinatura", "TipoAssinaturas");
        }

        public override void Down()
        {
        }
    }
}
