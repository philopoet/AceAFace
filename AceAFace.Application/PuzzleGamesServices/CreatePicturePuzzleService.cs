using System;
using System.Collections.Generic;
using AceAFace.Application.Contract.PuzzleGamesRequests;
using AceAFace.Application.Contract.PuzzleGamesResponse;
using AceAFace.Domain;
using AceAFace.Domain.PuzzleGames;

namespace AceAFace.Application.PuzzleGamesServices
{
    public class CreatePicturePuzzleService: AceAFaceServiceBase<CreatePicturePuzzleRequest, CreatePicturePuzzleResponse>
    {
        private readonly IPictureNationalityPuzzleRepository _pictureNationalityPuzzleRepository;
        private readonly IPuzzleGameRepository _puzzleGameRepository;
        public CreatePicturePuzzleService(
            IPictureNationalityPuzzleRepository pictureNationalityPuzzleRepository,
            IAceAFaceUnitOfWork unitOfWork, 
            IPuzzleGameRepository puzzleGameRepository) : base(unitOfWork)
        {
            _pictureNationalityPuzzleRepository = pictureNationalityPuzzleRepository;
            _puzzleGameRepository = puzzleGameRepository;
        }

        public override CreatePicturePuzzleResponse Execute(CreatePicturePuzzleRequest request)
        {
            var puzzleGame = new PuzzleGame(new PuzzleGameBoard()
            {
                Height = request.BoardGameHeight,
                Width = request.BoardGameWidth,
            });
            Random rnd = new Random();
            var randomIds = new List<int>();
            
            for (int i = 0; i < request.NumberOfPuzzles; i++)
            {
                // Number 21 for now is hardcoded it should be moved to a setting file
                var randomNumber = rnd.Next(1, 22);
                while (randomIds.Contains(randomNumber))
                {
                    randomNumber = rnd.Next(1, 22);
                }
                randomIds.Add(randomNumber); 
            }

            var pictureNationalityPuzzles = _pictureNationalityPuzzleRepository.GetPuzzlesByIds(randomIds);
            var response = new CreatePicturePuzzleResponse();
            foreach (var puzzle in pictureNationalityPuzzles)
            {
                puzzleGame.GameHistories.Add(new PuzzleGameHistory()
                    {
                        Id = Guid.NewGuid(),
                        PictureNationalityPuzzleId = puzzle.Id,
                        PuzzleGameId = puzzleGame.Id,
                    });
                  response.PicturePuzzleResponses.Add(new PicturePuzzleResponse()
                  {
                      PictureId = puzzle.Id ,
                      PictureUrl = puzzle.PictureUrl,
                          
                  });  
            }
            _puzzleGameRepository.Create(puzzleGame);
            UnitOfWork.Commit();
            return response;
        }
    }
}
