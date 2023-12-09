using DotnetGraphQLAppClient.Consumers;
using DotnetGraphQLAppClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGraphQLAppClient.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly OwnerConsumer _consumer;

    public ValuesController(OwnerConsumer consumer)
    {
        _consumer = consumer;
    }

    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> Get()
    {
        var owners = await _consumer.GetAllOwners();
        return Ok(owners);
    }

    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> Get([FromQuery] Guid id)
    {
        var owners = await _consumer.GetOwner(id);
        return Ok(owners);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] OwnerInput owner)
    {
        var owners = await _consumer.CreateOwner(owner);
        return Ok(owners);
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update([FromBody] OwnerInput owner, [FromQuery] Guid id)
    {
        var owners = await _consumer.UpdateOwner(id ,owner);
        return Ok(owners);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> Delete([FromQuery] Guid id)
    {
        var owners = await _consumer.DeleteOwner(id);
        return Ok(owners);
    }
}
