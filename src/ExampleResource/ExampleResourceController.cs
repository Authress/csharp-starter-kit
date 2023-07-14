using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Authress.SDK.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthressStarterKit.Controllers;

[ApiController]
[Route("example-resource")]
[Authorize]
public class ExampleResourceController : ControllerBase
{
    private readonly ILogger<ExampleResourceController> _logger;

    public ExampleResourceController(ILogger<ExampleResourceController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{resourceId}")]
    public async Task<IActionResult> GetExampleResource([FromRoute] string resourceId)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await AuthressConfiguration.GetAuthressClient().AuthorizeUser(userId, $"resources/example-resource/{resourceId}", "READ");
            return Ok(new ExampleResource{ ResourceId = resourceId });
        } catch (NotAuthorizedException error)
        {
            System.Console.WriteLine(error);
            return Unauthorized();
        }
    }

    [HttpPost()]
    public async Task<IActionResult> CreateExampleResource([FromBody, Required] ExampleResource exampleResource)
    {
        var newResourceId = "New-Resource-ID";
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await AuthressConfiguration.GetAuthressClient().AuthorizeUser(userId, $"resources/example-resource/{newResourceId}", "CREATE");

            exampleResource.ResourceId = newResourceId;
            return Ok(exampleResource);
        } catch (NotAuthorizedException error)
        {
            System.Console.WriteLine(error);
            return Unauthorized();
        }
    }
}