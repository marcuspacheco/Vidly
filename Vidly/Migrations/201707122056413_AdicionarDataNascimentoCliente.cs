namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarDataNascimentoCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "DataNascimento", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "DataNascimento");
        }
    }
}
