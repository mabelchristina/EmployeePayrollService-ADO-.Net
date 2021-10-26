using System;

namespace EmployeePayRoll
{
    class Program
    {
        static void Main(string[] args)
        {
            int options;
            bool isExit = false;
            EmployeeRepo empRepository = new EmployeeRepo();
            while (!isExit)
            {
                Console.WriteLine("choose 1.GetAllEmployeeDetails\n 2.AddEmployeeDetails\n" +
                    " 3.UpdateEmployeeDetails\n 4.RetrieveAllEmployeeForParticularRange");
                options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        empRepository.GetAllEmployee();
                        break;
                    case 2:
                        EmployeeModel obj = new EmployeeModel();
                        obj.name = "Gladis";
                        obj.salary = 35000;
                        obj.start_date = "2020-09-07";
                        empRepository.AddEmployee(obj);
                        break;
                    case 3:
                        empRepository.UpdateEmployee(50000, "Joe");
                        break;
                    case 4:
                        empRepository.RetrieveAllEmployeeForParticularRange();
                        break;
                    de:
                        Console.WriteLine("enter valid option");
                        break;
                }
            }
        }
    }
}
