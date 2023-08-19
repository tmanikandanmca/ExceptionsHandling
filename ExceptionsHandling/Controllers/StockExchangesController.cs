using System;
using ExceptionsHandling.Exception;
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

    public IEnumerable<StockExchangeEntity> GetAllExchange()
    {
       
            return _dbContext.StockExchanges.ToList();
       
    }


    [HttpGet("GetById")]
    [AllowAnonymous]
    public IActionResult GetExchangeById(int? id)
    {
        try
        {
            if (id <= 0) throw new ExchangeExceptions("Id is Not valid");
            var res = _dbContext.StockExchanges.Where(x => x.ExchangeId == id).ToList();
            return Ok(res);
        }
        catch(ExchangeExceptions ex)
        {
            return BadRequest(ex.Message);
        }
    }


}

