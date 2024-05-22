using CarBuilder.Models;

List<Interior> interiors = new List<Interior>
{
    new Interior()
    {
        Id = ,
        Price = ,
        Material = ""
    }
};

List<Order> orders = new List<Order>
{
    new Order()
    {
        Id = ,
        TimeStamp = ,
        WheelId = ,
        TechnologyId = ,
        PaintId = ,
        InteriorId =
    }
};

List<PaintColor> paintColors = new List<PaintColor>
{
    new PaintColor()
    {
        Id = ,
        Price = ,
        Color = ""
    }
};

List<Technology> technologies = new List<Technology>
{
    new Technology()
    {
        Id = ,
        Price = ,
        Package = ""
    }
};

List<Wheel> wheels = new List<Wheel>
{
    new Wheel()
    {
        Id = ,
        Price = ,
        Style = "",
    }
};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
