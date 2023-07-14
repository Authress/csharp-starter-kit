using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthressStarterKit.Controllers;

[ApiController]
[Route("/example-resource")]
[Authorize]
public class ExampleResourceController : ControllerBase
{
    private readonly ILogger<ExampleResourceController> _logger;

    public ExampleResourceController(ILogger<ExampleResourceController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetExampleResource")]
    public ExampleResource Get()
    {
        return new ExampleResource{ ResourceId = "New-Resource-ID" };
    }

    [HttpPost(Name = "CreateExampleResource")]
    public ExampleResource CreateExampleResource()
    {
        return new ExampleResource{ ResourceId = "New-Resource-ID" };
    }
}