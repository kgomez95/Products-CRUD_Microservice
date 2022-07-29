namespace Products_CRUD_Microservice.Repository.Interfaces
{
    public interface ICreateRepository<T>
    {
        /// <summary>
        /// Crea el <typeparamref name="T"/> proporcionado por parámetros en base de datos.
        /// </summary>
        /// <param name="record"><typeparamref name="T"/> a crear.</param>
        /// <returns>Retorna el <typeparamref name="T"/> que se ha creado con su identificador.</returns>
        T? Create(T record);
    }
}
