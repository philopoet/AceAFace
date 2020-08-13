using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AceAFace.Application.Contract.PuzzleGamesRequests;
using AceAFace.Application.Contract.PuzzleGamesResponse;
using AceAFace.Domain.PuzzleGames;
using Framework.Service;

namespace AceAFace.Application.PuzzleGamesServices
{
    public class EvaluatePicturePuzzleAnswerService: IService<EvaluatePicturePuzzleAnswerRequest, EvaluatePicturePuzzleAnswerResponse>
    {
        private readonly IPictureNationalityPuzzleRepository _pictureNationalityPuzzleRepository;

        public EvaluatePicturePuzzleAnswerService(
            IPictureNationalityPuzzleRepository pictureNationalityPuzzleRepository)
        {
            _pictureNationalityPuzzleRepository = pictureNationalityPuzzleRepository;
        }

        public EvaluatePicturePuzzleAnswerResponse Execute(EvaluatePicturePuzzleAnswerRequest request)
        {
            var pictureNationalityPuzzle =
                _pictureNationalityPuzzleRepository.Get(puzzle => puzzle.Id == request.PictureId);
            var result = pictureNationalityPuzzle.IsSolutionAccepted(new PictureNationalityPuzzleSolution()
            {
                Nationality = request.Nationality,
            });
            return new EvaluatePicturePuzzleAnswerResponse()
            {
                IsValid = result,
            };
        }
    }
}
