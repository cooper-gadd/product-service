using ProductService.Models;

var products = new List<Product>
{
    new Product { Id = 1, Name = "Apples", Price = 3.99M },
    new Product { Id = 2, Name = "Peaches", Price = 4.05M },
    new Product { Id = 3, Name = "Pumpkin", Price = 13.99M },
    new Product { Id = 4, Name = "Pie", Price = 8.00M }
};

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Run();
