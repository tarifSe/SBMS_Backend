using Microsoft.EntityFrameworkCore;
using SBMS.BLL.Managers;
using SBMS.BLL.Services;
using SBMS.DAL.Repositories;
using SBMS.DAL.Services;
using SBMS.DatabaseContexts.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SBMSDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("SBMSConnection")), ServiceLifetime.Transient);
//builder.Services.AddDbContext<SBMSDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("SBMSConnection")));

#region start service inject
builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

builder.Services.AddTransient<ISupplierManager, SupplierManager>();
builder.Services.AddTransient<ICategoryManager, CategoryManager>();
builder.Services.AddTransient<IProductManager, ProductManager>();
builder.Services.AddTransient<ICustomerManager, CustomerManager>();
#endregion end

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.WithOrigins("http://localhost:4200")
.AllowAnyMethod()
.AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
