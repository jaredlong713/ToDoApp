using Microsoft.AspNetCore.Mvc;
using ToDoAppApi.Models;
using ToDoAppApi.Services;

namespace ToDoAppApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly IToDoService _toDoService;

        public ToDoController(ILogger<ToDoController> logger, IToDoService toDoService)
        {
            _logger = logger;
            _toDoService = toDoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allItems = _toDoService.GetAllToDoItems();

            return Ok(allItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemAsync(ToDoItem newitem)
        {
            var id = await _toDoService.AddToDoItem(newitem);

            return Created(string.Empty, new { id });
        }

        [HttpPut("{updateItemId}")]
        public async Task<IActionResult> UpdateAsync(int updateItemId, ToDoItem updatedItem)
        {
            await _toDoService.UpdateToDoItem(updateItemId, updatedItem);

            return NoContent();
        }

        [HttpDelete("{deleteItemId}")]
        public async Task<IActionResult> DeleteAsync(int deleteItemId)
        {
            await _toDoService.DeleteToDoItem(deleteItemId);

            return NoContent();
        }
    }
}
