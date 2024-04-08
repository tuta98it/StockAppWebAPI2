using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Models;
using StockAppWebApi.Services;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace StockAppWebAPI1.Controllers
{
    [Route("api/ws")]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;
        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }
        [HttpGet("ws")]
        //https://localhost:port/api/quote/ws
        public async Task GetRealtimeQuotes(
            int page = 1,
            int limit = 10,
            string sector = "",
            string industry = "")
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                while (webSocket.State == WebSocketState.Open)
                {

                    List<RealtimeQuote>? quotes = await _quoteService.GetRealtimeQuotes(page, limit, sector, industry);
                    string jsonString = JsonSerializer.Serialize(quotes);
                    var buffer = Encoding.UTF8.GetBytes(jsonString);
                    await webSocket.SendAsync(
                        new ArraySegment<byte>(buffer),
                        WebSocketMessageType.Text, true, CancellationToken.None);
                    await Task.Delay(2000); // Đợi 2 giây trước khi gửi giá trị tiếp theo
                }
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure,
                            "Connection closed by the server", CancellationToken.None);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
    }
}
