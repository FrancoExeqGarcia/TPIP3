
using System.Collections.Generic;
using System.Linq;
using TODOLIST.Data.Entities;
using TODOLIST.Services.Interfaces;

namespace TODOLIST.Services.Implementations
{
    public class TodoService : IToDoService
    {
        private readonly List<ToDo> _todos;

        public TodoService()
        {
            _todos = new List<ToDo>();
        }

        public List<ToDo> GetAllToDos()
        {
            return _todos.ToList();
        }

        public ToDo GetTodoById(int todoId)
        {
            return _todos.FirstOrDefault(t => t.ToDoId == todoId);
        }

        public ToDo CreateTodo(ToDo todo)
        {
            int newTodoId = _todos.Count > 0 ? _todos.Max(t => t.ToDoId) + 1 : 1;
            todo.ToDoId = newTodoId;
            _todos.Add(todo);
            return todo;
        }

        public ToDo UpdateTodo(int todoId, ToDo updatedTodo)
        {
            var existingTodo = _todos.FirstOrDefault(t => t.ToDoId == todoId);

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
            var todo = _todos.FirstOrDefault(t => t.ToDoId == todoId);
            if (todo != null)
            {
                _todos.Remove(todo);
            }
        }
    }
}
