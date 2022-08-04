using AutoMapper;
using DOMAIN.IConfiguration;
using DOMAIN.Models;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class DirectorateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DirectorateController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Directorate>>> GetAll()
        {
            try
            {
                var directorates = await _uow.Directorate.FindAll();

                var directoratesDTO = _mapper.Map<List<DirectorateDTO>>(directorates);

                return Ok(directoratesDTO);

            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        // GET api/<DepartmentController>/5
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Directorate>> GetById(int id)
        {
            try
            {
                var directorate = await _uow.Directorate.FindById(id);

                var directorateDTO = _mapper.Map<DirectorateDTO>(directorate);

                return Ok(directorateDTO);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<DepartmentController>
        [HttpPost("Create")]
        public async Task<ActionResult> CreateDirectorate([FromBody] DirectorateCreateDTO directoratecreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (directoratecreateDTO == null)
            {
                return BadRequest();
            }
            try
            {
                var directorate = _mapper.Map<Directorate>(directoratecreateDTO);
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
        public async Task<ActionResult> UpdateDirectorate(int id, [FromBody] DirectorateDTO directorateDTO)
        {
            if(id != directorateDTO.DirectorateId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            try
            {
                var directorate = _mapper.Map<Directorate>(directorateDTO);
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

                _uow.Directorate.Delete(directorate);

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
