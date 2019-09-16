using System;

namespace EFCore3DDD

{
  public class Employee
  { public Employee(string first, string last, int companyId)
    {
      Name = PersonFullName.Create(first, last);
      CompanyId = companyId;

    }
     public Employee( int companyId)
    {
      
      CompanyId = companyId;

    }
    public int EmployeeID { get; set; }
    public PersonFullName Name { get; set; }
    private Company _company;
    public Company Company
    {
      get { return _company; }
      set
      {
        _company = value;
        SendEmployeeChangedCompany();
      }
    }

    private void SendEmployeeChangedCompany()
    {
      Console.WriteLine("Employee Changed Company");
    }

    public int CompanyId { get; set; }
  }
  
}