using ErrorOr;
using System.Collections.Generic;
using TODOLIST.Data.Entities;

namespace TODOLIST.Services.Interfaces
{
    public interface IToDoService
    {
        List<ToDo> GetAllToDos();
        ToDo GetTodoById(int todoId);
        ToDo CreateTodo(ToDo toDo);
        ToDo UpdateTodo(int todoId, ToDo updatedTodo);
        bool DeleteTodo(int todoId);
    }
}
