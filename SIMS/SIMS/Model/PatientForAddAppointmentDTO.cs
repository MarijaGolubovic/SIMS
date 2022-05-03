using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
