﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASP.netCoreTreningApp.ModelBinders
{
    public class ExtractYearModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if(context?.Metadata?.Name?.ToLower() == "year"
                && context.Metadata.ModelType == typeof(int))
            {
                return new ExtractYearModelBinder();
            }

            return null;
        }
    }
}
