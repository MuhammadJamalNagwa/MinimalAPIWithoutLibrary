using Microsoft.EntityFrameworkCore;
using Repository_With_UOW.EntityFrameworkCore.Services;
using UserMinimal.API.Data;
using UserMinimal.API.Endpoints;
using UserMinimal.API.Interfaces;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped<IUserRepository, UserRepository>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen();

}

WebApplication? app = builder.Build();
{
    // Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapUserEndpoints();

    app.UseHttpsRedirection();
}

app.Run();
