using Microsoft.EntityFrameworkCore;
using ToDoAppApi.Data;
using ToDoAppApi.Models;

namespace ToDoAppApi.Services
{
    public class ToDoService : IToDoService
    {
        public readonly ToDoDataContext _dbContext;

        public ToDoService(ToDoDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<ToDoItem>> GetAllToDoItems()
        {
            var results = _dbContext.ToDoItems.ToList();

            return Task.FromResult(results);
        }

        public async Task<int> AddToDoItem(ToDoItem addItem)
        {
            await _dbContext.ToDoItems.AddAsync(addItem);
            await _dbContext.SaveChangesAsync();

            return addItem.Id;
        }

        public async Task UpdateToDoItem(int updateItemId, ToDoItem updatedItem)
        {
            var foundResult = await _dbContext.ToDoItems.SingleAsync(x => x.Id == updateItemId);
            if (foundResult != null)
            {
                foundResult.Title = updatedItem.Title;
                foundResult.Note = updatedItem.Note;
                foundResult.IsCompleted = updatedItem.IsCompleted;
                foundResult.Deadline = updatedItem.Deadline;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteToDoItem(int removeItemId)
        {
            var foundResult = await _dbContext.ToDoItems.SingleAsync(x => x.Id == removeItemId);
            if (foundResult != null)
            {
                _dbContext.Remove(foundResult);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
