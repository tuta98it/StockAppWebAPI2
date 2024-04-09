using StockAppWebAPI1.Models;

namespace StockAppWebAPI1.Services
{
    public interface IStockService
    {
        Task<Stock?> GetStockById(int stockId);
        Task<List<string>> GetDistinctIndustries();
        Task<List<string>> GetDistinctSectors();
    }
}

