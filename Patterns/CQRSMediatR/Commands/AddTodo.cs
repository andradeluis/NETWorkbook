using MediatR;
using MediatRExample.Database;
using MediatRExample.Domain;

namespace MediatRExample.Commands
{
    // Static class only for example purposes
    public static class AddTodo
    {
        // Command
        // All the data we need to execute
        public record Command(Todo todo) : IRequest<int>;

        // Handler
        // All the business logic to execute. Returns a response
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly Repository repository;

            public Handler(Repository repository)
            {
                this.repository = repository;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                repository.Todos.Add(new Todo()
                {
                    Id = repository.Todos.Count + 1,
                    Name = request.todo.Name,
                    Completed = request.todo.Completed,
                });

                return repository.Todos.Count;
            }
        }
    }
}
