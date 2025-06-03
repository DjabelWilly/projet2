﻿using P2FixAnAppDotNetCode.Models.Repositories;
using System.Collections.Generic;
using System.Linq;


namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>
        public List<Product> GetAllProducts()
        {
            // TODO change the return type from array to List<T> and propagate the change
            // throughout the application
            // Convertit le tableau retourné par le repository en liste
            return _productRepository.GetAllProducts().ToList();
        }

        /// <summary>
        /// Get a product from the inventory by its id
        /// </summary>
        public Product GetProductById(int id)
        {
            // TODO implement the method

            return _productRepository.GetProductById(id); ;
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            // TODO implement the method
            // update product inventory by using _productRepository.UpdateProductStocks() method.
            // Mise à jour des stocks des produits présents dans le panier
            foreach (var line in cart.Lines)
            {
                var product = _productRepository.GetProductById(line.Product.Id);
                if (product != null)
                {
                    // Appelle le repository pour mettre à jour le stock
                    _productRepository.UpdateProductStocks(line.Product.Id, line.Quantity);
                }
              
            }


        }
    }
}
