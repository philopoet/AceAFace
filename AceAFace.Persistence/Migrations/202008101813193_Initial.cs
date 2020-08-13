namespace AceAFace.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PictureNationalityPuzzles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PictureUrl = c.String(),
                        Nationality = c.Byte(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PuzzleGameHistories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PuzzleGameId = c.Guid(nullable: false),
                        PictureNationalityPuzzleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PictureNationalityPuzzles", t => t.PictureNationalityPuzzleId, cascadeDelete: true)
                .ForeignKey("dbo.PuzzleGames", t => t.PuzzleGameId, cascadeDelete: true)
                .Index(t => t.PuzzleGameId)
                .Index(t => t.PictureNationalityPuzzleId);
            
            CreateTable(
                "dbo.PuzzleGames",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PuzzleGameBoardHeight = c.Int(nullable: false),
                        PuzzleGameBoardWidth = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayerHistories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PuzzleGameId = c.Guid(nullable: false),
                        PlayerId = c.Guid(nullable: false),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PuzzleGames", t => t.PuzzleGameId, cascadeDelete: true)
                .ForeignKey("dbo.PuzzleGamePlayers", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PuzzleGameId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.PuzzleGamePlayers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PuzzleGameHistories", "PuzzleGameId", "dbo.PuzzleGames");
            DropForeignKey("dbo.PlayerHistories", "PlayerId", "dbo.PuzzleGamePlayers");
            DropForeignKey("dbo.PlayerHistories", "PuzzleGameId", "dbo.PuzzleGames");
            DropForeignKey("dbo.PuzzleGameHistories", "PictureNationalityPuzzleId", "dbo.PictureNationalityPuzzles");
            DropIndex("dbo.PlayerHistories", new[] { "PlayerId" });
            DropIndex("dbo.PlayerHistories", new[] { "PuzzleGameId" });
            DropIndex("dbo.PuzzleGameHistories", new[] { "PictureNationalityPuzzleId" });
            DropIndex("dbo.PuzzleGameHistories", new[] { "PuzzleGameId" });
            DropTable("dbo.PuzzleGamePlayers");
            DropTable("dbo.PlayerHistories");
            DropTable("dbo.PuzzleGames");
            DropTable("dbo.PuzzleGameHistories");
            DropTable("dbo.PictureNationalityPuzzles");
        }
    }
}
