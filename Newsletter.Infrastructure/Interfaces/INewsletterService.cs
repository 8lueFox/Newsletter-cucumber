using Newsletter.Infrastructure.Entities;

namespace Newsletter.Infrastructure.Interfaces;

public interface INewsletterService
{
    Task<bool> AddToNewsletter(string name, string email);

    Task<bool> RemoveFromNewsletter(string email);

    Task<List<Contact>> GetAllMembers();
}
