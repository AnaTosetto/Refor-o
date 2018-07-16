namespace ReforcoEF.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReforcoEF_v4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Resultado", newName: "TBResultado");
            DropForeignKey("dbo.Resultado", "AlunoId", "dbo.TBAluno");
            AddColumn("dbo.TBResultado", "Aluno_Id", c => c.Int());
            CreateIndex("dbo.TBResultado", "Aluno_Id");
            AddForeignKey("dbo.TBResultado", "Aluno_Id", "dbo.TBAluno", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBResultado", "Aluno_Id", "dbo.TBAluno");
            DropIndex("dbo.TBResultado", new[] { "Aluno_Id" });
            DropColumn("dbo.TBResultado", "Aluno_Id");
            AddForeignKey("dbo.Resultado", "AlunoId", "dbo.TBAluno", "Id");
            RenameTable(name: "dbo.TBResultado", newName: "Resultado");
        }
    }
}
