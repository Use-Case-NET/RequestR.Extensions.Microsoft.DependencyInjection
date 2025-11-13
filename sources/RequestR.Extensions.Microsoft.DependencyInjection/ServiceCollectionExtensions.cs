// RequestR
// Copyright (C) 2021 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using Microsoft.Extensions.DependencyInjection;

namespace DustInTheWind.RequestR.Extensions.Microsoft.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddUseCaseEngine(this ServiceCollection serviceCollection, Action<UseCaseEngineOptions> setupOptions)
    {
        if (setupOptions is null) throw new ArgumentNullException(nameof(setupOptions));

        UseCaseEngineOptions options = new();
        setupOptions(options);

        serviceCollection.AddTransient<UseCaseFactoryBase, UseCaseFactory>();
        serviceCollection.AddSingleton(serviceProvider =>
        {
            UseCaseFactoryBase useCaseFactory = serviceProvider.GetService<UseCaseFactoryBase>();
            RequestBus requestBus = new(useCaseFactory);

            foreach (Type useCaseType in options.UseCaseTypes)
                requestBus.RegisterUseCase(useCaseType);

            foreach (Type validatorType in options.ValidatorTypes)
                requestBus.RegisterValidator(validatorType);

            return requestBus;
        });

        foreach (Type useCaseType in options.UseCaseTypes)
            serviceCollection.AddTransient(useCaseType);

        foreach (Type validatorType in options.ValidatorTypes)
            serviceCollection.AddTransient(validatorType);
    }

    //private static void AddAllHandlersAndValidators(this ServiceCollection serviceCollection)
    //{
    //    if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));

    //    IEnumerable<Type> useCaseOrValidatorTypes = AppDomain.CurrentDomain.GetAssemblies()
    //        .SelectMany(x => x.GetAllRequestHandlersOrValidators());

    //    foreach (Type useCaseOrValidatorType in useCaseOrValidatorTypes)
    //        serviceCollection.AddTransient(useCaseOrValidatorType);
    //}

    //private static IEnumerable<Type> GetAllRequestHandlersOrValidators(this Assembly assembly)
    //{
    //    Type[] types = assembly.GetTypes();

    //    foreach (Type type in types)
    //    {
    //        if (type.IsClass && !type.IsAbstract)
    //        {
    //            Type[] interfaces = type.GetInterfaces();

    //            foreach (Type @interface in interfaces)
    //            {
    //                if (@interface.IsGenericType)
    //                {
    //                    Type genericTypeDefinition = @interface.GetGenericTypeDefinition();

    //                    if (genericTypeDefinition == typeof(IUseCase<,>) ||
    //                        genericTypeDefinition == typeof(IUseCase<>) ||
    //                        genericTypeDefinition == typeof(IRequestValidator<>))
    //                    {
    //                        yield return type;
    //                        break;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
}