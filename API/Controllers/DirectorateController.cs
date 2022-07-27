using DOMAIN.IConfiguration;
using DOMAIN.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class DirectorateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public DirectorateController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<Response<IEnumerable<Directorate>>>> GetAll()
        {
            try
            {
                var directorates = await _uow.Directorate.FindAll();

                return Ok(directorates);

            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        // GET api/<DepartmentController>/5
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Response<Directorate>>> GetById(int id)
        {
            try
            {
                var directorate = await _uow.Directorate.FindById(id);

                return Ok(directorate);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<DepartmentController>
        [HttpPost("Create")]
        public async Task<ActionResult> CreateDirectorate([FromBody] Directorate directorate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (directorate == null)
            {
                return BadRequest();
            }
            try
            {
                _uow.Directorate.Create(directorate);
                await _uow.Save();
                return Ok();

            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("UpdateById/{id}")]
        public async Task<ActionResult> UpdateDirectorate(int id, [FromBody] Directorate directorate)
        {
            if(id != directorate.DirectorateId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            try
            {
                _uow.Directorate.Update(directorate);

                await _uow.Save();

                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult> DeleteDirectorate(int id)
        {
            
            try
            {
                var directorate = await _uow.Directorate.FindById(id);

                if (directorate == null)
                {
                    return BadRequest();
                }

                _uow.Directorate.Delete(directorate.Data);

                await _uow.Save();

                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
