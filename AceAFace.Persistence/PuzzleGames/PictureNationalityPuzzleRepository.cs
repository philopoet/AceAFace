using System;
using System.Collections.Generic;
using System.Linq;
using AceAFace.Domain;
using AceAFace.Domain.PuzzleGames;

namespace AceAFace.Persistence.PuzzleGames
{
    public class PictureNationalityPuzzleRepository : Repository<int, PictureNationalityPuzzle>, IPictureNationalityPuzzleRepository
    {
        public PictureNationalityPuzzleRepository(
            IAceAFaceUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<PictureNationalityPuzzle> GetPuzzlesByIds(List<int> ids)
        {
            return Query.Where(puzzle => ids.Contains(puzzle.Id));
        }
        protected override IEnumerable<string> GetIncludeExpressions()
        {
            return Enumerable.Empty<string>();

        }
    }
}
