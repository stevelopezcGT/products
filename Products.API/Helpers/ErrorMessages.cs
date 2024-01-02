using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Products.API.Helpers;

public static class ErrorMessages
{
    public static List<string> Convert(ModelStateDictionary modelState)
    {
        var errorsList = new List<string>();
        foreach (var keyModelStatePair in modelState)
        {
            var errors = keyModelStatePair.Value.Errors;
            if (errors != null && errors.Count>0) {
                for (var i = 0; i < errors.Count; i++)
                    errorsList.Add(errors[0].ErrorMessage);
            }
        }

        return errorsList;
    }
}
