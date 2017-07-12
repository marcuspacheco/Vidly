namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AdicionarCamposFilme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Generoes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false, maxLength: 255),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Filmes", "DataDeLancamento", c => c.DateTime(nullable: false));
            AddColumn("dbo.Filmes", "DataAdicionado", c => c.DateTime(nullable: false));
            AddColumn("dbo.Filmes", "NumeroEmEstoque", c => c.Int(nullable: false));
            AddColumn("dbo.Filmes", "Genero_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Filmes", "Nome", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Filmes", "Genero_Id");
            AddForeignKey("dbo.Filmes", "Genero_Id", "dbo.Generoes", "Id", cascadeDelete: true);
            Sql("INSERT INTO Generoes (Nome) VALUES ('Comédia'), ('Ação'), ('Família'), ('Romance')");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Filmes", "Genero_Id", "dbo.Generoes");
            DropIndex("dbo.Filmes", new[] { "Genero_Id" });
            AlterColumn("dbo.Filmes", "Nome", c => c.String());
            DropColumn("dbo.Filmes", "Genero_Id");
            DropColumn("dbo.Filmes", "NumeroEmEstoque");
            DropColumn("dbo.Filmes", "DataAdicionado");
            DropColumn("dbo.Filmes", "DataDeLancamento");
            DropTable("dbo.Generoes");
        }
    }
}
