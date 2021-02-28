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
using System.Collections.Generic;
using DustInTheWind.RequestR.Demo.Microsoft.DependencyInjection.Application.PresentProducts;
using DustInTheWind.RequestR.Demo.Microsoft.DependencyInjection.Domain;
using DustInTheWind.RequestR.Demo.Microsoft.DependencyInjection.Presentation.ViewModels;
using DustInTheWind.RequestR.Demo.Microsoft.DependencyInjection.Presentation.Views;

namespace DustInTheWind.RequestR.Demo.Microsoft.DependencyInjection.Presentation.Commands
{
    internal class ProductsCommand
    {
        private readonly RequestR.RequestBus requestBus;

        public ProductsCommand(RequestR.RequestBus requestBus)
        {
            this.requestBus = requestBus ?? throw new ArgumentNullException(nameof(requestBus));
        }

        public void Execute()
        {
            PresentProductsRequest request = new PresentProductsRequest();
            List<Product> products = requestBus.Send<PresentProductsRequest, List<Product>>(request);

            ProductsViewModel viewModel = new ProductsViewModel
            {
                Products = products
            };
            ProductsView view = new ProductsView(viewModel);
            view.Display();
        }
    }
}