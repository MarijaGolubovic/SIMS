using GalaSoft.MvvmLight.Messaging;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

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
        public String Recipe { get; set; }

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
            Medicine m = SelectedMedicine;
            String periodInHours = SelectedPeriodInHours;
            String periodInDays = SelectedPeriodInDays;
            String recept = Recipe;
            String id = JoinAppointmentViewModel.SelectedAppointment.Patient.Person.JMBG;
            DateTime timeOfMaking = DateTime.Now;

            MedicalRecord medRec = medicalRecordController.GetOne(id);
            List<Allergy> allergies = medRec.Allergies;

            foreach (String s in m.Ingredients)
            {
                foreach (Allergy a in allergies)
                {
                    if (s.Equals(a.Name))
                    {
                        notifier.ShowError("Pacijent je alergican na taj lijek!");
                        Messenger.Default.Send("AddTherapy");
                        return;
                    }
                }
            }

            Therapy t = new Therapy(m, periodInHours, recept, periodInDays, timeOfMaking, id);

            therapyContoller.Create(t);
            notifier.ShowSuccess("Uspješno ste dodali terapiju!");
            Messenger.Default.Send("AddTherapy");
        }

        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });

        private void OnBack()
        {
            Messenger.Default.Send("BackFromAddTherapyView");
        }
    }
}
