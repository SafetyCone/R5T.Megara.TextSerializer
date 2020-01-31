using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Megara.Stockholm.Standard;
using R5T.Stockholm.Tiros.Standard;
using R5T.Tiros;


namespace R5T.Megara.TextSerializer
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IFileSerializer{T}"/> service.
        /// </summary>
        public static IServiceCollection AddTextFileSerializer<T>(this IServiceCollection services,
            ServiceAction<ITextSerializer<T>> addTextSerializer)
        {
            services.AddFileSerializer<T>(
                services.AddTextStreamSerializerAction(addTextSerializer))
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IFileSerializer{T}"/> service.
        /// </summary>
        public static ServiceAction<IFileSerializer<T>> AddTextFileSerializerAction<T>(this IServiceCollection services,
            ServiceAction<ITextSerializer<T>> addTextSerializer)
        {
            var serviceAction = new ServiceAction<IFileSerializer<T>>(() => services.AddTextFileSerializer<T>(addTextSerializer));
            return serviceAction;
        }
    }
}
