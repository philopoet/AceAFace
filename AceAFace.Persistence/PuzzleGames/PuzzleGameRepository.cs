using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AceAFace.Domain;
using AceAFace.Domain.PuzzleGames;
using Framework.Domain;

namespace AceAFace.Persistence.PuzzleGames
{
    public class PuzzleGameRepository : Repository<Guid, PuzzleGame>, IPuzzleGameRepository
    {
        public PuzzleGameRepository(IAceAFaceUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IEnumerable<string> GetIncludeExpressions()
        {
            return Enumerable.Empty<string>();
        }
    }
}
