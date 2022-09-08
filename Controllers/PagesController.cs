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
        public async Task<ActionResult> GetSinglePage(Guid id)
        {
            try
            {
                return Ok(await PagesManager.GetPage(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
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
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Page pagePL)
        {
            try
            {
                Page updatedPage = await PagesManager.UpdatePage(id, pagePL);
                return Ok(updatedPage);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                bool successfully = await PagesManager.DeletePage(id);
                if (successfully)
                {
                    return Ok(new { deleted = true });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
