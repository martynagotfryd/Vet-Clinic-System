namespace VetClinic.Models.Services;

[Serializable]
public class Surgery : Service
{
    private int _time; 
    private string _difficulty;

    public Surgery(decimal price, string description, int time, string difficulty, List<Service>? subServices = null)
        : base(price, description, subServices)
    {
        Time = time;
        Difficulty = difficulty;
    }

    public int Time
    {
        get => _time;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Time must be positive.");
            }
            _time = value;
        }
    }

    public string Difficulty
    {
        get => _difficulty;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Difficulty cannot be null or empty.");
            }
            _difficulty = value;
        }
    }
}
