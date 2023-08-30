using AutoMapper;
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
    public class UsersController : ControllerBase
    {
        public readonly IUserRepository _UserRepo;
        public readonly IMapper _mapper;
        protected APIResponse _response;

        public UsersController(IUserRepository UserRepo, IMapper mapper)
        {
            _UserRepo = UserRepo;
            _mapper = mapper;
            _response = new();
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetUsers()
        {
            try
            {
                IEnumerable<ApplicationUser> UserList = await _UserRepo.GetAll();

                _response.Result = _mapper.Map<IEnumerable<ApplicationUser>>(UserList);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);

            }
            catch(Exception ex)
            {
                _response.isSucessfull = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return _response;

        }

        [HttpGet("id:int", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetUser(int id)
        {
            try
            {
                Console.WriteLine(id);

                if (id == 0)
                {
                    _response.isSucessfull = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response); // Bad request if id is invalid

                }


                var user =  await _UserRepo.Get(u => u.Id == id);

                if(user == null)
                {
                    _response.isSucessfull = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                    _response.Result = _mapper.Map<ApplicationUserDto>(user);
                    _response.isSucessfull = false;

                    return Ok(_response);
                

            }
            catch (Exception ex) 
            {
                _response.isSucessfull=false;
                _response.ErrorMessage=new List<string> { ex.ToString() };

            }

            return _response;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> CreateUser([FromBody] ApplicationUserCreateDto CreateDto)
        {
            try
            {
               
                if(CreateDto == null)
                {
                    return BadRequest();
                }
     
                ApplicationUser model = _mapper.Map<ApplicationUser>(CreateDto);
                await _UserRepo.Create(model);

                _response.Result = model;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetUser", new { id = model.Id }, _response);

            }
            catch (Exception ex)
            {
                _response.isSucessfull = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };

            }

            return _response;
        }




        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] ApplicationUserUpdateDto updateDto)
        {
            if(updateDto == null || id != updateDto.Id)
            {
                _response.isSucessfull=false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(ModelState);

            }

            ApplicationUser model = _mapper.Map<ApplicationUser>(updateDto);

            await _UserRepo.Update(model);

            _response.StatusCode = HttpStatusCode.NoContent;
           return Ok(_response);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _UserRepo.Get(u => u.Id == id);

                if(user == null)
                {
                    _response.isSucessfull = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _UserRepo.Delete(user);

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.isSucessfull = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return BadRequest(_response);
        }




    }
}
