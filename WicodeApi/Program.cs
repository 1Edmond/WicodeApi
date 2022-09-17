var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WicodeApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WicodeApiContext") ?? throw new InvalidOperationException("Connection string 'WicodeApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CryptoAPi",
        Description = "Api de l'applicaiton de crytprographie",
        Contact = new OpenApiContact
        {
            Name = "Honyiglo Wilfried",
        },
        License = new OpenApiLicense
        {
            Name = "+228 92 08 07 70",
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseHsts();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
