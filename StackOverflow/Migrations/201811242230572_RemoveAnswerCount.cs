namespace StackOverflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAnswerCount : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "AnswerCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "AnswerCount", c => c.Int(nullable: false));
        }
    }
}
