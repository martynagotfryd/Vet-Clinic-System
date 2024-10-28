namespace VetClinic.Models.Services;

[Serializable]
public class Other : Service
{
    public Other(decimal price, string description, List<Service>? subServices = null)
        : base(price, description, subServices)
    {
    }
}
