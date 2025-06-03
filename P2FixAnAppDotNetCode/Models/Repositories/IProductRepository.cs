namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        // Retourne un array de tous les produits 
        Product[] GetAllProducts();

        // Retourne un produit par son id
        Product GetProductById(int id);

        // Mise à jour du stock de produits
        void UpdateProductStocks(int productId, int quantityToRemove);
      

    }
}
