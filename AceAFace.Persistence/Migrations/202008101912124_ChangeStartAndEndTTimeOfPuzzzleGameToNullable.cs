namespace AceAFace.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStartAndEndTTimeOfPuzzzleGameToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PuzzleGames", "StartTime", c => c.DateTime());
            AlterColumn("dbo.PuzzleGames", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PuzzleGames", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PuzzleGames", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
