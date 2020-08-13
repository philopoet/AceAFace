namespace Framework.Service
{
    public interface  IService<in TRequest,out TResponse>
    {
        TResponse Execute(TRequest request);
    }
}
