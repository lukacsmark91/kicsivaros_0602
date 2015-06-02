namespace kicsivaros_0602.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Egysegs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EgysegNev = c.Int(nullable: false),
                        Tamadoero = c.Int(),
                        Vedekezoero = c.Int(),
                        Ar = c.Int(),
                        Zsold = c.Int(),
                        Ellatmanyigeny = c.Int(),
                        Termeles = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrszagEgysegs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrszagId = c.Int(nullable: false),
                        EgysegId = c.Int(nullable: false),
                        Darab = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Egysegs", t => t.EgysegId, cascadeDelete: true)
                .ForeignKey("dbo.Orszags", t => t.OrszagId, cascadeDelete: true)
                .Index(t => t.OrszagId)
                .Index(t => t.EgysegId);
            
            CreateTable(
                "dbo.Orszags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                        Pontszam = c.Int(nullable: false),
                        Idos = c.Int(nullable: false),
                        Arany = c.Int(nullable: false),
                        Krumpli = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrszagEpulets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrszagId = c.Int(nullable: false),
                        EpuletId = c.Int(nullable: false),
                        Darab = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Epulets", t => t.EpuletId, cascadeDelete: true)
                .ForeignKey("dbo.Orszags", t => t.OrszagId, cascadeDelete: true)
                .Index(t => t.OrszagId)
                .Index(t => t.EpuletId);
            
            CreateTable(
                "dbo.Epulets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EpuletNev = c.Int(nullable: false),
                        Szallas = c.Int(),
                        Nepesseg = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrszagFejlesztes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FejlesztesNev = c.Int(nullable: false),
                        allapot = c.Int(nullable: false),
                        Orszag_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orszags", t => t.Orszag_Id)
                .Index(t => t.Orszag_Id);
            
            CreateTable(
                "dbo.OrszagTulajdonsags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TulajdonsagNev = c.Int(nullable: false),
                        Sebesseg = c.Int(nullable: false),
                        Orszag_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orszags", t => t.Orszag_Id)
                .Index(t => t.Orszag_Id);
            
            CreateTable(
                "dbo.Harcs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GyoztesOrszag_Id = c.Int(),
                        Kor_Id = c.Int(),
                        TamadoOrszag_Id = c.Int(),
                        VedoOrszag_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orszags", t => t.GyoztesOrszag_Id)
                .ForeignKey("dbo.Kors", t => t.Kor_Id)
                .ForeignKey("dbo.Orszags", t => t.TamadoOrszag_Id)
                .ForeignKey("dbo.Orszags", t => t.VedoOrszag_Id)
                .Index(t => t.GyoztesOrszag_Id)
                .Index(t => t.Kor_Id)
                .Index(t => t.TamadoOrszag_Id)
                .Index(t => t.VedoOrszag_Id);
            
            CreateTable(
                "dbo.Kors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Szamlalo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Harcs", "VedoOrszag_Id", "dbo.Orszags");
            DropForeignKey("dbo.Harcs", "TamadoOrszag_Id", "dbo.Orszags");
            DropForeignKey("dbo.Harcs", "Kor_Id", "dbo.Kors");
            DropForeignKey("dbo.Harcs", "GyoztesOrszag_Id", "dbo.Orszags");
            DropForeignKey("dbo.OrszagTulajdonsags", "Orszag_Id", "dbo.Orszags");
            DropForeignKey("dbo.OrszagFejlesztes", "Orszag_Id", "dbo.Orszags");
            DropForeignKey("dbo.OrszagEpulets", "OrszagId", "dbo.Orszags");
            DropForeignKey("dbo.OrszagEpulets", "EpuletId", "dbo.Epulets");
            DropForeignKey("dbo.OrszagEgysegs", "OrszagId", "dbo.Orszags");
            DropForeignKey("dbo.OrszagEgysegs", "EgysegId", "dbo.Egysegs");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Harcs", new[] { "VedoOrszag_Id" });
            DropIndex("dbo.Harcs", new[] { "TamadoOrszag_Id" });
            DropIndex("dbo.Harcs", new[] { "Kor_Id" });
            DropIndex("dbo.Harcs", new[] { "GyoztesOrszag_Id" });
            DropIndex("dbo.OrszagTulajdonsags", new[] { "Orszag_Id" });
            DropIndex("dbo.OrszagFejlesztes", new[] { "Orszag_Id" });
            DropIndex("dbo.OrszagEpulets", new[] { "EpuletId" });
            DropIndex("dbo.OrszagEpulets", new[] { "OrszagId" });
            DropIndex("dbo.OrszagEgysegs", new[] { "EgysegId" });
            DropIndex("dbo.OrszagEgysegs", new[] { "OrszagId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Kors");
            DropTable("dbo.Harcs");
            DropTable("dbo.OrszagTulajdonsags");
            DropTable("dbo.OrszagFejlesztes");
            DropTable("dbo.Epulets");
            DropTable("dbo.OrszagEpulets");
            DropTable("dbo.Orszags");
            DropTable("dbo.OrszagEgysegs");
            DropTable("dbo.Egysegs");
        }
    }
}
