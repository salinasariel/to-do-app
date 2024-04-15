using simple_to_do.Models;

namespace final_proyect.Interfaces
{
    public interface IUserService
    {

        public int CreateUser(Users user);
        public int CreateDoItem(TodoItem item, int UserId);
        public List<TodoItem> GetItems(int UserId);
        public void DeleteItem(int UserId, int ItemId);

    }
}
