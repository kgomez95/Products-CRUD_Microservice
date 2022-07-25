using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Products_CRUD_Microservice.API.Models;
using Products_CRUD_Microservice.Exceptions.StatusExceptions;

namespace Products_CRUD_Microservice.API.Attributes
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                IList<ApiError> errors = new List<ApiError>();

                // Recorremos los errores que se han producido en el modelo para guardarlos.
                foreach (ModelStateEntry? models in context.ModelState.Values)
                {
                    if (models != null)
                    {
                        foreach (ModelError? error in models.Errors)
                        {
                            if (error != null)
                            {
                                errors.Add(new ApiError(error.ErrorMessage));
                            }
                        }
                    }
                }

                // Lanzamos la excepción.
                throw new BadRequestException(errors.ToArray());

                // https://code-maze.com/aspnetcore-modelstate-validation-web-api/
            }
        }
        public void OnActionExecuted(ActionExecutedContext context) 
        { }
    }
}
