using AceAFace.Application;
using AceAFace.Application.Contract.PuzzleGamesRequests;
using AceAFace.Application.Contract.PuzzleGamesResponse;
using AceAFace.Application.PuzzleGamesServices;
using AceAFace.Domain;
using AceAFace.Domain.PuzzleGames;
using AceAFace.Persistence.PuzzleGames;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Framework.Service;
using Pap.WebPushManagement.Infrastructure.Persistence;


namespace AceAFace.Configuration
{
    public class Registrar
    {
        public void Setup(IWindsorContainer container)
        {
            container.Register(Component.For<IService<CreatePicturePuzzleRequest, CreatePicturePuzzleResponse>>().ImplementedBy<CreatePicturePuzzleService>().LifestylePerWebRequest());
            container.Register(Component.For<IService<EvaluatePicturePuzzleAnswerRequest, EvaluatePicturePuzzleAnswerResponse>>().ImplementedBy<EvaluatePicturePuzzleAnswerService>().LifestylePerWebRequest());

            
            container.Register(Component.For<IAceAFaceUnitOfWork>().ImplementedBy<AceAFaceContext>().LifestylePerWebRequest());
            container.Register(Component.For<IPictureNationalityPuzzleRepository>().ImplementedBy<PictureNationalityPuzzleRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IPuzzleGameRepository> ().ImplementedBy<PuzzleGameRepository>().LifestylePerWebRequest());
        }
    }
}
