using Microsoft.AspNetCore.Mvc;

namespace WebApp_example;

[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{
    private readonly IService _service;
    
    public Controller(IService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return _service.GetAsync();
    }
    
}