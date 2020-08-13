using System.Security.AccessControl;
using AceAFace.Common.EnumTypes;
using Framework.Domain;
using Framework.Game;

namespace AceAFace.Domain.PuzzleGames
{
    public class PictureNationalityPuzzleSolution : ValueObject<PictureNationalityPuzzleSolution>, IPuzzleSolution
    {
        public Nationality Nationality { get; set; }
        public override bool Equals(PictureNationalityPuzzleSolution other)
        {
            return Nationality.Equals(other.Nationality);
        }
    }
}
