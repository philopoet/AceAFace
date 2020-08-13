using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AceAFace.Domain.PuzzleGames
{
    public interface IPictureNationalityPuzzleRepository
    {
        IEnumerable<PictureNationalityPuzzle> GetPuzzlesByIds(List<int> ids);
        PictureNationalityPuzzle Get(Expression<Func<PictureNationalityPuzzle, bool>> predicate);
    }
}
