using AutoMapper;
using Azure;
using FinanceAssistantAPI.Models;
using FinanceAssistantAPI.Models.Dto;
using FinanceAssistantAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WEBTEST_API_PROYECT.Models;

namespace FinanceAssistantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {

        public readonly IFinancialRecordRepository _financialRepo;
        public readonly IMapper _mapper;
        protected APIResponse _response;

        public ExpensesController(IFinancialRecordRepository financialRepo, IMapper mapper)
        {
            _financialRepo = financialRepo;
            _mapper = mapper;
            _response = new();
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ApplicationFinancialRecord>>> GetFinancialRecords()
        {

            IEnumerable<ApplicationFinancialRecord> financialRecordsList = await _financialRepo.GetAll();

            _response.Result = _mapper.Map<ApplicationFinancialRecordDto>(financialRecordsList);
            _response.StatusCode = HttpStatusCode.OK;

            return Ok(_response);

        }


        [HttpGet("id:int", Name = "GetFinancialRecordById")]
        public async Task<ActionResult<APIResponse>> GetFinancialRecordById(int Id)
        {

            try
            {
                var record = await _financialRepo.Get(r => r.Id == Id);

                if(record == null)
                {
                    _response.isSucessfull = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                else
                {
                    _response.Result = _mapper.Map<ApplicationFinancialRecordDto>(record);
                    //_response.isSucessfull = true;
                }

                return Ok(_response);

            }
            catch(Exception ex)
            {
                _response.isSucessfull = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }


            return _response;
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> CreateFinancialRecords([FromBody] ApplicationFinancialRecordDto CreateDto)
        {

            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if(CreateDto == null)
                {
                    return BadRequest();
                }


                ApplicationFinancialRecord model = _mapper.Map<ApplicationFinancialRecord>(CreateDto);

                model.Date = DateTime.Now;

                await _financialRepo.Create(model);

                _response.Result = model;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetFinancialRecordById", new { id = model.Id }, _response);


            }
            catch(Exception ex) 
            {
                _response.isSucessfull = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return _response;
        }

    }
    
}
