﻿using StockAppWebAPI1.Repositories;
using StockAppWebAPI1.Models;

namespace StockAppWebAPI1.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;
        public QuoteService(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        public async Task<List<Quote>> GetHistoricalQuotes(int days, int stockId)
        {
            return await _quoteRepository.GetHistoricalQuotes(days, stockId);
        }

        public async Task<List<RealtimeQuote>?> GetRealtimeQuotes(
            int page, int limit,
            string sector,
            string industry)
        {
            return await _quoteRepository.GetRealtimeQuotes(page, limit, sector, industry);
        }
    }
}

