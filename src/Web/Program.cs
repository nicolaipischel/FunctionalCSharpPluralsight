using Application;
using Models.Types;
using Models.Types.Components;
using TestPersistence;
using Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IReadOnlyRepository<Part>, PartsReadRepository>();
builder.Services.Configure<BarcodeFormatOptions>(builder.Configuration.GetSection(BarcodeFormatOptions.SectionKeyName));
builder.Services.AddSingleton<BarcodeGeneratorFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
