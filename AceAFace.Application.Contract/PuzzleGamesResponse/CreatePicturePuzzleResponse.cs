using System.Collections.Generic;

namespace AceAFace.Application.Contract.PuzzleGamesResponse
{
    public class CreatePicturePuzzleResponse: IResponse
    {
        public CreatePicturePuzzleResponse()
        {
            PicturePuzzleResponses = new List<PicturePuzzleResponse>();
        }
        public List<PicturePuzzleResponse> PicturePuzzleResponses { get; set; }
    }
}
