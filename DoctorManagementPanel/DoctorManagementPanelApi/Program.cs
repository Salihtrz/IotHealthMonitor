using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DoctorManagementPanelApi.Hubs;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(host => true).AllowCredentials();
    });
});
builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi  
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<DoctorManagementPanelContext>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EFAboutDal>();
builder.Services.AddScoped<IDoctorService, DoctorManager>();
builder.Services.AddScoped<IDoctorDal, EFDoctorDal>();
builder.Services.AddScoped<IPatientService, PatientManager>();
builder.Services.AddScoped<IPatientDal, EFPatientDal>();
builder.Services.AddScoped<IBranchService, BranchManager>();
builder.Services.AddScoped<IBranchDal, EFBranchDal>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EFContactDal>();
builder.Services.AddScoped<IPulseService, PulseManager>();
builder.Services.AddScoped<IPulseDal, EFPulseDal>();
builder.Services.AddScoped<ISpO2Service, SpO2Manager>();
builder.Services.AddScoped<ISpO2Dal, EFSpO2Dal>();
builder.Services.AddScoped<IDeviceService, DeviceManager>();
builder.Services.AddScoped<IDeviceDal, EFDeviceDal>();
builder.Services.AddScoped<IPatientsRelativeService, PatientsRelativeManager>();
builder.Services.AddScoped<IPatientsRelativeDal, EFPatientsRelativeDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();
