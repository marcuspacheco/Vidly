namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarCamposFilme1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Filmes", name: "Genero_Id", newName: "GeneroId");
            RenameIndex(table: "dbo.Filmes", name: "IX_Genero_Id", newName: "IX_GeneroId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Filmes", name: "IX_GeneroId", newName: "IX_Genero_Id");
            RenameColumn(table: "dbo.Filmes", name: "GeneroId", newName: "Genero_Id");
        }
    }
}
