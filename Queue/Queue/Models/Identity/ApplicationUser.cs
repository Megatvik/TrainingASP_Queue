using Microsoft.AspNet.Identity.EntityFramework;

public class ApplicationUser : IdentityUser
{
    public string Role { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public bool isBaned { get; set; }

    public ApplicationUser()
    {
    }
}


