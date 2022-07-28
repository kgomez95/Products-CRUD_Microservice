using Products_CRUD_Microservice.Utils;

namespace Products_CRUD_Microservice.Repository.Interfaces
{
    public interface IGetRepository<T>
    {
        T? GetById(int id);
        T? GetByName(string name);
    }
}
