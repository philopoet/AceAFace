using System.Data;
using System.Data.Entity;
using AceAFace.Domain;
using AceAFace.Domain.Players;
using AceAFace.Domain.PuzzleGames;
using AceAFace.Persistence;


namespace Pap.WebPushManagement.Infrastructure.Persistence
{
    public class AceAFaceContext : DbContext, IAceAFaceUnitOfWork
    {
        public AceAFaceContext() : base("name=AceAFaceEntities")
        {
            Database.Log = (x)=> System.Diagnostics.Debug.Write(x);
        }
        public virtual DbSet<PuzzleGame> PuzzleGames { get; set; }
        public virtual DbSet<PuzzleGamePlayer> PuzzleGamePlayers { get; set; }
        public virtual DbSet<PlayerHistory> PlayerHistories { get; set; }
        public virtual DbSet<PictureNationalityPuzzle> PictureNationalityPuzzles { get; set; }
        public void Commit()
        {
            ChangeTracker.DetectChanges();
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Add(new NonPublicColumnAttributeConvention());
            modelBuilder.Entity<PuzzleGame>().Property(x => x.Board.Height).HasColumnName("PuzzleGameBoardHeight");
            modelBuilder.Entity<PuzzleGame>().Property(x => x.Board.Width).HasColumnName("PuzzleGameBoardWidth");
            modelBuilder.Entity<PuzzleGameHistory>()
                .HasRequired(x => x.PuzzleGame)
                .WithMany(x => x.GameHistories)
                .HasForeignKey(x => x.PuzzleGameId);
            modelBuilder.Entity<PuzzleGameHistory>()
                .HasRequired(x => x.PictureNationalityPuzzles)
                .WithMany(x => x.Histories)
                .HasForeignKey(x => x.PictureNationalityPuzzleId);
            modelBuilder.Entity<PlayerHistory>()
                .HasRequired(x => x.PuzzleGame)
                .WithMany(x => x.PlayerHistories)
                .HasForeignKey(x => x.PuzzleGameId);
            modelBuilder.Entity<PlayerHistory>()
                .HasRequired(x => x.PuzzleGamePlayer)
                .WithMany(x => x.Histories)
                .HasForeignKey(x => x.PlayerId);
         


        }
    }
}
