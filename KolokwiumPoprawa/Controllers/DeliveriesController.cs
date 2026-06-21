using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KolokwiumPoprawa.Data;

namespace KolokwiumPoprawa.Controllers;

[ApiController] 
[Route("api/[controller]")]
public class DeliveriesController: ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DeliveriesController(ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpGet("deliveries/{id}")]
    public async Task<IActionResult> GetDeliveryProducts(int id)
    {

        var delivery = await _context.Deliveries
            .Include(d => d.Customer) 
            .Include(d => d.Driver)   
            .Include(d => d.ProductDeliveries) 
            .ThenInclude(pd => pd.Product) 
            .FirstOrDefaultAsync(d => d.DeliveryId == id); 
        
        if (delivery == null)
            return NotFound($"Delivery with ID {id} not found.");
        


        var result = new
        {
            date = delivery.Date.ToString("yyyy-MM-ddTHH:mm:ss"),
            customer = new
            {
                firstName = delivery.Customer.FirstName,
                lastName = delivery.Customer.LastName,
                dateOfBirth = delivery.Customer.DateOfBirth.ToString("yyyy-MM-ddTHH:mm:ss")
            },
            driver = new
            {
                firstName = delivery.Driver.FirstName,
                lastName = delivery.Driver.LastName,
                licenceNumber = delivery.Driver.LicenceNumber
            },
            products = delivery.ProductDeliveries.Select(pd => new
            {
                name = pd.Product.Name,
                price = pd.Product.Price,
                amount = pd.Amount
            })
        };


        return Ok(result); 
    }
    
}