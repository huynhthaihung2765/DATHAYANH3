namespace WebDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Hoten", c => c.String());
            AddColumn("dbo.AspNetUsers", "Diachi", c => c.String());
            AddColumn("dbo.AspNetUsers", "Tuoi", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Gioitinh", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Gioitinh");
            DropColumn("dbo.AspNetUsers", "Tuoi");
            DropColumn("dbo.AspNetUsers", "Diachi");
            DropColumn("dbo.AspNetUsers", "Hoten");
        }
    }
}
