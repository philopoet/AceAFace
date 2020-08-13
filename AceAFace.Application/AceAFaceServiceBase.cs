
using AceAFace.Application.Contract;
using AceAFace.Domain;
using Framework.Persistence;
using Framework.Service;


namespace AceAFace.Application
{
    public abstract class AceAFaceServiceBase<TRequest, TResponse>  : IService<TRequest, TResponse>
        where TRequest :IRequest
    where TResponse : IResponse

    {
        protected AceAFaceServiceBase(IAceAFaceUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        protected readonly IRepository Repository;
        protected readonly IAceAFaceUnitOfWork UnitOfWork;

        public abstract TResponse Execute(TRequest request);
    }
}
