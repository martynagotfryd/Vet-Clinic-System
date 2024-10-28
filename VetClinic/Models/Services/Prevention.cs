namespace VetClinic.Models.Services;

[Serializable]
public class Prevention : Service
{
    private int _testsNum;
    private int _vaccinationNum;

    public Prevention(decimal price, string description, int testsNum, int vaccinationNum, List<Service>? subServices = null)
        : base(price, description, subServices)
    {
        TestsNum = testsNum;
        VaccinationNum = vaccinationNum;
    }

    public int TestsNum
    {
        get => _testsNum;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Number of tests cannot be negative.");
            }
            _testsNum = value;
        }
    }

    public int VaccinationNum
    {
        get => _vaccinationNum;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Number of vaccinations cannot be negative.");
            }
            _vaccinationNum = value;
        }
    }
}
