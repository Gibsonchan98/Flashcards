using DataAccess; 
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDatabaseRepo, DBRepo>(ctx => new DBRepo(builder.Configuration.GetConnectionString("Server=tcp:flashcard.database.windows.net,1433;Initial Catalog=FlashDB;Persist Security Info=False;User ID=CloudSA03a93605;Password=123456F!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")));
builder.Services.AddScoped<FService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
