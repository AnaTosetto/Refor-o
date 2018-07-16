namespace ProvaTDD.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProvaTDD_v1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TBEndereco", new[] { "Aluno_Id" });
            DropColumn("dbo.TBEndereco", "Id");
            RenameColumn(table: "dbo.TBEndereco", name: "Aluno_Id", newName: "Id");
            DropPrimaryKey("dbo.TBEndereco");
            AlterColumn("dbo.TBEndereco", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.TBEndereco", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TBEndereco", "Id");
            CreateIndex("dbo.TBEndereco", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TBEndereco", new[] { "Id" });
            DropPrimaryKey("dbo.TBEndereco");
            AlterColumn("dbo.TBEndereco", "Id", c => c.Int());
            AlterColumn("dbo.TBEndereco", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TBEndereco", "Id");
            RenameColumn(table: "dbo.TBEndereco", name: "Id", newName: "Aluno_Id");
            AddColumn("dbo.TBEndereco", "Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.TBEndereco", "Aluno_Id");
        }
    }
}
