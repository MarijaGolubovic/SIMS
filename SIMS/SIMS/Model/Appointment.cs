using System;

namespace Model
{
   public class Appointment
   {
      public DateTime dateAndTime;
      public int id;
      
      public Room room;
      public Patient patient;
      
      
      public Patient Patient
      {
         get
         {
            return patient;
         }
         set
         {
            this.patient = value;
         }
      }
      public Doctor doctor;
      
      
      public Doctor Doctor
      {
         get
         {
            return doctor;
         }
         set
         {
            this.doctor = value;
         }
      }
   
   }
}