using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace SIMS.Model
{
    public class PatientForAddAppointmentDTO
    {
        public String PatientId { get; set; }
        public String PatientName { get; set; }
        public String PatientSurname { get; set; }
        public String PatientAddress { get; set; }
        public String DatoOfBirth { get; set; }

        public PatientForAddAppointmentDTO(string patientId, string patientName, string patientSurname, string patientAddress, string datoOfBirth)
        {
            PatientId = patientId;
            PatientName = patientName;
            PatientSurname = patientSurname;
            PatientAddress = patientAddress;
            DatoOfBirth = datoOfBirth;
        }
    }
}
