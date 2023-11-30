namespace AllSpice.Models;

public class Account : Profile
{
  // These are hidden as our account inherits through our profile class.
  // public string Id { get; set; }
  // public string Name { get; set; }
  // public string Picture { get; set; }
  public string Email { get; set; }
}
