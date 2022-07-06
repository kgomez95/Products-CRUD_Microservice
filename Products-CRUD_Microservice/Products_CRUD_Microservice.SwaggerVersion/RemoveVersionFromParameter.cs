using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Products_CRUD_Microservice.SwaggerVersion
{
    public class RemoveVersionFromParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters != null && operation.Parameters.Count > 0)
            {
                // Borramos el parámetro "version" del objeto de operaciones.
                OpenApiParameter versionParameter = operation.Parameters.Single(x => x.Name.Equals("version", StringComparison.CurrentCultureIgnoreCase));
                operation.Parameters.Remove(versionParameter);
            }
        }
    }
}
