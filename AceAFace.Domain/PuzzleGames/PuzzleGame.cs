using System;
using System.Collections.Generic;
using AceAFace.Domain.Players;
using Framework.Domain;
using Framework.Game;

namespace AceAFace.Domain.PuzzleGames
{
    public class PuzzleGame: AggregateRoot<Guid, PuzzleGame>, IGame
    {
        private PuzzleGame()
        {
          
        }
        public PuzzleGame(PuzzleGameBoard board)
        {
            Id =  Guid.NewGuid();
            Board = board;
            CreationDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
            GameHistories = new List<PuzzleGameHistory>();
            PlayerHistories = new List<PlayerHistory>();
        }

       
        public virtual ICollection<PuzzleGameHistory> GameHistories { get;private set; }
        public virtual ICollection<PlayerHistory> PlayerHistories { get; private set; }
        public PuzzleGameBoard Board { get; set; }
        public DateTime? StartTime { get;  set; }
        public DateTime? EndTime { get;  set; }
    
    }
}
