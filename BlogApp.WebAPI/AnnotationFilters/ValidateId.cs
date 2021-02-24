using BlogApp.Business.Interfaces;
using BlogApp.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace BlogApp.WebAPI.AnnotationFilters
{
    public class ValidateId <T>: IActionFilter where T : class, ITable
    {
        private readonly IGenericService<T> genericService;

        public ValidateId(IGenericService<T> genericService)
        {
            this.genericService = genericService;

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var contextIdPair = context.ActionArguments.Where(I => I.Key == "id").FirstOrDefault();

            var id = int.Parse(contextIdPair.Value.ToString());

            var relatedEntity = genericService.FindById(id).Result;

            if (relatedEntity == null) { context.Result = new NotFoundObjectResult("Related object can not found"); }
        }
    }
}
