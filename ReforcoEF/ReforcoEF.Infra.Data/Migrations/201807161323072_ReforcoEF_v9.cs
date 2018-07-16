namespace ReforcoEF.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReforcoEF_v9 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AlunoMateria", newName: "TBAlunoMateria");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TBAlunoMateria", newName: "AlunoMateria");
        }
    }
}
