namespace ReforcoEF.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReforcoEF_v7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBMateria",
                c => new
                    {
                        IdMateria = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.IdMateria);
            
            CreateTable(
                "dbo.AlunoMateria",
                c => new
                    {
                        Aluno_Id = c.Int(nullable: false),
                        Materia_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Aluno_Id, t.Materia_Id })
                .ForeignKey("dbo.TBAluno", t => t.Aluno_Id, cascadeDelete: true)
                .ForeignKey("dbo.TBMateria", t => t.Materia_Id, cascadeDelete: true)
                .Index(t => t.Aluno_Id)
                .Index(t => t.Materia_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlunoMateria", "Materia_Id", "dbo.TBMateria");
            DropForeignKey("dbo.AlunoMateria", "Aluno_Id", "dbo.TBAluno");
            DropIndex("dbo.AlunoMateria", new[] { "Materia_Id" });
            DropIndex("dbo.AlunoMateria", new[] { "Aluno_Id" });
            DropTable("dbo.AlunoMateria");
            DropTable("dbo.TBMateria");
        }
    }
}
