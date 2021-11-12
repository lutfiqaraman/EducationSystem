namespace EducationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnTypeOfFullPriceInCourseTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "FullPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "FullPrice", c => c.Single(nullable: false));
        }
    }
}
