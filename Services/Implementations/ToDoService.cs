
using System.Collections.Generic;
using System.Linq;
using TODOLIST.Data.Entities;
using TODOLIST.Services.Interfaces;
using TODOLIST.DBContext;
using Microsoft.EntityFrameworkCore;

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
            var newTodoId = _todos.ToDo.Add(todo);
            return todo;
        }

        public ToDo UpdateTodo(int todoId, ToDo updatedTodo)
        {
            var existingTodo = _todos.ToDo.FirstOrDefault(t => t.ToDoId == todoId);
            if (existingTodo != null)
            {
                existingTodo.Name = updatedTodo.Name;
                existingTodo.StartDate = updatedTodo.StartDate;
                existingTodo.EndDate = updatedTodo.EndDate;
            }

            return existingTodo;
        }

        public void DeleteTodo(int todoId)
        {
            var todo = _todos.ToDo.FirstOrDefault(t => t.ToDoId == todoId);
            if (todo != null)
            {
                _todos.Remove(todo);
            }
        }
    }
}
