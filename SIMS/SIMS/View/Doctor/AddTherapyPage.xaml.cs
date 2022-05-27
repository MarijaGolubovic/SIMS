using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SIMS.Controller;
using SIMS.Model;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace SIMS.View.Doctor
{
    /// <summary>
    /// Interaction logic for AddTherapyPage.xaml
    /// </summary>
    public partial class AddTherapyPage : Page
    {

        private readonly MedicineContoller medicineController = new MedicineContoller();
        private readonly TherapyContoller therapyContoller = new TherapyContoller();
        private readonly MedicalRecordController medicalRecordController = new MedicalRecordController();
        public AddTherapyPage()
        {
            InitializeComponent();
            DataContext = this;

            List<Medicine> medicines = medicineController.GetAll();

            Medicine_Combobox.ItemsSource = medicines;
            Medicine_Combobox.SelectedItem = medicines.First();
            Trajanje_Combobox.SelectedValue = "7";
            Period_Combobox.SelectedValue = "4";
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow.frame.Content = new JoinAppointmentPage();
        }

        private void Recept_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void setButtonVisibility()
        {
            if (Recept_TextBox.Text != String.Empty && Medicine_Combobox.IsInitialized && Period_Combobox.IsInitialized)
            {
                Button_Zavrsi.IsEnabled = true;
            }
            else
            {
                Button_Zavrsi.IsEnabled = false;
            }
        }

        private void Button_Zavrsi_Click(object sender, RoutedEventArgs e)
        {
            Medicine m = Medicine_Combobox.SelectedItem as Medicine;
            String periodInHours = (String)Period_Combobox.SelectedValue;
            String periodInDays = (String)Trajanje_Combobox.SelectedValue;
            String recept = Recept_TextBox.Text;
            String id = JoinAppointmentPage.SelectedItem.Patient.Person.JMBG;
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
                        MainWindow.frame.Content = new AddTherapyPage();
                        return;
                    }
                }
            }

            Therapy t = new Therapy(m, periodInHours, recept, periodInDays, timeOfMaking, id);

            therapyContoller.Create(t);
            notifier.ShowSuccess("Uspješno ste dodali terapiju!");
            MainWindow.frame.Content = new AddTherapyPage();
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
    }
}
