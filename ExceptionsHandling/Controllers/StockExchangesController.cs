using ExceptionsHandling.Models;
using ExceptionsHandling.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionsHandling.Controllers;
[ApiController]
[Route("[controller]")]
public class StockExchangesController : ControllerBase
{
    private readonly ILogger<StockExchangesController> _logger;
    private readonly MarketDbContext _dbContext;

    public StockExchangesController(ILogger<StockExchangesController> logger, MarketDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet]
    [AllowAnonymous]

    public IEnumerable<StockExchangeEntity> GetAllExchange(int? id)
    { 
        if (id<0 )
        throw new System.Exception("Not a valid Request");
   
            return _dbContext.StockExchanges.ToList();
        
    }
}

