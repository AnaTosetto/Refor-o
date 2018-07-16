namespace ReforcoEF.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReforcoEF_v5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TBAluno", name: "Id", newName: "IdAluno");
            RenameColumn(table: "dbo.TBResultado", name: "Id", newName: "IdResultado");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.TBResultado", name: "IdResultado", newName: "Id");
            RenameColumn(table: "dbo.TBAluno", name: "IdAluno", newName: "Id");
        }
    }
}
