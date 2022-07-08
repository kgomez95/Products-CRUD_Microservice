using Newtonsoft.Json;
using Products_CRUD_Microservice.SwaggerVersion.Models;

namespace Products_CRUD_Microservice.SwaggerVersion
{
    public class Documentation
    {
        /// <summary>
        /// Coge la documentación de Swagger mediante la ruta del fichero proporcionado por parámetros.
        /// </summary>
        /// <param name="filePath">Ruta del fichero de la documentación Swagger.</param>
        /// <returns>Retorna una lista de documentación de Swagger.</returns>
        public static SwaggerDoc[] GetDocumentations(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            SwaggerDoc[] swaggerDocs = JsonConvert.DeserializeObject<SwaggerDoc[]>(jsonData);
            return swaggerDocs;
        }
    }
}
