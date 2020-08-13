using System;
using AceAFace.Domain.PuzzleGames;
using Framework.Domain;

namespace AceAFace.Domain.Players
{
    public class PlayerHistory: IdentifiedValueObject<Guid>
    {
        public Guid Id { get; set; }
        public Guid PuzzleGameId { get; set; }
        public Guid PlayerId { get; set; }

        public virtual PuzzleGame PuzzleGame { get; set; }
        public virtual PuzzleGamePlayer PuzzleGamePlayer { get; set; }
        public int Score { get; set; }
        public override Guid GetIdentity()
        {
            return Id;
        }
    }
}
