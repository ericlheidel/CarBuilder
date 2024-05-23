using CarBuilder.Models;

List<Interior> interiors = new List<Interior>
{
    new Interior()
    {
        Id = 1,
        Price = 299.99M,
        Material = "Beige Fabric"
    },
    new Interior()
    {
        Id = 2,
        Price = 399.99M,
        Material = "Charcoal Fabric"
    },
    new Interior()
    {
        Id = 3,
        Price = 499.99M,
        Material = "White Leather"
    },
    new Interior()
    {
        Id = 4,
        Price = 599.99M,
        Material = "Black Leather"
    }
};

List<Order> orders = new List<Order> { };

List<PaintColor> paintColors = new List<PaintColor>
{
    new PaintColor()
    {
        Id = 1,
        Price = 125.99M,
        Color = "Silver"
    },
    new PaintColor()
    {
        Id = 2,
        Price = 135.99M,
        Color = "Midnight Blue"
    },
    new PaintColor()
    {
        Id = 3,
        Price = 145.99M,
        Color = "Firebrick Red"
    },
    new PaintColor()
    {
        Id = 4,
        Price = 155.99M,
        Color = "Spring Green"
    }
};

List<Technology> technologies = new List<Technology>
{
    new Technology()
    {
        Id = 1,
        Price = 1999.99M,
        Package = "Basic Package"
    },
    new Technology()
    {
        Id = 2,
        Price = 2999.99M,
        Package = "Navigation Package"
    },
    new Technology()
    {
        Id = 3,
        Price = 3999.99M,
        Package = "Visibility Package"
    },
    new Technology()
    {
        Id = 4,
        Price = 4999.99M,
        Package = "Ultra Package"
    }
};

List<Wheel> wheels = new List<Wheel>
{
    new Wheel()
    {
        Id = 1,
        Price = 599.99M,
        Style = "17-inch Radial",
    },
    new Wheel()
    {
        Id = 2,
        Price = 699.99M,
        Style = "17-inch Radial Black",
    },
    new Wheel()
    {
        Id = 3,
        Price = 799.99M,
        Style = "18-inch Spoke Silver",
    },
    new Wheel()
    {
        Id = 4,
        Price = 899.99M,
        Style = "18-inch Spoke Black",
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

//++   /\\\\\\\\\\\\   /\\\\\\\\\\\\\\\   /\\\\\\\\\\\\\\\
//++  /\\\//////////   \/\\\///////////   \///////\\\/////
//++  /\\\              \/\\\                    \/\\\
//++  \/\\\    /\\\\\\\  \/\\\\\\\\\\\            \/\\\
//++   \/\\\   \/////\\\  \/\\\///////             \/\\\
//++    \/\\\       \/\\\  \/\\\                    \/\\\
//++     \/\\\       \/\\\  \/\\\                    \/\\\
//++      \//\\\\\\\\\\\\/   \/\\\\\\\\\\\\\\\        \/\\\
//++        \////////////     \///////////////         \///

app.MapGet("/interiors", () =>
{
    return interiors.Select(i => new InteriorDTO
    {
        Id = i.Id,
        Price = i.Price,
        Material = i.Material
    });
});

app.MapGet("/paintcolors", () =>
{
    return paintColors.Select(pc => new PaintColorDTO
    {
        Id = pc.Id,
        Price = pc.Price,
        Color = pc.Color
    });
});

app.MapGet("/technologies", () =>
{
    return technologies.Select(t => new TechnologyDTO
    {
        Id = t.Id,
        Price = t.Price,
        Package = t.Package
    });
});

app.MapGet("/wheels", () =>
{
    return wheels.Select(w => new WheelDTO
    {
        Id = w.Id,
        Price = w.Price,
        Style = w.Style
    });
});

app.Run();