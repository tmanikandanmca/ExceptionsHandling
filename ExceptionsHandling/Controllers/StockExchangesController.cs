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

    // throw actual exception
    [HttpGet]
    [AllowAnonymous]
    public IEnumerable<StockExchangeEntity> GetAllExchange()
    {
        try
        {
            //consider if you have an exception here
            throw new Exception("Could n't connect with db");
            return _dbContext.StockExchanges.ToList();

        }
        catch
        {
            throw;
        }
    }

    //throw actual exception messages
    [HttpGet("GetById")]
    [AllowAnonymous]
    public IActionResult GetById(int? id)
    {
        try
        {
            //consider if you have an exception here
            var res = _dbContext.StockExchanges.Where(x => x.ExchangeId == id).ToList();
            if (!res.Any())
                throw new Exception("No Data Available");
            return Ok(res);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //instead of exception we can use our custom messages
    [HttpGet("GetByName")]
    [AllowAnonymous]
    public IActionResult GetByName(string id)
    {
        try
        {
            //consider if you have an exception here
            var res = _dbContext.StockExchanges.Where(x => x.ExchangeName == id).ToList();
            if (!res.Any())
                throw new Exception("No Data Available");
            return Ok(res);

        }
        catch (Exception ex)
        {
            return BadRequest("Exchange Is Missing In DB");
        }
    }
}

