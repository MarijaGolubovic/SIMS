using System;

namespace Model
{
   public class Person
   {
      public String name;
      public String surname;
      public String jmgb;
      public String telephone;
      public DateTime dateOfBirth;
      public String eMail;
      
      public Address address;
      
      
      public Address Address
      {
         get
         {
            return address;
         }
         set
         {
            this.address = value;
         }
      }
   
   }
}