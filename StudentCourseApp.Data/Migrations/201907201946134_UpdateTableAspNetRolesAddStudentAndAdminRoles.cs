namespace StudentCourseApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableAspNetRolesAddStudentAndAdminRoles : DbMigration
    {
        public override void Up()
        {
            Sql(
            @"
                INSERT INTO AspNetRoles
                VALUES
                (1, 'Admin'),
                (2, 'Student');
            ");

            Sql(
            @"
                INSERT INTO AspNetUserRoles
                VALUES
                ((SELECT Id FROM AspNetUsers WHERE UserName = 'admin@testsite.local'), 1);
            ");
        }
        
        public override void Down()
        {
            Sql(
                @"
                DELETE FROM AspNetUserRoles
                WHERE RoleId = 1;
            ");

            Sql(
                @"
                DELETE FROM AspNetRoles
                WHERE Id = 1
            ");
        }
    }
}
