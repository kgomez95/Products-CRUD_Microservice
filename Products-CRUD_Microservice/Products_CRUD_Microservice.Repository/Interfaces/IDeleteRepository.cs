namespace Products_CRUD_Microservice.Repository.Interfaces
{
    public interface IDeleteRepository<T>
    {
        bool Delete(int id);
    }
}
