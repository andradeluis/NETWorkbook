using MediatR;
using MediatRExample.Database;

namespace MediatRExample.Queries
{
    // Static class only for example purposes
    public static class GetTodoById
    {
        // Query / command
        // All the data we need to execute
        public record Query(int id) : IRequest<Response>;

        // Handler
        // All the business logic to execute. Returns a response
        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly Repository repository;

            public Handler(Repository repository)
            {
                this.repository = repository;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                var todo = repository.Todos.FirstOrDefault(x => x.Id == request.id);
                return todo == null ? null : new Response(todo.Id, todo.Name, todo.Completed);
            }
        }

        // Response
        // The data we want to return
        public record Response(int id, string Name, bool Completed);
    }
}
