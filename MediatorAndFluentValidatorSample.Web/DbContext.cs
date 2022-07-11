using MediatrAndFluentValidationSample.Models;

namespace MediatrAndFluentValidationSample;

public class DbContext
{
    private static readonly List<User> users = new List<User>
    {
        new User
        {
            Id = 1,
            FirstName = "Kuzma",
            LastName = "Petrenko",
            Email = "k.petrenko@test.com"
        },
        new User
        {
            Id = 2,
            FirstName = "Petro",
            LastName = "Kuzmenko",
            Email = "p.kuzmenko@test.com"
        },
        new User
        {
            Id = 3,
            FirstName = "Mikhailo",
            LastName = "Petrenko",
            Email = "m.petrenko@test.com"
        }
    };

    public List<User> Users
    {
        get => users;
    }
}