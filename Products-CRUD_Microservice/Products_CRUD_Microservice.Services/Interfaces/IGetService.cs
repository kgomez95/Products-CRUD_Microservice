namespace Products_CRUD_Microservice.Services.Interfaces
{
    public interface IGetService<T>
    {
        /// <summary>
        /// Llama al repositorio para recuperar un <typeparamref name="T"/> filtrando por su identificador.
        /// </summary>
        /// <param name="id">Identificador del <typeparamref name="T"/>.</param>
        /// <returns>Retorna el <typeparamref name="T"/> que se ha encontrado en el repositorio.</returns>
        T GetById(int id);
        /// <summary>
        /// Llama al repositorio para recuperar un <typeparamref name="T"/> filtrando por su nombre.
        /// </summary>
        /// <param name="name">Nombre del <typeparamref name="T"/>.</param>
        /// <returns>Retorna el <typeparamref name="T"/> que se ha encontrado en el repositorio.</returns>
        T GetByName(string name);
    }
}
