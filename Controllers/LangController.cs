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
    public class LangController : ControllerBase
    {
        private ILangManager LangManager { get; set; }
        public LangController(ILangManager langManager)
        {
            LangManager = langManager;
        }


        // GET: api/<LangController>
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery(Name = "count")] int count, [FromQuery(Name = "pageIndex")] int pageIndex, [FromQuery(Name = "pageSize")] int pageSize)
        {
            try
            {
                PaginatedList<Lang> test = await LangManager.GetPaginatedLang(count, pageIndex, pageSize);
                return Ok(test);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<LangController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetLangById(Guid id)
        {
            try
            {
                Lang lang = await LangManager.GetSingleLangById(id);
                return Ok(lang);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<LangController>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLanuagePL langPL)
        {
            try
            {
                Lang newLang = await LangManager.CreateLang(langPL);

                return Ok(newLang);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // PUT api/<LangController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLang(Guid id, [FromBody] Lang pagePL)
        {
            try
            {
                Lang updatedLang = await LangManager.UpdateLang(id, pagePL);
                return Ok(updatedLang);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<LangController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                bool successfully = await LangManager.DeleteLang(id);
                if (successfully)
                {
                    return Ok(new { deleted = true});
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
