namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilmeByte : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Filmes", "NumeroEmEstoque", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Filmes", "NumeroEmEstoque", c => c.Int(nullable: false));
        }
    }
}
