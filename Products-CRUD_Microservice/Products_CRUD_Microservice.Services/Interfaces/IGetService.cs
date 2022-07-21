namespace Products_CRUD_Microservice.Services.Interfaces
{
    public interface IGetService<T>
    {
        T GetById(int id);
        T GetByName(string name);
    }
}
