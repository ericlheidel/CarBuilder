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

List<Order> orders = new List<Order>
{
    new Order()
    {
        Id = 1,
        TimeStamp = null,
        WheelId = 1,
        TechnologyId = 1,
        PaintColorId = 1,
        InteriorId = 1
    },
    new Order()
    {
        Id = 2,
        TimeStamp = null,
        WheelId = 2,
        TechnologyId = 2,
        PaintColorId = 2,
        InteriorId = 2
    },
    new Order()
    {
        Id = 3,
        TimeStamp = null,
        WheelId = 4,
        TechnologyId = 4,
        PaintColorId = 4,
        InteriorId = 4
    },
    new Order()
    {
        Id = 4,
        TimeStamp = null,
        WheelId = 4,
        TechnologyId = 4,
        PaintColorId = 4,
        InteriorId = 4
    },
    new Order()
    {
        Id = 5,
        TimeStamp = new DateTime(2024,05,05),
        WheelId = 1,
        TechnologyId = 1,
        PaintColorId = 1,
        InteriorId = 1
    }
};

List<PaintColor> paintColors = new List<PaintColor>
{
    new PaintColor()
    {
        Id = 1,
        Price = 1255.99M,
        Color = "Silver"
    },
    new PaintColor()
    {
        Id = 2,
        Price = 1355.99M,
        Color = "Midnight Blue"
    },
    new PaintColor()
    {
        Id = 3,
        Price = 1455.99M,
        Color = "Firebrick Red"
    },
    new PaintColor()
    {
        Id = 4,
        Price = 1555.99M,
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
builder.Services.AddCors(); //!

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(options => //!
    {
        options.AllowAnyOrigin(); //!
        options.AllowAnyMethod(); //!
        options.AllowAnyHeader(); //!
    }); //!
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

app.MapGet("/orders", (int? paintColorId) =>
{
    List<OrderDTO> ordersDTO = new List<OrderDTO>();

    List<Order> filteredOrders = orders.Where(o => !o.Fulfilled).ToList();

    if (paintColorId != null)
    {
        filteredOrders = filteredOrders.Where(o => o.PaintColorId == paintColorId).ToList();

        if (filteredOrders == null)
        {
            return null;
        }
    }

    foreach (Order order in filteredOrders)
    {
        Wheel? wheel = wheels.FirstOrDefault(w => w.Id == order.WheelId);
        Technology? technology = technologies.FirstOrDefault(t => t.Id == order.TechnologyId);
        PaintColor? paintColor = paintColors.FirstOrDefault(pc => pc.Id == order.PaintColorId);
        Interior? interior = interiors.FirstOrDefault(i => i.Id == order.InteriorId);

        OrderDTO orderDTO = new OrderDTO
        {
            Id = order.Id,
            TimeStamp = order.TimeStamp,
            WheelId = order.WheelId,
            Wheel = wheel == null ? null : new WheelDTO
            {
                Id = wheel.Id,
                Price = wheel.Price,
                Style = wheel.Style
            },
            TechnologyId = order.TechnologyId,
            Technology = technology == null ? null : new TechnologyDTO
            {
                Id = technology.Id,
                Price = technology.Price,
                Package = technology.Package
            },
            PaintColorId = order.PaintColorId,
            PaintColor = paintColor == null ? null : new PaintColorDTO
            {
                Id = paintColor.Id,
                Price = paintColor.Price,
                Color = paintColor.Color
            },
            InteriorId = order.InteriorId,
            Interior = interior == null ? null : new InteriorDTO
            {
                Id = interior.Id,
                Price = interior.Price,
                Material = interior.Material
            },
        };

        ordersDTO.Add(orderDTO);
    }

    return Results.Ok(ordersDTO);
});


//++ /\\\\\\\\\\\\\        /\\\\\         /\\\\\\\\\\\    /\\\\\\\\\\\\\\\
//++ \/\\\/////////\\\    /\\\///\\\     /\\\/////////\\\ \///////\\\/////
//++  \/\\\       \/\\\  /\\\/  \///\\\  \//\\\      \///        \/\\\
//++   \/\\\\\\\\\\\\\/  /\\\      \//\\\  \////\\\               \/\\\
//++    \/\\\/////////   \/\\\       \/\\\     \////\\\            \/\\\
//++     \/\\\            \//\\\      /\\\         \////\\\         \/\\\
//++      \/\\\             \///\\\  /\\\    /\\\      \//\\\        \/\\\
//++       \/\\\               \///\\\\\/    \///\\\\\\\\\\\/         \/\\\
//++        \///                  \/////        \///////////           \///

app.MapPost("/orders", (Order order) =>
{
    order.Id = orders.Max(o => o.Id) + 1;
    order.TimeStamp = DateTime.Now;
    orders.Add(order);

    return Results.Created($"/orders/{order.Id}", new Order
    {
        Id = order.Id,
        TimeStamp = order.TimeStamp,
        WheelId = order.WheelId,
        TechnologyId = order.TechnologyId,
        PaintColorId = order.PaintColorId,
        InteriorId = order.InteriorId
    });
});

app.Run();