using SIMS.Controller;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class MedicalRecord : Serialization.Serializable
    {
        public Double Height { get; set; }
        public Double Weight { get; set; }
        public List<Allergy> Allergies { get; set; }
        public BloodType BloodType { get; set; }

        private readonly PatientController patientController = new PatientController();
        private readonly TherapyContoller therapyContoller = new TherapyContoller();
        public MedicalRecord(double height, double weight, List<Allergy> allergies, BloodType bloodType, List<Therapy> therapies)
        {
            Height = height;
            Weight = weight;
            Allergies = allergies;
            BloodType = bloodType;
            Therapy = therapies;
        }

        public System.Collections.Generic.List<Therapy> therapies;

        public System.Collections.Generic.List<Therapy> Therapy
        {
            get
            {
                if (therapies == null)
                    therapies = new System.Collections.Generic.List<Therapy>();
                return therapies;
            }
            set
            {
                RemoveAllTherapy();
                if (value != null)
                {
                    foreach (Therapy oTherapy in value)
                        AddTherapy(oTherapy);
                }
            }
        }

        public MedicalRecord()
        {
        }

        public void AddTherapy(Therapy newTherapy)
        {
            if (newTherapy == null)
                return;
            if (this.therapies == null)
                this.therapies = new System.Collections.Generic.List<Therapy>();
            if (!this.therapies.Contains(newTherapy))
                this.therapies.Add(newTherapy);
        }


        public void RemoveThearpy(Therapy oldTherapy)
        {
            if (oldTherapy == null)
                return;
            if (this.therapies != null)
                if (this.therapies.Contains(oldTherapy))
                    this.therapies.Remove(oldTherapy);
        }


        public void RemoveAllTherapy()
        {
            if (therapies != null)
                therapies.Clear();
        }

        public string[] toCSV()
        {


            string[] csvValues = {

                Height.ToString(),
                Weight.ToString(),
                BloodType.ToString(),
                patient.Person.JMBG.ToString()
            };

            int i = 4;
            foreach (Allergy a in Allergies)
            {
                Array.Resize(ref csvValues, i + 1);
                csvValues[i] = a.Name;
                i++;
            }

            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            Allergies = new List<Allergy>();
            if (values == null)
                return;
            Height = Double.Parse(values[0]);
            Weight = Double.Parse(values[1]);
            BloodType = (BloodType)Enum.Parse(typeof(BloodType), values[2]);
            patient = patientController.GetOne(values[3]);
            therapies = therapyContoller.GetById(values[3]);

            Allergies = new List<Allergy>();
            for (int i = 4; i < values.Length; i++)
            {
                Allergy al = new Allergy(values[i]);
                Allergies.Add(al);
            }

        }

        public Patient patient;

        public MedicalRecord(double height, double weight, List<Allergy> allergies, BloodType bloodType, List<Therapy> therapies, Patient patient) : this(height, weight, allergies, bloodType, therapies)
        {
            this.patient = patient;
        }
    }

}
