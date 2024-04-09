using StockAppWebAPI1.Models;

namespace StockAppWebAPI1.Services
{
    public interface IQuoteService
    {
        Task<List<RealtimeQuote>?> GetRealtimeQuotes(
            int page,
            int limit,
            string sector,
            string industry);
        Task<List<Quote>> GetHistoricalQuotes(int days, int stockId);
    }
}

