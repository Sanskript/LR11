var builder = WebApplication.CreateBuilder(args);

// ������ �������� ������ ��� MVC (Controllers with Views)
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<LogActionFilter>();   // �������� ������ ��� ���������
    options.Filters.Add<UniqueUserFilter>();  // �������� ������ ��� ��������� ��������� ������������
});

// ������ ���� ������� �� ������, ��� �� ����� ���� ���������������
builder.Services.AddScoped<LogActionFilter>();
builder.Services.AddScoped<UniqueUserFilter>();

var app = builder.Build();

// ������������ ��� ���������� ��������
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
