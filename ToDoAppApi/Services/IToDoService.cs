using Microsoft.AspNetCore.Mvc;
using ToDoAppApi.Models;

namespace ToDoAppApi.Services
{
    public interface IToDoService
    {
        Task<List<ToDoItem>> GetAllToDoItems();

        Task<int> AddToDoItem(ToDoItem addItem);

        Task UpdateToDoItem(int updateItemId, ToDoItem updatedItem);

        Task DeleteToDoItem(int removeItemId);
    }
}
