namespace Products_CRUD_Microservice.Repository.Interfaces
{
    public interface IUpdateRepository<T>
    {
        T? Update(T entity);
    }
}
