using MovieApp.Services.Interfaces;
using MovieApp.Services;
using MovieApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IActorService, ActorService>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddControllers();
// todo: Move out connectoin string to config
builder.Services.AddSqlServer<MovieAppDbContext>("Server=.;Database=MovieAppDB;Trusted_Connection=True;TrustServerCertificate=true;");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//cors setup
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontendUrl = configuration.GetValue<string>("frontend_url");

    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendUrl).AllowAnyMethod().AllowAnyHeader();
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
