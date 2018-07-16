namespace ReforcoEF.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReforcoEF_v3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Resultado", new[] { "Aluno_Id" });
            RenameColumn(table: "dbo.Resultado", name: "Aluno_Id", newName: "AlunoId");
            AlterColumn("dbo.Resultado", "AlunoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Resultado", "AlunoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Resultado", new[] { "AlunoId" });
            AlterColumn("dbo.Resultado", "AlunoId", c => c.Int());
            RenameColumn(table: "dbo.Resultado", name: "AlunoId", newName: "Aluno_Id");
            CreateIndex("dbo.Resultado", "Aluno_Id");
        }
    }
}
