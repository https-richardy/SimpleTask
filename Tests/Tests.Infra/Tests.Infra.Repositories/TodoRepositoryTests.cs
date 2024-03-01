namespace HttpsRichardy.SimpleTask.Tests.Infra.Repositories;

# pragma warning disable
public class TodoRepositoryTests : IAsyncLifetime
{
    private readonly AppDbContext _dbContext;
    private readonly ITodoRepository _todoRepository;
    private readonly IFixture _fixture;

    public TodoRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _dbContext = new AppDbContext(options);
        _todoRepository = new TodoRepository(_dbContext);

        _fixture = new Fixture();
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    public async Task DisposeAsync()
    {
        await _dbContext.Database.EnsureDeletedAsync();
        await _dbContext.DisposeAsync();
    }

    public async Task InitializeAsync()
    {
        await _dbContext.Database.EnsureCreatedAsync();
    }

    [Fact]
    public async Task GivenNewTodo_WhenSaveAsyncCalled_ThenShouldBeInsertedIntoDatabase()
    {
        var newTodo = _fixture.Create<ToDo>();
        await _todoRepository.SaveAsync(newTodo);

        var savedTodo = await _dbContext.ToDos.FindAsync(newTodo.Id);

        Assert.NotNull(savedTodo);
        Assert.Equal(newTodo.Id, savedTodo.Id);
    }

    [Fact]
    public async Task GivenExistingTodo_WhenUpdateAsyncCalled_ThenShouldBeUpdatedInDatabase()
    {
        var existingTodo = _fixture.Create<ToDo>();
        await _todoRepository.SaveAsync(existingTodo);

        var updatedTodo = _fixture.Build<ToDo>()
            .With(t => t.Id, existingTodo.Id)
            .With(t => t.Title, "updated title")
            .Create();

        await _todoRepository.UpdateAsync(updatedTodo);
        var retrievedTodo = await _dbContext.ToDos.FindAsync(existingTodo.Id);

        Assert.NotNull(retrievedTodo);
        Assert.Equal(existingTodo.Id, retrievedTodo.Id);
        Assert.NotEqual(existingTodo.Title, retrievedTodo.Title);
    }
}