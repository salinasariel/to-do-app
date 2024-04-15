

using final_proyect.Interfaces;
using simple_to_do.Models;

namespace final_proyect.Services
{
    public class UserService : IUserService
    {


        private readonly ToDoDbContext _context;

        public UserService(ToDoDbContext context)
        {
            _context = context;
        }

        public int CreateUser(Users user)
        {
            try
            {
                
                _context.Add(user);
                _context.SaveChanges();
                return user.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear");
                throw;
            }
        }

        public int CreateDoItem(TodoItem item, int UserId)
        {
            try
            {
                item.State = true;
                item.UserId = UserId;
                _context.Add(item);
                _context.SaveChanges();
                return item.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear" );
                throw;
            }
        }

        public List<TodoItem> GetItems(int UserId)
        {
            return _context.TodoItems.Where(u => u.UserId == UserId && u.State == true).ToList();
        }


        public void DeleteItem(int UserId, int ItemId) 
        {
            var item = _context.TodoItems.FirstOrDefault(i => i.UserId == UserId && i.Id == ItemId);
            if (item != null)
            {
                item.State = false; 
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("No Existe");
            }
        }
    }
}
