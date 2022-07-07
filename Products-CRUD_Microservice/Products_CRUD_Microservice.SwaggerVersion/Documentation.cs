using Newtonsoft.Json;
using Products_CRUD_Microservice.SwaggerVersion.Models;

namespace Products_CRUD_Microservice.SwaggerVersion
{
    public class Documentation
    {
        public static SwaggerDoc[] GetDocumentations(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            SwaggerDoc[] swaggerDocs = JsonConvert.DeserializeObject<SwaggerDoc[]>(jsonData);
            return swaggerDocs;
        }
    }
}
