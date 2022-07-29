namespace Products_CRUD_Microservice.Services.Interfaces
{
    public interface IUpdateService<T>
    {
        /// <summary>
        /// Llama al repositorio para actualizar un <typeparamref name="T"/>.
        /// </summary>
        /// <param name="recordDTO"><typeparamref name="T"/> a actualizar.</param>
        /// <returns>Retorna el <typeparamref name="T"/> que se ha actualizado en el repositorio.</returns>
        T Update(T entity);
    }
}
