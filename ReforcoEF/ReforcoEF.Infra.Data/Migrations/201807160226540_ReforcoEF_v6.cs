namespace ReforcoEF.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReforcoEF_v6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TBResultado", "AlunoId", "dbo.TBAluno");
            AddForeignKey("dbo.TBResultado", "AlunoId", "dbo.TBAluno", "IdAluno", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBResultado", "AlunoId", "dbo.TBAluno");
            AddForeignKey("dbo.TBResultado", "AlunoId", "dbo.TBAluno", "IdAluno");
        }
    }
}
