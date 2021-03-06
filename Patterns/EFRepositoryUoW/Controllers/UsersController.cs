using EFRepositoryUoW.Core.Configuration;
using EFRepositoryUoW.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFRepositoryUoW.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(
            ILogger<UsersController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();

                await _unitOfWork.Users.Add(user);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetItem", new { user.Id }, user);    
            }
            
            return new JsonResult("Something went wrong") { StatusCode = 500};
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
