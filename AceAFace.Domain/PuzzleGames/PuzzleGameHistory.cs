using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;

namespace AceAFace.Domain.PuzzleGames
{
    public class PuzzleGameHistory: IdentifiedValueObject<Guid>
    {
        public Guid Id { get; set; }
        public Guid PuzzleGameId { get; set; }
        public int PictureNationalityPuzzleId { get; set; }
        public virtual PuzzleGame PuzzleGame { get; set; }
        public virtual PictureNationalityPuzzle PictureNationalityPuzzles { get; set; }
        public override Guid GetIdentity()
        {
            throw new NotImplementedException();
        }
    }
}
