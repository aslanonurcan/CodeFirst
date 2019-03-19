namespace CodeFirstStudentClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YasEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ogrenci", "Yas", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ogrenci", "Yas");
        }
    }
}
