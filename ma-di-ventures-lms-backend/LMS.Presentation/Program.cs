using LMS.Application.Admins.Commands.CreateStudent;
using LMS.Infrastructure.DatabaseContext;
using LMS.Infrastructure.DI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LMSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services
builder.Services.AddInfrastructure();

// Add MediatR - register handlers from the assembly containing your handlers
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblyContaining<AddStudentCommandHandler>();
});

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();