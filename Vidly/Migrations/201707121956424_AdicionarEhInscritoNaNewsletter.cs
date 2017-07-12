namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarEhInscritoNaNewsletter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "EhInscritoNaNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "EhInscritoNaNewsletter");
        }
    }
}
