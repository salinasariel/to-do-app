
using final_proyect.Interfaces;
using Microsoft.AspNetCore.Mvc;
using simple_to_do.Models;

namespace final_proyect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("NewUser")]
        public ActionResult<int> CreateUsers([FromBody] Users user)
        {
            try
            {
                var newuser = _userService.CreateUser(user);
                return Ok(newuser);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el usuario.");
                return StatusCode(500);
            }
        }

        [HttpPost("NewItem")]
        public ActionResult<int> CreateItem(TodoItem item, int UserId)
        {
            try
            {
                var newitem = _userService.CreateDoItem(item, UserId);
                return Ok(newitem);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el item.");
                return StatusCode(500);
            }
        }

        [HttpGet("GetItems")]
        public ActionResult<List<TodoItem>> GetItems(int UserId)
        {
            try
            {
                var items = _userService.GetItems(UserId);
                return Ok(items);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                return StatusCode(500);
            }
        }

        [HttpPut("CheckItem")]
        public ActionResult<int> CheckItem(int UserId, int ItemId)
        {
            try
            {
                _userService.DeleteItem(UserId, ItemId);
                return Ok("Borrado ok, marcado como completado");
            }
            catch
            { 
                return StatusCode(500);
            }
        }
    }
}
