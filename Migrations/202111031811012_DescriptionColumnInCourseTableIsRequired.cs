﻿namespace EducationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionColumnInCourseTableIsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Description", c => c.String());
        }
    }
}
