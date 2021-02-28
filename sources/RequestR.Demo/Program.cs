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

using DustInTheWind.RequestR.Demo.Microsoft.DependencyInjection.Presentation.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace DustInTheWind.RequestR.Demo.Microsoft.DependencyInjection
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ServiceProvider serviceProvider = SetupApplication();

            Run(serviceProvider);
        }

        private static ServiceProvider SetupApplication()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            Startup.ConfigureServices(serviceCollection);

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            Startup.Configure(serviceProvider);

            return serviceProvider;
        }

        private static void Run(ServiceProvider serviceProvider)
        {
            ProductsCommand productsCommand = serviceProvider.GetService<ProductsCommand>();
            productsCommand.Execute();
        }
    }
}