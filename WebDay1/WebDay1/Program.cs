using Microsoft.EntityFrameworkCore;
using WebDay1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//*
string cns_str = builder.Configuration.GetConnectionString("DataContext");

builder.Services.AddDbContext<DataContext>(options =>options.UseSqlite(cns_str));
//*/

builder.Services.AddSingleton<WebDay1.Rubrica>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
