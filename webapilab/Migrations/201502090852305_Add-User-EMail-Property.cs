namespace webapilab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserEMailProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "EMail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "EMail", c => c.String(maxLength: 256));
        }
    }
}
