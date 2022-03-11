using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuotesApi.Data;
using QuotesApi.modules;
namespace QuotesApi.controllers
{
    [Route("api/[contoller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private QuotesDbContext _quotesDbContext;
        public QuotesController (QuotesDbContext quotesDbContext)
        {
            _quotesDbContext = quotesDbContext;
        }
        [HttpGet]
        // GET attribute
        public IActionResult Get()
        {
           //return StatusCode(200) .....returns statuscode in iteger format
               // return _quotesDbContext.Quotes;
            
            return Ok(_quotesDbContext.Quotes);
        }
        // to return list of quotes above
        
        [HttpGet("{id}", Name = "Get")] 
        // GET attribute by Id
        public Quote Get(int id)
        {
            var quote = _quotesDbContext.Quotes.Find(id);
            return quote;
        }


        [HttpPost]
        // POST attribute
        public IActionResult Post([FromBody] Quote quote)
        // the key-value pair data should go to the body section
        {
            _quotesDbContext.Quotes.Add(quote);
            _quotesDbContext.SaveChanges();
            return StatusCode(StatusCode.Status201Created);
        }

        [HttpPut("{id}")]
        // PUT attribute
        public void Put(int id, [FromBody] Quote quote)
        // specify the field to be updated, here it's the Id field 
        {
          var entity =  _quotesDbContext.Quotes.Find(id);
            if (entity == null)
            {
                return NotFound ("No record found against this id....");
            }
            else
            {
                entity.Id = quote.Id;
                entity.Name = quote.Name;
                entity.Description = quote.Description;
                _quotesDbContext.SaveChanges();
                return Ok("Record updated successfully...");
            }
            
        }

        [HttpDelete("{id}")] // DELETE attribute
        public void Delete(int id)  // Delete quote with this id 
        {
            var quote = _quotesDbContext.Quotes.Find(id);
            _quotesDbContext.Quotes.Remove(quote);
            _quotesDbContext.SaveChanges();

        }
    }


}

