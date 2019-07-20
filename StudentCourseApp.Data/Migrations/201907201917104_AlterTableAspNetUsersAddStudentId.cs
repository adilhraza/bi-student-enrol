namespace StudentCourseApp.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableAspNetUsersAddStudentId : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"
                ALTER TABLE AspNetUsers
                ADD StudentId int NULL,
                CONSTRAINT FK_AspNetUsers_StudentId FOREIGN KEY(StudentId) REFERENCES Students(StudentId); "
            );
        }

        public override void Down()
        {
            Sql(
                @"
	            ALTER TABLE AspNetUsers
		        DROP
		        CONSTRAINT FK_AspNetUsers_StudentId,
		        COLUMN StudentId;
                "
            );
        }
    }
}
