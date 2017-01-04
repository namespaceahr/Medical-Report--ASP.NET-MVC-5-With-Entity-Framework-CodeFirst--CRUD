namespace DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        patientId = c.Int(nullable: false, identity: true),
                        patientName = c.String(nullable: false, maxLength: 50),
                        patientAddress = c.String(nullable: false, maxLength: 50),
                        Report_reportId = c.Int(),
                    })
                .PrimaryKey(t => t.patientId)
                .ForeignKey("dbo.Reports", t => t.Report_reportId)
                .Index(t => t.Report_reportId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        reportId = c.Int(nullable: false, identity: true),
                        reportType = c.String(nullable: false),
                        reportDescription = c.String(nullable: false),
                        patientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.reportId)
                .ForeignKey("dbo.Patients", t => t.patientId, cascadeDelete: true)
                .Index(t => t.patientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "Report_reportId", "dbo.Reports");
            DropForeignKey("dbo.Reports", "patientId", "dbo.Patients");
            DropIndex("dbo.Reports", new[] { "patientId" });
            DropIndex("dbo.Patients", new[] { "Report_reportId" });
            DropTable("dbo.Reports");
            DropTable("dbo.Patients");
        }
    }
}
