using System;
using System.Xml.Linq;
namespace Employee;


public class Employee
{
    private string _name;
    private int _id;
    private float _salary;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int ID
    {
        get => _id;
        set
        {
            if (value > 0)
                _id = value;

            else
                throw new ArgumentException("ID must be positve");
        }

    }

    public float Salary
    {
        get => _salary;
        set
        {
            if (value >= 0)
                _salary = value;

            else
                throw new ArgumentException("Salary cannot be negative");
        }
    }


    public Employee(string name, int id)
    {
        Name = name;
        ID = id;
        Salary = 0;
    }

    public float ApplyBonus(float threshold, float bonus)
    {
        float total = Salary;
        if (Salary > threshold)
        {
            Salary += bonus;

        }
        return total;


    }
}

public class RegularEmployee : Employee
{
    public float FixedRate = 3000;

    public RegularEmployee(string name, int id) : base(name, id)
    { }

    public float CalculateSalary()
    {
        Salary = FixedRate;
        return Salary;
    }

}

public class HourlyEmployee : Employee
{
    private float _hoursWorked;
    private float _hourlyRate;

    public float HoursWorked
    {
        get => _hoursWorked;
        set
        {
            if (value >= 0)
                _hoursWorked = value;
            else
                throw new ArgumentException("Hours worked must be not negatve");
        }
    }

    public float HourlyRate
    {
        get => _hourlyRate;
        set
        {
            if (value >= 0)
                _hourlyRate = value;
            else
                throw new ArgumentException("Hourly rates cannot be less than zero");
        }
    }
    public HourlyEmployee(string name, int id, float hoursWorked, float hourlyRate) : base(name, id)
    {
        HoursWorked = hoursWorked;
        HourlyRate = hourlyRate;
    }
    public float CalculateSalary()
    {
        Salary = HoursWorked * HourlyRate;
        return Salary;
    }
}
public class CommissionEmployee : Employee
{
    public float salesAmount { get; set; }
    public float commissionRate { get; set; }

    public CommissionEmployee(string name, int ID, float salesAmount, float commissionRate) : base(name, ID)
    {
        this.salesAmount = salesAmount;
        this.commissionRate = commissionRate;
    }
    public void CalculateSalary()
    {
        salary = salesAmount * commissionRate;
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

        float totalPayroll = alice.salary + bob.salary + charlie.salary;
        Console.WriteLine($"\nTotal Payroll: {totalPayroll}");



        static void DisplayEmployeeSalary(Employee employee)
        {
            Console.WriteLine($"Name: {employee.name}, ID: {employee.id}, Salary: {employee.salary}");
        }
    }
}