using Headless.Core.Managers;
using Headless.Core.Pagination;
using Headless.Core.Payloads;
using Headless.DB.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Headless.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        IPagesManager PagesManager { get; set; }
        public PagesController(IPagesManager pagesManager)
        {
            PagesManager = pagesManager;
        }
        // GET: api/<ValuesController>
        [HttpGet("nobody")]
        public async Task<ActionResult> GetPagesWithoutBody([FromQuery(Name = "count")] int count, [FromQuery(Name = "pageIndex")] int pageIndex, [FromQuery(Name = "pageSize")] int pageSize)
        {
            try
            {
                PaginatedList<Page> pagesWithoutBody = await PagesManager.GetPaginatedPagesForTables(count, pageIndex, pageSize);

                return Ok(pagesWithoutBody);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePagePL pagePL)
        {
            try
            {
                Page newPage = await PagesManager.CreatePage(pagePL);

                return Ok(newPage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Lang pagePL)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
