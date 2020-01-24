namespace Payments_Net462.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Payments",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    PayDate = c.DateTime(nullable: false),
                    Amount = c.Int(nullable: false),
                    Description = c.String(nullable: false),
                    CatogoryId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CatogoryId, cascadeDelete: true)
                .Index(t => t.CatogoryId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Payments", "CatogoryId", "dbo.Categories");
            DropIndex("dbo.Payments", new[] { "CatogoryId" });
            DropTable("dbo.Payments");
            DropTable("dbo.Categories");
        }
    }
}
