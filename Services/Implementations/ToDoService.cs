
using System.Collections.Generic;
using System.Linq;
using TODOLIST.Data.Entities;
using TODOLIST.Services.Interfaces;
using TODOLIST.DBContext;
using Microsoft.EntityFrameworkCore;
using ErrorOr;

namespace TODOLIST.Services.Implementations
{
    public class TodoService : IToDoService
    {
        private readonly ToDoContext _todos;

        public TodoService(ToDoContext todoService)
        {
            _todos = todoService;
        }

        public List<ToDo> GetAllToDos()
        {
            return _todos.ToDo.ToList();
        }

        public ToDo GetTodoById(int todoId)
        {
            var todoEncontrado = _todos.ToDo.FirstOrDefault(t => t.ToDoId == todoId);
            return todoEncontrado;
        }

        public ToDo CreateTodo(ToDo todo)
        {
            _todos.ToDo.Add(todo);
            _todos.SaveChanges();
            return todo;
        }

        public ToDo UpdateTodo(int todoId, ToDo updatedTodo)
        {
            var existingTodo = _todos.ToDo.Find(todoId);
            if (existingTodo == null)
            {
                return null;
            }
            existingTodo.Name = updatedTodo.Name;
            existingTodo.StartDate = updatedTodo.StartDate;
            existingTodo.EndDate = updatedTodo.EndDate;

            _todos.SaveChanges();
            return existingTodo;
        }

        public ErrorOr<Deleted> DeleteTodo(int todoId)
        {
            ToDo toDoToBeDeleted = _todos.ToDo.SingleOrDefault(u => u.ToDoId == todoId); //el usuario a borrar va a existir en la BBDD porque el userId viene del token del usuario que inició sesión. Si inicia sesión, su usuario ya existe.
            toDoToBeDeleted.State = false; //borrado lógico. El usuario seguirá en la BBDD pero con un state 0 (false)
            _todos.Update(toDoToBeDeleted);
            _todos.SaveChanges();
            return Result.Deleted;
        }
    }
}
