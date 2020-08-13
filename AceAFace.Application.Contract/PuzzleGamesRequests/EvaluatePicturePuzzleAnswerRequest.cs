using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AceAFace.Common.EnumTypes;

namespace AceAFace.Application.Contract.PuzzleGamesRequests
{
    public class EvaluatePicturePuzzleAnswerRequest: IRequest
    {
        public Nationality Nationality { get; set; }
        public int PictureId { get; set; }
    }
}
