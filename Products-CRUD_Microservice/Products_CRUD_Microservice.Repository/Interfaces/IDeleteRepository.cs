namespace Products_CRUD_Microservice.Repository.Interfaces
{
    public interface IDeleteRepository<T>
    {
        /// <summary>
        /// Borra de base de datos el <typeparamref name="T"/> proporcionado por parámetros.
        /// </summary>
        /// <param name="id">Identificador del <typeparamref name="T"/> a borrar.</param>
        /// <returns>Retorna "true" si el <typeparamref name="T"/> se borra correctamente o "false" en caso de que no se pueda borrar.</returns>
        bool Delete(int id);
    }
}
