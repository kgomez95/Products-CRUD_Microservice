using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Products_CRUD_Microservice.SwaggerVersion
{
    public class ReplaceVersionWithExactValueInPath : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            // Hacemos una copia de las rutas de swagger y vaciamos el listado original.
            OpenApiPaths paths = swaggerDoc.Paths;
            swaggerDoc.Paths = new OpenApiPaths();

            // Recorremos la copia de las rutas y las volvemos a añadir al listado original reemplazando la cadena "v{version}" por la versión correspondiente del documento.
            foreach (KeyValuePair<string, OpenApiPathItem> path in paths)
            {
                string key = path.Key.Replace("v{version}", swaggerDoc.Info.Version);
                OpenApiPathItem value = path.Value;
                swaggerDoc.Paths.Add(key, value);
            }
        }
    }
}
