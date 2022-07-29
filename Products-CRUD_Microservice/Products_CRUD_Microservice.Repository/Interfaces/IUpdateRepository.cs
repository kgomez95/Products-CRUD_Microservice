namespace Products_CRUD_Microservice.Repository.Interfaces
{
    public interface IUpdateRepository<T>
    {
        /// <summary>
        /// Actualiza en base de datos el <typeparamref name="T"/> proporcionado por parámetros.
        /// </summary>
        /// <param name="record"><typeparamref name="T"/> a actualizar.</param>
        /// <returns>Retorna el <typeparamref name="T"/> actualizado o NULL en caso de que no exista.</returns>
        T? Update(T entity);
    }
}
