using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Megara.Stockholm.Standard;
using R5T.Stockholm.Tiros.Standard;
using R5T.Tiros;


namespace R5T.Megara.TextSerializer
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTextFileSerializer<T, TTextSerializer>(this IServiceCollection services)
            where TTextSerializer: class, ITextSerializer<T>
        {
            services
                .AddSingleton<ITextSerializer<T>, TTextSerializer>()
                .AddTextStreamSerializer<T>()
                .AddStreamFileSerializer<T>()
                ;

            return services;
        }
    }
}
