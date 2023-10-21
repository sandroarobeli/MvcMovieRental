var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Creating Custom Routes. ORDER NATTERS HERE: FROM MOST SPECIFIC ==> TO MOST GENERIC
app.MapControllerRoute(
    name: "FilmsByReleaseDate",
    pattern: "films/released/{year}/{month}",
    new { controller = "Films", action = "ByReleaseDate" },
    // Apply constraints:
    new { year = @"\d{4}", month = @"\d{2}" }
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
