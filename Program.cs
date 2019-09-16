using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCore3DDD
{
  class Program
  {

    static void Main(string[] args)
    {
      var context = new CompanyContext();
      //context.Database.EnsureCreated();
      //  AddCompanies();
       AddEmployeeToCompany();
       AddNamelessEmployeeToCompany();
      RetrieveEmployees();
      RetrieveCompanies();
      UpdateNameViaEF();
      RetrieveEmployeeWithCompany();
      UpdateEmployeeCount();
      AddCompanyWithOwner();
      SetFavoriteEmployee();
      ReplaceEmployeeName();
      AddNamelessEmployeeToCompanyThenUpdate();
AddNamelessEmployeeToCompanyThenDelete();
AddEmployeeToCompanyThenDelete();
    }

    private static void ReplaceEmployeeName()
    {
      using (var context = new CompanyContext())
      {
        var employee = context.Employees.FirstOrDefault(e => e.Name == null);
        employee.Name = PersonFullName.Create("Diego", "Vega");
        context.SaveChanges();
      }
    }

    private static void AddCompanyWithOwner()
    {
      var company = new Company("Flynn Flam Carpentry", "Rich");
      using (var context = new CompanyContext())
      {
        context.Companies.Add(company);
        context.SaveChanges();
      }
    }

    private static void UpdateEmployeeCount()
    {
      var company = new Company("Flynn Flam Carpentry");

      company.AddEmployee();
    }

    private static void RetrieveEmployeeWithCompany()
    {
      using (var context = new CompanyContext())
      {
        var employee = context.Employees.Include(e => e.Company).FirstOrDefault();
      }
    }
    private static void RetrieveEmployees()
    {
      using (var context = new CompanyContext())
      {
        var employees = context.Employees.ToList();
      }
    }
    private static void SetFavoriteEmployee()
    {
      using (var context = new CompanyContext())
      {
        var company = context.Companies.FirstOrDefault();
        company.SetFave("Julie");
        context.SaveChanges();
      }
    }

    private static void AddEmployeeToCompany()
    {
      using (var context = new CompanyContext())
      {
        context.Employees.Add(new Employee("Julie", "Lerman", 2));
        context.SaveChanges();
      }
    }
    private static void AddNamelessEmployeeToCompany()
    {
      using (var context = new CompanyContext())
      {
        context.Employees.Add(new Employee(2));
        context.SaveChanges();

      }
    }
    private static void AddNamelessEmployeeToCompanyThenUpdate()
    {
      using (var context = new CompanyContext())
      {
        context.Employees.Add(new Employee(2));
        context.SaveChanges();

      }
      using (var context = new CompanyContext())
      {
        var employee = context.Employees.FirstOrDefault(e => e.Name == null);
        employee.Name = PersonFullName.Create("Diego", "Vega");
        context.SaveChanges();
      }
    }
    private static void AddNamelessEmployeeToCompanyThenDelete()
    {
      using (var context = new CompanyContext())
      {
        context.Employees.Add(new Employee(2));
        context.SaveChanges();

      }
      using (var context = new CompanyContext())
      {
        var employee = context.Employees.FirstOrDefault(e => e.Name == null);
        context.Remove(employee);
         context.SaveChanges();
      }
    }

    private static void AddEmployeeToCompanyThenDelete()
    {
      using (var context = new CompanyContext())
      {
        context.Employees.Add(new Employee("Arthur","Vickers",1));
        context.SaveChanges();

      }
      using (var context = new CompanyContext())
      {
        var employee = context.Employees.FirstOrDefault(e => e.Name.First == "Arthur");
        context.Remove(employee);
         context.SaveChanges();
      }
    }
    private static void RetrieveCompanies()
    {
      using (var context = new CompanyContext())
      {
        var companies = context.Companies.ToList();
      }

    }

    private static void AddCompanies()
    {
      using (var context = new CompanyContext())
      {
        context.Companies.AddRange(
            new Company("Microsoft"),
            new Company("The Data Farm")
        );
        context.SaveChanges();
      }
    }
    private static void UpdateNameViaEF()
    {
      using (var context = new CompanyContext())
      {
        var company = context.Companies.FirstOrDefault();
        context.Entry(company).Property(c => c.Name).CurrentValue = "New Company Name";
      }
    }
  }
}
