using Microsoft.EntityFrameworkCore;
using MoviesWebAPI.Data;
using MoviesWebAPI.Repositories.Genres;
using MoviesWebAPI.Repositories.Movies;
using MoviesWebAPI.Repositories.Ratings;
using MoviesWebAPI.Repositories.Users;
using MoviesWebAPI.Repositories.Watchlist;
using MoviesWebAPI.Services.Genres;
using MoviesWebAPI.Services.Movies;
using MoviesWebAPI.Services.Ratings;
using MoviesWebAPI.Services.Users;
using MoviesWebAPI.Services.Watchlist;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    s.IncludeXmlComments(xmlPath);
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMovieRepository,MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGenreRepository,GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IRatingsRepository, RatingsRepository>();
builder.Services.AddScoped<IRatingsService, RatingsService>();
builder.Services.AddScoped<IWatchlistRepository, WatchlistRepository>();
builder.Services.AddScoped<IWatchlistService, WatchlistService>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");
app.UseHttpsRedirection();
app.UseAuthorization();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

AppDbInitializer.Seed(app);

app.Run();
