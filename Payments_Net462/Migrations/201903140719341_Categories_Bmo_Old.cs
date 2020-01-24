namespace Payments_Net462.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Categories_Bmo_Old : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories(\"Name\", \"IsActive\") VALUES('BMO', 'true'), ('OLD', 'true'); ");
        }

        public override void Down()
        {
        }
    }
}
