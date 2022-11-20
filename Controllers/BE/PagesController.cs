using Headless.Core.Managers;
using Headless.Core.Pagination;
using Headless.Core.Payloads;
using Headless.DB.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Headless.API.Controllers.BE
{
    [Route("api/be/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        IPagesManager PagesManager { get; set; }
        IActualPagesManager ActualPagesManager { get; set; }
        public PagesController(IPagesManager pagesManager, IActualPagesManager actualPagesManager)
        {
            PagesManager = pagesManager;
            ActualPagesManager = actualPagesManager;
        }
        // GET: api/be/<ValuesController>
        [HttpGet("nobody")]
        public async Task<ActionResult> GetPagesWithoutBody([FromQuery(Name = "count")] int count, [FromQuery(Name = "pageIndex")] int pageIndex, [FromQuery(Name = "pageSize")] int pageSize)
        {
            try
            {
                PaginatedList<Page> pagesWithoutBody = await PagesManager.GetPaginatedPagesForTables(count, pageIndex, pageSize);

                return Ok(pagesWithoutBody);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/be/<ValuesController>/{langId}/{id}
        [HttpGet("{langId}/{id}")]
        public async Task<ActionResult> GetSinglePage(Guid id, Guid langId)
        {
            try
            {
                Page page = await PagesManager.GetPage(id);
                ActualPage actualPage = await ActualPagesManager.GetActualPage(id, langId);
                return Ok(new {page, actualPage});
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/be/<ValuesController>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PagePL pagePL)
        {
            try
            {
                Page newPage = await PagesManager.CreatePage(pagePL);
                ActualPage newActualPage = await ActualPagesManager.CreateActualPage(newPage.Id ,pagePL);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/be/<ValuesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] PagePL pagePL)
        {
            try
            {
                Page page = await PagesManager.UpdatePage(id, pagePL);
                await ActualPagesManager.UpdateActualPage(id, pagePL.LangId, pagePL);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/be/<ValuesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                bool successfully = await PagesManager.DeletePage(id);
                await ActualPagesManager.DeleteActualPages(id);
                if (successfully)
                {
                    return Ok();
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
