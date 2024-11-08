var builder = WebApplication.CreateBuilder(args);

// Додаємо необхідні сервіси для MVC (Controllers with Views)
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<LogActionFilter>();   // Реєструємо фільтр для логування
    options.Filters.Add<UniqueUserFilter>();  // Реєструємо фільтр для підрахунку унікальних користувачів
});

// Додаємо наші фільтри як сервіси, щоб їх можна було використовувати
builder.Services.AddScoped<LogActionFilter>();
builder.Services.AddScoped<UniqueUserFilter>();

var app = builder.Build();

// Налаштування для середовища розробки
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
