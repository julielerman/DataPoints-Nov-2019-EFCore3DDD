using System;

public class PersonFullName {
  
  public static PersonFullName Create (string first, string last) {
    return new PersonFullName (first, last);
  }

  private PersonFullName (string first, string last) {
    First = first;
    Last = last;
  }
  public string First { get; private set; }
  public string Last { get; private set; }
  public string FullName () => $"{First.Trim()} {Last}";
  public string FullNameReverse () =>  $"{Last.Trim()}, {First}";
 
  public override bool Equals(object obj)
  {
    return obj is PersonFullName name &&
           First == name.First &&
           Last == name.Last;
  }

  public override int GetHashCode()
  {
    return HashCode.Combine(First, Last);
  }
}
