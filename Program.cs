namespace Employee;


public class Employee
{
    public string name { get; set; }
    public int id { get; set; }
    public float salary { get; set; }

    public Employee(string name, int id)
    {
        this.name = name;
        this.id = id;
        salary = 0;
    }

    public float ApplyBonus(float threshold, float bonus)
    {
        float total = salary;
        if (salary > threshold)
        {
            salary += bonus;
          
        }
        return total;
        
        
    }
}

public class RegularEmployee : Employee
{
    public float FixedRate = 3000;

    public RegularEmployee(string name, int id) : base(name, id)
    {
        this.name=name;
        this.id=id;
    }

    public float CalculateSalary()
    {
        salary = FixedRate;
        return salary;

    }
    
}

public class HourlyEmployee : Employee
{
    public float HoursWorked { get; set; }
    public float HourlyRate { get; set; }

    public HourlyEmployee(string name, int id, float HoursWorked, float HourlyRate) : base(name, id)
    {
        this.HoursWorked = HoursWorked;
        this.HourlyRate = HourlyRate;
    }

    public float CalculateSalary()
    {
        salary = HoursWorked * HourlyRate;
        return salary;
    }
}