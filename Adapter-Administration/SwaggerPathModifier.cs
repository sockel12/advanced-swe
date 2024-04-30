using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Globalization;

namespace Adapter_Administration;

public class SwaggerPathModifier : IDocumentFilter
{
    TextInfo myTI = new CultureInfo("en-US",false).TextInfo;
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        foreach (var path in swaggerDoc.Paths.SelectMany(p => p.Value.Operations))
        {
            var operation = path.Value;
            operation.Tags.Clear();
            var id = myTI.ToTitleCase(operation.OperationId.Replace("/api/v1", "").Split("/").ElementAt(1));
            operation.Tags.Add(new OpenApiTag { Name = id + "Handler" });
        }
    }
}