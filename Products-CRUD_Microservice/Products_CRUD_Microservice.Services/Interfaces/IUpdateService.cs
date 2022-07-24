namespace Products_CRUD_Microservice.Services.Interfaces
{
    public interface IUpdateService<T>
    {
        T Update(T entity);
    }
}
