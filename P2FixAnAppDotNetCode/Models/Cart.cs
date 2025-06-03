using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for display only
        /// </summary>
        //public List<CartLine> Lines => GetCartLineList();
        private List<CartLine> _cartLines = new List<CartLine>();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        //private List<CartLine> GetCartLineList()
        //{
        //    return new List<CartLine>();
        //}
        public List<CartLine> Lines => _cartLines;

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            var line = _cartLines.FirstOrDefault(p => p.Product.Id == product.Id);

            if (line == null)
            {
                _cartLines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }


        /// <summary>
        /// Removes a product from the cart
        /// </summary>
        public void RemoveLine(Product product)
        {
            _cartLines.RemoveAll(l => l.Product.Id == product.Id);
        }

        /// <summary>
        /// Gets the total value of the cart
        /// </summary>
        public double GetTotalValue()
        {
            return _cartLines.Sum(l => l.Product.Price * l.Quantity);
        }

        /// <summary>
        /// Gets the average value per item in the cart
        /// </summary>
        public double GetAverageValue()
        {
            if (!_cartLines.Any())
                return 0.0;

            int totalQuantity = _cartLines.Sum(l => l.Quantity);
            return GetTotalValue() / totalQuantity;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            return _cartLines.FirstOrDefault(l => l.Product.Id == productId)?.Product;
        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return _cartLines.ElementAtOrDefault(index);
        }


        /// <summary>
        /// Clears all added products from cart
        /// </summary>
        public void Clear()
        {
            _cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
