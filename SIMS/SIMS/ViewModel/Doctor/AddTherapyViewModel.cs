using SIMS.Controller;
using SIMS.Model;
using SIMS.Controller;
using SIMS.Model;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using ToastNotifications.Messages;

namespace SIMS.ViewModel.Doctor
{
    internal class AddTherapyViewModel : BindableBase
    {
        public MyICommand AddTherapyCommand { get; set; }
        public MyICommand BackCommand { get; set; }

        private readonly MedicineContoller medicineController = new MedicineContoller();
        private readonly TherapyContoller therapyContoller = new TherapyContoller();
        private readonly MedicalRecordController medicalRecordController = new MedicalRecordController();
        public List<Medicine> Medicines { get; set; }
        public Medicine SelectedMedicine { get; set; }
        public String SelectedPeriodInHours { get; set; }
        public String SelectedPeriodInDays { get; set; }
        private String recipe;
        public String Recipe
        {
            get { return recipe; }
            set
            {
                recipe = value;
                OnPropertyChanged("Recipe");
            }
        }

        public AddTherapyViewModel()
        {
            Medicines = medicineController.GetAllWithStatusValid();
            SelectedMedicine = Medicines.First();
            SelectedPeriodInHours = "4";
            SelectedPeriodInDays = "7";
            AddTherapyCommand = new MyICommand(OnAddTherapy);
            BackCommand = new MyICommand(OnBack);
        }

        private void OnAddTherapy()
        {
            MedicalRecord medicalRecord = medicalRecordController.GetOne(JoinAppointmentViewModel.SelectedAppointment.Patient.Person.JMBG);
            List<Allergy> allergies = medicalRecord.Allergies;

            Medicine medicine = SelectedMedicine;

            if (IfAllergic(allergies, medicine))
                return;

            Therapy t = new Therapy(medicine, SelectedPeriodInHours, Recipe, SelectedPeriodInDays,
                                    DateTime.Now, JoinAppointmentViewModel.SelectedAppointment.Patient.Person.JMBG);

            AddTherapy(t);
        }

        private void AddTherapy(Therapy t)
        {
            therapyContoller.Create(t);
            Recipe = "";
            MainWindowViewModel.notifier.ShowSuccess("Uspješno!");
            Messenger.Default.Send("AddTherapy");
        }

        private bool IfAllergic(List<Allergy> allergies, Medicine medicine)
        {
            foreach (String ingredient in medicine.Ingredients)
            {
                if (IsIngredientEqualsAllergies(allergies, ingredient))
                    return true;
            }
            return false;
        }

        private bool IsIngredientEqualsAllergies(List<Allergy> allergies, string ingredient)
        {
            foreach (Allergy allergy in allergies)
            {
                if (ingredient.Equals(allergy.Name))
                {
                    MainWindowViewModel.notifier.ShowError("Pacijent je alergican na taj lijek!");
                    Messenger.Default.Send("AddTherapy");
                    return true;
                }
            }
            return false;
        }

        private void OnBack()
        {
            Messenger.Default.Send("BackFromAddTherapyView");
        }
    }
}
