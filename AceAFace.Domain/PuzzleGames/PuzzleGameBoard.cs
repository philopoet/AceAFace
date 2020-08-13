using System;
using System.Security.AccessControl;
using Framework.Domain;
using Framework.Game;

namespace AceAFace.Domain.PuzzleGames
{
    public class PuzzleGameBoard : ValueObject<PuzzleGameBoard>, IGameBoard
    {
       
        public override bool Equals(PuzzleGameBoard other)
        {
            return Height.Equals(other.Height) && Width.Equals(other.Width);
        }

        public int Height { get; set; }
        public int Width { get; set; }
    }
}
