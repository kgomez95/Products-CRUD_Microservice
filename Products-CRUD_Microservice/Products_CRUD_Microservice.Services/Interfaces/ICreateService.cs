namespace Products_CRUD_Microservice.Services.Interfaces
{
    public interface ICreateService<T>
    {
        T? Create(T recordDTO);
    }
}
