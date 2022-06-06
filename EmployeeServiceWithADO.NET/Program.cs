using System;
using EmployeeServiceWithADO.NET;
public class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("#################Welcome in the Employee Pay Roll Service################");
        EmployeeRepo payrollService = new EmployeeRepo();
        bool check = true;


        while (check)
        {
            Console.WriteLine("1. To Insert the Data in Data Base \n2.Retrieve All Employee Data from the Data Base\n");
            Console.WriteLine("###### Enter the Above Option To Perform The CRUD Operation ##########");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    EmpModel empModel = new EmpModel();
                    empModel.Id = 111;
                    empModel.Name = "Raunak";
                    empModel.Salary = 50000;
                    empModel.StartDate = DateTime.Now;
                    empModel.Address = "Dhule";
                    empModel.ContactNumber = "9541750256";
                    empModel.Gender = "M";
                    empModel.Pay = 500;
                    empModel.Deduction = 500;
                    empModel.TaxablePay = 500;
                    empModel.IncomeTax = 500;
                    empModel.NetPay = 2000;
                    payrollService.AddEmployee(empModel);
                    break;
                    case 2:
                    List<EmpModel> empList = payrollService.GetAllEmployees();
                    foreach (EmpModel data in empList)
                    {
                        Console.WriteLine(data.Id + " " + data.Name + " " + data.Salary + " " + data.Gender + " " + data.StartDate + " " + data.Address + " " + data.ContactNumber + " " + data.Pay + " " + data.Deduction + " " + data.TaxablePay + " " + data.IncomeTax + " " + data.NetPay);
                    }
                    break;
                case 0:
                    check= false;
                    break;
                default:
                    Console.WriteLine("$$$$$$$$$ Please Enter the Correct option $$$$$$$$$$");
                    break;
            }
        }

    }
}