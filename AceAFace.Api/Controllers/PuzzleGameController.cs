using System.Web.Http;
using AceAFace.Application.Contract.PuzzleGamesRequests;
using AceAFace.Application.Contract.PuzzleGamesResponse;
using Framework.Service;

namespace AceAFace.Api.Controllers
{
    [RoutePrefix("api/AceAFace/PuzzleGames")]
    public class PuzzleGameController : ApiController
    {
        private readonly IService<CreatePicturePuzzleRequest, CreatePicturePuzzleResponse> _createPicturePuzzleService;

        private readonly IService<EvaluatePicturePuzzleAnswerRequest, EvaluatePicturePuzzleAnswerResponse> _evaluatePicturePuzzleService;
        public PuzzleGameController(
           IService<CreatePicturePuzzleRequest, CreatePicturePuzzleResponse> createPicturePuzzleService, 
           IService<EvaluatePicturePuzzleAnswerRequest, EvaluatePicturePuzzleAnswerResponse> evaluatePicturePuzzleService)
        {
            _createPicturePuzzleService = createPicturePuzzleService;
            _evaluatePicturePuzzleService = evaluatePicturePuzzleService;
        }
        [HttpGet]
        [Route("EvaluateAnswer")]
        public IHttpActionResult EvaluatePicturePuzzleAnswer([FromUri]EvaluatePicturePuzzleAnswerRequest request)
        {
            var response = _evaluatePicturePuzzleService.Execute(request);
            return Ok(response);
        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreatePicturePuzzle(CreatePicturePuzzleRequest request)
        {
           var response =  _createPicturePuzzleService.Execute(request);
           return Ok(response);
        }

    }
}
