using AutoMapper;
using AzureBlobStorage.Interfaces;
using DOMAIN.IConfiguration;
using DOMAIN.Models;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        private readonly IMapper _mapper;

        private readonly IFileUpload _ifileupload;

        public ReportController(IUnitOfWork uow, IMapper mapper, IFileUpload ifileupload)
        {
            _uow = uow;
            _mapper = mapper;
            _ifileupload = ifileupload;
        }
        
        // GET: api/<ReportController>/GetAll
        [HttpGet("GetAll")]
        public async  Task<ActionResult<IEnumerable<Report>>> FindAll()
        {
            try
            {
                var reports = await _uow.Report.FindAll();

                var reportsDTO = _mapper.Map<List<ReportDTO>> (reports);

                if (reportsDTO == null)
                {
                    return NotFound(reportsDTO);
                }

                return Ok(reportsDTO);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<ReportController>/5
        [HttpGet("FindById/{id}")]
        public async Task<ActionResult<Report>> FindById(int id)
        {
            try
            {
                var report = await _uow.Report.FindById(id);

                var reportDTO = _mapper.Map<ReportDTO>(report);

                if (reportDTO == null)
                {
                    return NotFound(reportDTO);
                }

                return Ok(reportDTO);

            }
            catch (Exception)
            {
                return BadRequest();
            }
           
        }

        // POST api/<ReportController>
        [HttpPost("Create")]
        public async Task<ActionResult> CreateReport([FromForm] ReportCreateDTO reportcreatedto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                //Upload the file to the azure blob storage
                var report = _mapper.Map<Report>(reportcreatedto);

                var fileupload = await _ifileupload.PdfUpload(reportcreatedto.PdfFile);

               

                report.PostDate = DateTime.Now;
                report.FileUrl = fileupload.Url;
                //report.Directorate = directorate.Data;

                _uow.Report.Create(report);
                await _uow.Save();
                return CreatedAtAction(nameof(FindById), new { id = report.ReportId }, report);


            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<ReportController>/5
        [HttpPut("UpdateById/{id}")]
        public async Task<ActionResult> UpdateById(int id, [FromBody] ReportUpdateDTO reportupdateDTO)
        {
            if(id != reportupdateDTO.ReportId || !ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                // var report = _mapper.Map<Report>(reportDTO);
                //Upload the file to the azure blob storage
                var report = _mapper.Map<Report>(reportupdateDTO);

                var fileupload = await _ifileupload.PdfUpload(reportupdateDTO.PdfFile);

                var directorate = await _uow.Directorate.FindById(reportupdateDTO.DirectorateId);

                if(directorate == null)
                {
                    return BadRequest();
                }
                report.PostDate = DateTime.Now;
                report.FileUrl = fileupload.Url;
                report.Directorate = directorate;
                _uow.Report.Update(report);
                await _uow.Save();
                return NoContent();

            }
            catch(Exception)
            {
                return BadRequest();

            }
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            try
            {
                //get the report
                var report = await _uow.Report.FindById(id);

                _uow.Report.Delete(report);

                //Save changes to database

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
