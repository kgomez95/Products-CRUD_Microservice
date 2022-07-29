namespace Products_CRUD_Microservice.Repository.Interfaces
{
    public interface IGetRepository<T>
    {
        /// <summary>
        /// Obtiene un <typeparamref name="T"/> mediante su identificador.
        /// </summary>
        /// <param name="id">Identificador del <typeparamref name="T"/> a buscar.</param>
        /// <returns>Retorna un <typeparamref name="T"/> o NULL en caso de que no exista.</returns>
        T? GetById(int id);
        /// <summary>
        /// Obtiene un <typeparamref name="T"/> mediante su nombre.
        /// </summary>
        /// <param name="id">Nombre del <typeparamref name="T"/> a buscar.</param>
        /// <returns>Retorna un <typeparamref name="T"/> o NULL en caso de que no exista.</returns>
        T? GetByName(string name);
    }
}
