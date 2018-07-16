namespace ReforcoEF.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReforcoEF_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBAluno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Endereco_Numero = c.Int(nullable: false),
                        Endereco_Rua = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TBAluno");
        }
    }
}
