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