namespace StudentCourseApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableAspNetUsersAddAdminUser : DbMigration
    {
        public override void Up()
        {
            var guid = Guid.NewGuid().ToString();
            Sql(
                $@"
                  INSERT INTO [StudentEnrollDb].[dbo].[AspNetUsers]
                  VALUES(
	                   '{guid}'
                      ,'admin@testsite.local'
                      ,1
                      ,'APmXEuDTQ0y33+42sVTgS+cwqHoiRXbWmklN9LrwFmChOKBBqcJhckvkHn7nxe0/1A=='
                      ,'816f6343-9622-4ab0-9ad3-1342466c17ac'
                      ,null
                      ,0
                      ,0
                      ,null
                      ,1
                      ,0
                      ,'admin@testsite.local'
                      ,null
                  );"
                );
        }
        
        public override void Down()
        {
            Sql(@"
                DELETE FROM [StudentEnrollDb].[dbo].[AspNetUsers]
                WHERE username = 'admin@testsite.local'
            ");
        }
    }
}
