namespace ReforcoEF.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReforcoEF_v8 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AlunoMateria", name: "Aluno_Id", newName: "AlunoId");
            RenameColumn(table: "dbo.AlunoMateria", name: "Materia_Id", newName: "MateriaId");
            RenameIndex(table: "dbo.AlunoMateria", name: "IX_Aluno_Id", newName: "IX_AlunoId");
            RenameIndex(table: "dbo.AlunoMateria", name: "IX_Materia_Id", newName: "IX_MateriaId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AlunoMateria", name: "IX_MateriaId", newName: "IX_Materia_Id");
            RenameIndex(table: "dbo.AlunoMateria", name: "IX_AlunoId", newName: "IX_Aluno_Id");
            RenameColumn(table: "dbo.AlunoMateria", name: "MateriaId", newName: "Materia_Id");
            RenameColumn(table: "dbo.AlunoMateria", name: "AlunoId", newName: "Aluno_Id");
        }
    }
}
