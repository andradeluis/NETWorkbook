using MediatRExample.Domain;

namespace MediatRExample.Database
{
    public class Repository
    {
        public List<Todo> Todos { get; } = new List<Todo>()
        {
            new Todo(){ Id = 1, Name = "Cook dinner", Completed = false },
            new Todo(){ Id = 2, Name = "Make youtube video", Completed = true },
            new Todo(){ Id = 3, Name = "Wash car", Completed = false }
        };
    }
}
