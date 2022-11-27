namespace Newsletter.Infrastructure.Entities;

public class Contact
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Email { get; set; } = default!;
}
