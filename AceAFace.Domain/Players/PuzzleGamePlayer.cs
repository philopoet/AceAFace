using System;
using System.Collections.Generic;
using System.Linq;
using AceAFace.Domain.PuzzleGames;
using Framework.Domain;
using Framework.Game;

namespace AceAFace.Domain.Players
{
    public class PuzzleGamePlayer : AggregateRoot<Guid, PuzzleGamePlayer>, IGamePlayer
    {
        public PuzzleGamePlayer()
        {
            Histories = new List<PlayerHistory>();
        }

        public int Score => Histories.Sum(h => h.Score);

        public void Played(IGame game, int score)
        {
            Histories.Add(new PlayerHistory()
            {
                PlayerId = Id,
                PuzzleGameId = game.Id,
                Score = score,
            });
        }

        public virtual ICollection<PlayerHistory> Histories { get;private set; }
    }
}
