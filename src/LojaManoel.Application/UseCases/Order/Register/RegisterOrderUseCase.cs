using LojaManoel.Communication.Requests.Order;
using LojaManoel.Communication.Requests.Product;
using LojaManoel.Communication.Responses.Order;
using LojaManoel.Communication.Responses.Product;
using LojaManoel.Domain.Entities;
using LojaManoel.Domain.Repositories;
using LojaManoel.Domain.Repositories.Orders;

namespace LojaManoel.Application.UseCases.Order.Register;

public class RegisterOrderUseCase : IRegisterOrderUseCase
{
    private static readonly List<Box> AvailableBoxes = new List<Box>
    {
        new Box { Id = 1, Name = "Caixa 1", Description = "Caixa 30, 40, 80", Height = 30, Width = 40, Length = 80 },
        new Box { Id = 2, Name = "Caixa 2", Description = "Caixa 80, 50, 40", Height = 80, Width = 50, Length = 40 },
        new Box { Id = 3, Name = "Caixa 3", Description = "Caixa 50, 80, 60", Height = 50, Width = 80, Length = 60 }
    };

    private readonly IOrdersWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterOrderUseCase(IOrdersWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ResponseRegisteredOrderJson> Execute(RequestOrderJson request)
    {
        Validate(request);
        
        var sortedProducts = new List<RequestProductJson>(request.Products)
            .OrderByDescending(p => p.Height + p.Width + p.Length)
            .ToList();
        var boxes = new List<UsedBox>();
       
       
        foreach (var product in sortedProducts)
        {
            bool placedInBox = false;
            
            // Try to place the product in an existing used box
            foreach (var box in boxes)
            {
                if (FitsInBox(product, box))
                {
                    placedInBox = true;
                    break;
                }
            }

            // If the product was not placed in any existing box, create a new used box
            if (!placedInBox)
            {
                var newUsedBox = CreateUsedBox(product);
                if (newUsedBox == null)
                {
                    throw new Exception("Could not create used box");
                }
                boxes.Add(newUsedBox);
            }
        }

        // Adding Order to database
        var order = new Domain.Entities.Order
        {
            OrderId = request.OrderId,
            Description = boxes.Select(b => "Box: " + b.Name + ", Products: " + string.Join(", ", b.Products.Select(p => p.Name)))
                .Aggregate((current, next) => current + "; " + next)
        };
        
        await _repository.Add(order);
        await _unitOfWork.Commit();
        
        return new ResponseRegisteredOrderJson
        {
            OrderId = order.OrderId,
            InternalId = order.Id,
            Boxes = boxes.Select(b => new ResponseBoxJson
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                Products = b.Products
            }).ToList()
        };

    }

    private UsedBox CreateUsedBox(RequestProductJson product)
    {
        foreach (var box in AvailableBoxes)
        {
            if (product.Height <= box.Height && 
                product.Width <= box.Width && 
                product.Length <= box.Length)
            {
                return new UsedBox
                {
                    Id = box.Id,
                    Name = box.Name,
                    Description = box.Description,
                    Height = box.Height,
                    Width = box.Width,
                    Length = box.Length,
                    HeightUsed = product.Height,
                    WidthUsed = product.Width,
                    LengthUsed = product.Length,
                    Products = new List<ResponseProductJson> { new ResponseProductJson
                        {
                            Id = product.Id,
                            Name = product.Name,
                        }
                    }
                };
            }
        }
        return null;
    }

    private bool FitsInBox(RequestProductJson product, UsedBox usedBox)
    {
        if (product.Height > usedBox.Height ||
            product.Width > usedBox.Width ||
            product.Length > usedBox.Length)
        {
            return false;
        }
        
        var newHeight = usedBox.HeightUsed + product.Height;
        var newWidth = usedBox.WidthUsed + product.Width;
        var newLength = usedBox.LengthUsed + product.Length;
        
        if (newHeight > usedBox.Height || newWidth > usedBox.Width || newLength > usedBox.Length)
        {
            return false;
        }
        
        usedBox.HeightUsed = newHeight;
        usedBox.WidthUsed = newWidth;
        usedBox.LengthUsed = newLength;
        usedBox.Products.Add(new ResponseProductJson
        {
            Id = product.Id,
            Name = product.Name,
        });
        return true;
    }

    
    
    private void Validate(RequestOrderJson request)
    {
        // Check if products mesurements are valid
        if (request.Products == null || request.Products.Count == 0)
        {
            throw new ArgumentException("Order must contain at least one product.");
        }
        foreach (var product in request.Products)
        {
            if (product.Height == 0 || product.Width == 0 || product.Length == 0)
            {
                throw new ArgumentException("Product measurements must be greater than zero.");
            }
        }
    }
}