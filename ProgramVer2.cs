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
public class CommissionEmployee : Employee
{
    private float _salesAmount;
    private float _commissionRate;

    public float SalesAmount
    {
        get => _salesAmount;
        set
        {
            if (value >= 0)
                _salesAmount = value;
            else
                throw new ArgumentException("Sales amount cannot be negative");
        }
    }
    public float CommissionRate
    {
        get => _commissionRate;
        set
        {
            if (value >= 0)
                _commissionRate = value;
            else
                throw new ArgumentException("Commission rate cannot be negative");
        }
    }
    public CommissionEmployee(string name, int ID, float salesAmount, float commissionRate) : base(name, ID)
    {
        SalesAmount = salesAmount;
        CommissionRate = commissionRate;
    }
    public void CalculateSalary()
    {
        Salary = SalesAmount * CommissionRate;
    }

}
public class Program
{
    public static void Main(string[] args)
    {
        var alice = new RegularEmployee("Alice", 1);
        var bob = new HourlyEmployee("Bob", 2, 160, 20.5F);
        var charlie = new CommissionEmployee("Charlie", 3, 50000, 0.10F);

        alice.CalculateSalary();
        bob.CalculateSalary();
        charlie.CalculateSalary();

        Console.WriteLine("Employee Salaries before bonus: ");
        DisplayEmployeeSalary(alice);
        DisplayEmployeeSalary(bob);
        DisplayEmployeeSalary(charlie);

        float bonusThreshold = 4000.0F;
        float bonusAmount = 1000.00F;
        alice.ApplyBonus(bonusThreshold, bonusAmount);
        bob.ApplyBonus(bonusThreshold, bonusAmount);
        charlie.ApplyBonus(bonusThreshold, bonusAmount);


        Console.WriteLine();
        Console.WriteLine("Employee salaries (after bonus): ");
        DisplayEmployeeSalary(alice);
        DisplayEmployeeSalary(bob);
        DisplayEmployeeSalary(charlie);

        float totalPayroll = alice.Salary + bob.Salary + charlie.Salary;
        Console.WriteLine($"\nTotal Payroll: {totalPayroll}");
         


        static void DisplayEmployeeSalary(Employee employee)
        {
            Console.WriteLine($"Name: {employee.Name}, ID: {employee.ID}, Salary: {employee.Salary}");
        }
    }
}