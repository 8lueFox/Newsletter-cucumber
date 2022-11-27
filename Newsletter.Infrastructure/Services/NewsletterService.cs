using Newsletter.Infrastructure.Entities;
using Newsletter.Infrastructure.Interfaces;

namespace Newsletter.Infrastructure.Services;

public class NewsletterService : INewsletterService
{
    private List<Contact> _members;
    
    public NewsletterService()
    {
        _members = new();
    }
    
    public async Task<bool> AddToNewsletter(string name, string email)
    {
        if (string.IsNullOrEmpty(name) ||
            string.IsNullOrEmpty(email) ||
            _members.Any(m => m.Email == email))    
            return await Task.FromResult(false);

        _members.Add(new Contact
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email
        });

        return await Task.FromResult(true);
    }

    public async Task<bool> RemoveFromNewsletter(string email)
    {
        var member = _members.FirstOrDefault(m => m.Email == email);

        if(member is null)
            return await Task.FromResult(false);

        _members.Remove(member);

        return await Task.FromResult(true);
    }

    public async Task<List<Contact>> GetAllMembers()
    {
        return await Task.FromResult(_members);
    }
}
