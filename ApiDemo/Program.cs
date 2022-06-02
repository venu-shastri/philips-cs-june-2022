using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApiDemo.DBContexts.PatientsDataContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:localdbConnection"]);
    

},ServiceLifetime.Singleton);

builder.Services.AddSingleton(
    typeof(ApiDemo.DataRepositories.IPatientInfoDataRepository),
    typeof(ApiDemo.DataRepositories.PatientInfoORMRepository));

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapControllers();

app.Run();

