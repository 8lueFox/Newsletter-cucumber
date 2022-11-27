using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsletter.Infrastructure.Entities;
using Newsletter.Infrastructure.Interfaces;
using Newsletter.Infrastructure.Requests;

namespace Newsletter.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewsletterMembersController : ControllerBase
{
    private readonly INewsletterService _newsletterService;

    public NewsletterMembersController(INewsletterService newsletterService)
        => _newsletterService = newsletterService;

    [HttpGet]
    public async Task<List<Contact>> GetAllMembers()
        => await _newsletterService.GetAllMembers();

    [HttpPost]
    public async Task<bool> AddMember([FromBody]AddMemberRequest request)
        => await _newsletterService.AddToNewsletter(request.Name, request.Email);

    [HttpDelete]
    public async Task<bool> DeleteMember([FromBody] DeleteMemberRequest request)
        => await _newsletterService.RemoveFromNewsletter(request.Email);

}
