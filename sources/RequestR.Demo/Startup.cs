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

using System;
using DustInTheWind.RequestR.Demo.Microsoft.DependencyInjection.Presentation.Commands;
using DustInTheWind.RequestR.Extensions.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace DustInTheWind.RequestR.Demo.Microsoft.DependencyInjection
{
    internal static class Startup
    {
        public static void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddRequestBus();

            serviceCollection.AddTransient<ProductsCommand>();
        }

        public static void Configure(IServiceProvider serviceProvider)
        {
            RequestR.RequestBus requestBus = serviceProvider.GetService<RequestR.RequestBus>();
            requestBus.RegisterAllHandlers();
        }
    }
}