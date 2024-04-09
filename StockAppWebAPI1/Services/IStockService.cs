using StockAppWebAPI11.Models;

namespace StockAppWebAPI11.Services
{
    public interface IStockService
    {
        Task<Stock?> GetStockById(int stockId);
        Task<List<string>> GetDistinctIndustries();
        Task<List<string>> GetDistinctSectors();
    }
}

