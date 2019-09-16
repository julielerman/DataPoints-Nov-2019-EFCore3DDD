using System;

namespace EFCore3DDD

{
  public class Company
  {
    private Company() { }
    public Company(string name)
    {
      _name = name;

    }
     public Company(string name,string ownername):this(name)
    {
      _ownerName=ownername;
    }
    //private property
    private int _companyId;
    private int CompanyId=>_companyId;
    
    //public readonly property with private backing field
    private string _name;
    public string Name => _name;
    private string _ownerName;
    public string OwnerName => _ownerName;
    private string _favoriteEmployee;
    public void SetFave(string fave){
      _favoriteEmployee=fave;
    }



    //public property with public getter & private setter with biz logic
    //explicit backing field
    private int _employeeCount;
    public int EmployeeCount
    {
      get { return _employeeCount; }
      private set
      {
        _employeeCount = value;
        SendEmployeeCountChangedMessage();
      }

    }

    private void SendEmployeeCountChangedMessage()
    {
      Console.WriteLine("Employee Count Has Changed");
    }

    public void AddEmployee()
    {
      EmployeeCount += 1;
    }
    public void RemoveEmployee()
    {
      EmployeeCount -= 1;
    }

  }
  
}