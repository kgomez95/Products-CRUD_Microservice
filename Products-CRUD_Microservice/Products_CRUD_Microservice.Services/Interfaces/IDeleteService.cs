namespace Products_CRUD_Microservice.Services.Interfaces
{
    public interface IDeleteService<T>
    {
        /// <summary>
        /// Llama al repositorio para borrar un <typeparamref name="T"/>.
        /// </summary>
        /// <param name="id">Identificador del <typeparamref name="T"/>.</param>
        void Delete(int id);
    }
}
