using Microsoft.EntityFrameworkCore;
using VoucherOnUs.EF.EntityFramework.DAL;
using VoucherOnUs.EF.EntityFramework.Interfaces;
using VoucherOnUs.EF.EntityFramework.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("VouchersForUsDB");
builder.Services.AddDbContext<VouchersOnUsDBContext>(options => options.UseSqlServer(connectionString));

Bulk_EF_AddToScope(builder.Services);
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();



//Clear distinction of Scope Added
void Bulk_EF_AddToScope(IServiceCollection services)
{
    services.AddScoped<iVouchersOnUsDbContext, VouchersOnUsDBContext>();

    builder.Services.AddScoped<IProvidersRepository, ProvidersRepository>();
    builder.Services.AddScoped<IVouchersRepository, VouchersRepository>();
    builder.Services.AddScoped<IUsersRepository, UsersRepository>();
    builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();

    services.AddScoped<IUnitOfWork, UnitOfWork>();

}
