using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {

        static List<Quote> _quotes = new List<Quote>()

         {
            new Quote(){ Id=0, Name= "Olashile Onanuga", Description= "My third sister"},
            new Quote(){ Id=1, Name= "Olamide Onanuga", Description= "My second sister"},
            new Quote(){ Id=2, Name= "Temitope Onanuga", Description= "My first sister"}
         };
        //code for creating static listing options and lists are decleared  

        [HttpGet]
        // GET attribute

        public IEnumerable<Quote> Get()
        {
            return _quotes;
        }
        // to return list of quotes above

        [HttpPost]
        // POST attribute
        public void Post([FromBody]Quote quote)
        // the key-value pair data should go to the body section
        {
            _quotes.Add(quote);
        }

        [HttpPut("{id}")]
        // PUT attribute
        public void Put(int id,[FromBody]Quote quote)
        // specify the field to be updated, here it's the Id field 
        {
            _quotes[id] = quote; 
        }

        [HttpDelete("{id}")] // DELETE attribute
        public void Delete(int id)  // Delete quote with this id 
        {
            _quotes.RemoveAt(id);
        }
    }
   
    
}
    

