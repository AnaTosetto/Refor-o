namespace ReforcoEF.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReforcoEF_v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resultado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nota = c.Double(nullable: false),
                        Aluno_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBAluno", t => t.Aluno_Id)
                .Index(t => t.Aluno_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resultado", "Aluno_Id", "dbo.TBAluno");
            DropIndex("dbo.Resultado", new[] { "Aluno_Id" });
            DropTable("dbo.Resultado");
        }
    }
}
