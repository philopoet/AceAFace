namespace AceAFace.Application.Contract.PuzzleGamesRequests
{
    public class CreatePicturePuzzleRequest: IRequest
    {
        public int BoardGameHeight { get; set; }
        public int BoardGameWidth { get; set; }
        public int NumberOfPuzzles { get; set; }
    }
}
