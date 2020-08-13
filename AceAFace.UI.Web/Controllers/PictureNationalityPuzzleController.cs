using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using AceAFace.Application.Contract.PuzzleGamesRequests;
using AceAFace.Application.Contract.PuzzleGamesResponse;
using AceAFace.UI.Web.Infrastructure;

namespace AceAFace.UI.Web.Controllers
{
    public class PictureNationalityPuzzleController : Controller
    {
        private readonly HttpApiClient _apiClient;

        private readonly string _aceAFaceApiUrl;

        public PictureNationalityPuzzleController()
        {
            _apiClient = new HttpApiClient();
            _aceAFaceApiUrl = WebConfigurationManager.AppSettings["AceAFaceApiUrl"];
        }

        // GET: PictureNationalityPuzzle
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CreatePicturePuzzle()
        {
            var createPicturePuzzleRequest = new CreatePicturePuzzleRequest()
            {
                BoardGameWidth = 500,
                BoardGameHeight = 1000,
                NumberOfPuzzles = 10,
            };
            var apiClient = new HttpApiClient();
            try
            {
                var responseData = apiClient.Post<CreatePicturePuzzleResponse>($"{_aceAFaceApiUrl}/PuzzleGames", createPicturePuzzleRequest);

                return Json(new { success = true, responseData = responseData.PicturePuzzleResponses }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult EvaluateAnswer(EvaluatePicturePuzzleAnswerRequest request)
        {
            
            var apiClient = new HttpApiClient();
            try
            {
                var responseData = apiClient.Get<EvaluatePicturePuzzleAnswerResponse>($"{_aceAFaceApiUrl}/PuzzleGames/EvaluateAnswer", request);

                return Json(new { success = true, answerIsValid = responseData.IsValid }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}