namespace Products_CRUD_Microservice.Services.Interfaces
{
    public interface ICreateService<T>
    {
        /// <summary>
        /// Llama al repositorio para crear un <typeparamref name="T"/>.
        /// </summary>
        /// <param name="recordDTO"><typeparamref name="T"/> a crear.</param>
        /// <returns>Retorna el <typeparamref name="T"/> que se ha creado en el repositorio.</returns>
        T Create(T recordDTO);
    }
}
