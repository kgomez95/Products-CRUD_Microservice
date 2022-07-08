namespace Products_CRUD_Microservice.Repository.Interfaces
{
    public interface ICreateRepository<T>
    {
        T Create(T record);
    }
}
