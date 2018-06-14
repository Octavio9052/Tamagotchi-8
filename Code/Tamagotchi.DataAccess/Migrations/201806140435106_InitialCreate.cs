namespace Tamagotchi.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IdleUri = c.String(),
                        PlayUri = c.String(),
                        EatUri = c.String(),
                        SleepUri = c.String(),
                        PacketUri = c.String(),
                        TimesDownloaded = c.Int(nullable: false),
                        IsReady = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        UserId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhotoUri = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 150),
                        Password = c.String(nullable: false),
                        UserId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.Email, unique: true, name: "Index_Email")
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Guid = c.Guid(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        UserId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Guid, unique: true, name: "Index_Guid");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Animals", "UserId", "dbo.Users");
            DropIndex("dbo.Sessions", "Index_Guid");
            DropIndex("dbo.Logins", new[] { "UserId" });
            DropIndex("dbo.Logins", "Index_Email");
            DropIndex("dbo.Animals", new[] { "UserId" });
            DropTable("dbo.Sessions");
            DropTable("dbo.Logins");
            DropTable("dbo.Users");
            DropTable("dbo.Animals");
        }
    }
}
