using BetterReads.Api.Exceptions.Infrastructure;
using BetterReads.Data;
using BetterReads.Data.Enums;
using DocumentFormat.OpenXml.CustomXmlSchemaReferences;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BetterReadsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        serverOptions => serverOptions.MigrationsAssembly(typeof(BetterReadsContext).Assembly.FullName));
});

builder.Services.AddMediatR(typeof(Program).Assembly).AddExceptionHandlers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Better Reads",
        Description = "Keep track of all the books you want to read, are currently reading and have read.",
        TermsOfService = null,
        Contact = new OpenApiContact
            { Name = "George Fox", Email = "george.fox@razor.co.uk", Url = null }
    });
    var filePath = Path.Combine(AppContext.BaseDirectory, "BetterReads.Api.xml");
    c.IncludeXmlComments(filePath);
    
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var betterReadsContext = services.GetRequiredService<BetterReadsContext>();
    betterReadsContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpContextExceptionHandling();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();