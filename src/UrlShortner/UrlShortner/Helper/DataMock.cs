using UrlShortner.Models;

namespace UrlShortner.Helper;

public class DataMock
{
    public static readonly List<User> Users =
    [
        new User { FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com", Password = "password123", PasswordSalt = "a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a11", Roles = ["Emperor", "Priest"] },
        new User { FirstName = "Bob", LastName = "Smith", Email = "bob.smith@example.com", Password = "password456", PasswordSalt = "1c3e7bda-9e5b-4c7c-b47d-6d79f530d117", Roles = ["Deacon"] },
        new User { FirstName = "Charlie", LastName = "Brown", Email = "charlie.brown@example.com", Password = "password789", PasswordSalt = "2b2d4e4b-3c6d-4d8a-b9a5-6e14c3d7a1ff", Roles = ["Grand Wizard"] },
        new User { FirstName = "David", LastName = "Lee", Email = "david.lee@example.com", Password = "securepass", PasswordSalt = "3a6f2c6d-2e9b-4f9b-a5d5-6c11c6b7a2aa", Roles = ["Space Cowboy"] },
        new User { FirstName = "Emma", LastName = "Wilson", Email = "emma.wilson@example.com", Password = "password321", PasswordSalt = "4b7e3e5a-1d8b-4e8c-b9c5-6a10b7c3a3ee", Roles = ["Supreme Overlord"] },
        new User { FirstName = "Frank", LastName = "Davis", Email = "frank.davis@example.com", Password = "pass1234", PasswordSalt = "5c8f3f4b-0f9b-4d7b-b8a5-6e12c5d7a4ff", Roles = ["Chief Happiness Officer"] },
        new User { FirstName = "Grace", LastName = "Martinez", Email = "grace.martinez@example.com", Password = "secure123", PasswordSalt = "6d9f4d4b-0e8b-4c7b-b6a5-6c14c6b7a3ff", Roles = ["Emperor"] },
        new User { FirstName = "Henry", LastName = "Garcia", Email = "henry.garcia@example.com", Password = "password987", PasswordSalt = "7e1f5e5a-0d7b-4f9b-b7c5-6e16c5d7b2aa", Roles = ["Priest"] },
        new User { FirstName = "Robert", LastName = "Lopez", Email = "isabella.lopez@example.com", Password = "pass4567", PasswordSalt = "8f2f6f6b-0c6b-4e9b-b9a5-6a18c3b7b1ff", Roles = ["Deacon"] },
        new User { FirstName = "Jack", LastName = "Taylor", Email = "jack.taylor@example.com", Password = "pass6789", PasswordSalt = "9a3f7g7b-0b5b-4d7b-b8a5-6c19c4d7a2ff", Roles = ["Grand Wizard"] },
        new User { FirstName = "Katherine", LastName = "Clark", Email = "katherine.clark@example.com", Password = "secure567", PasswordSalt = "1b4f8h8b-0a4b-4c9b-b7a5-6e20c4d7b3aa", Roles = ["Space Cowboy"] },
        new User { FirstName = "Liam", LastName = "Lewis", Email = "liam.lewis@example.com", Password = "password890", PasswordSalt = "2c5f9i9b-0b3b-4d8b-b6a5-6a21c3b7a4ee", Roles = ["Supreme Overlord"] },
        new User { FirstName = "Mia", LastName = "Moore", Email = "mia.moore@example.com", Password = "pass8901", PasswordSalt = "3d6f0j0b-0c2b-4e7b-b5a5-6c22c2b7b1ff", Roles = ["Chief Happiness Officer"] },
        new User { FirstName = "Salam", LastName = "Morcos", Email = "salam.morcos+testspsd@gmail.com", Password = "oauth2.0", PasswordSalt = "n/a", Roles = ["Deacon"] }
    ];

    public static readonly List<string> Roles =
    [
        "Emperor",
        "Priest",
        "Deacon",
        "Grand Wizard",
        "Space Cowboy",
        "Supreme Overlord",
        "Chief Happiness Officer"
    ];

    public static readonly List<string> Permissions =
    [
        "AddCustomer",
        "EditCustomer",
        "DeleteCustomer",
        "ViewCustomerDetails",
        "ManageInventory",
        "PlaceOrders",
        "ManagePayments",
        "ViewReports",
        "AssignTasks",
        "ApproveExpenses",
        "ScheduleMeetings",
        "ManageProjects",
        "AccessSensitiveData",
        "GenerateReports",
        "ModerateDiscussions"
    ];

    public static readonly List<(string Role, string Permission)> RolesPermissionsMatrix =
    [
        ("Priest", "AddCustomer"),
        ("Priest", "EditCustomer"),
        ("Priest", "DeleteCustomer"),
        ("Priest", "ViewCustomerDetails"),
        ("Priest", "ManageInventory"),
        ("Priest", "PlaceOrders"),
        ("Priest", "ManagePayments"),
        ("Priest", "ViewReports"),
        ("Priest", "AssignTasks"),
        ("Emperor", "ApproveExpenses"),
        ("Emperor", "ScheduleMeetings"),
        ("Emperor", "ManageProjects"),
        ("Emperor", "AccessSensitiveData"),
        ("Deacon", "ScheduleMeetings"),
        ("Deacon", "AccessSensitiveData"),
        ("Grand Wizard", "GenerateReports"),
        ("Grand Wizard", "ModerateDiscussions"),
        ("Grand Wizard", "ViewReports"),
        ("Space Cowboy", "ViewCustomerDetails"),
        ("Space Cowboy", "ManageInventory"),
        ("Space Cowboy", "PlaceOrders"),
        ("Supreme Overlord", "ApproveExpenses"),
        ("Supreme Overlord", "ManageProjects"),
        ("Chief Happiness Officer", "ViewReports"),
        ("Chief Happiness Officer", "AssignTasks"),
        ("Chief Happiness Officer", "GenerateReports")
    ];

    public static User? GetUserByEmail(string email)
    {
        return Users.FirstOrDefault(user => user.Email!.Equals(email, StringComparison.OrdinalIgnoreCase));
    }
}
