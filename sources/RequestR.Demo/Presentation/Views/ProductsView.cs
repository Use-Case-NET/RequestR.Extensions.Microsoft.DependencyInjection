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
using DustInTheWind.RequestR.Demo.Microsoft.DependencyInjection.Domain;
using DustInTheWind.RequestR.Demo.Microsoft.DependencyInjection.Presentation.ViewModels;

namespace DustInTheWind.RequestR.Demo.Microsoft.DependencyInjection.Presentation.Views
{
    internal class ProductsView
    {
        private readonly ProductsViewModel viewModel;

        public ProductsView(ProductsViewModel viewModel)
        {
            this.viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public void Display()
        {
            if (viewModel.Products == null || viewModel.Products.Count == 0)
            {
                Console.WriteLine("There are no products.");
                return;
            }

            foreach (Product product in viewModel.Products)
            {
                Console.WriteLine();
                Console.WriteLine("Product: " + product.Name);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine("Quantity: " + product.Quantity);
            }
        }
    }
}