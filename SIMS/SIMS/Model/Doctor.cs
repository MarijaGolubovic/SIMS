using System;

namespace SIMS.Model
{
   public class Doctor : User
   {
      public Specialization specialization;
      
      
      public Specialization Specialization
      {
         get
         {
            return specialization;
         }
         set
         {
            this.specialization = value;
         }
      }
   
   }
}