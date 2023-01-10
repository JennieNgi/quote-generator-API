using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using quoteGeneratorAPI.Models;

namespace quoteGeneratorAPI.Controllers {

    [ApiController]
    
    // disabling CORs for requests / responses of public Web API (only needed when using with React)
    [DisableCors]

    public class QuoteAPIController : ControllerBase {
        // GET api JSON
        [HttpGet]
        [Route("quotes/{count}")]
        public ActionResult<List<Quote>> Get(int count) {
            APIManager apiManager = new APIManager();
            return apiManager.getQuotes(count);
        }        
    }
    
}
