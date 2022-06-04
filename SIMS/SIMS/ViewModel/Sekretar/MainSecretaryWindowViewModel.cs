using SIMS.View.Sekretar;

namespace SIMS.ViewModel.Sekretar
{
    public class MainSecretaryWindowViewModel : BindableBase
    {
        public MyICommand AllPatientViewCMD { get; set; }
        public MyICommand AppointmentViewCMD { get; set; }
        public MyICommand EquipmentViewCMD { get; set; }
        public MyICommand EmergencyViewCMD { get; set; }
        public MyICommand RequestCMD { get; set; }
        public MyICommand MeetingsViewCMD { get; set; }



        public MainSecretaryWindowViewModel()
        {
            AllPatientViewCMD = new MyICommand(OpenAllPatient);
            AppointmentViewCMD = new MyICommand(OpenAppointmentView);
            EquipmentViewCMD = new MyICommand(OpenEquipmentView);
            EmergencyViewCMD = new MyICommand(OpenEmergencyView);
            RequestCMD = new MyICommand(OpenRequestView);
            MeetingsViewCMD = new MyICommand(OpenMeetingsView);


        }

        private void OpenAllPatient()
        {
            AllPatientView allPatientView = new AllPatientView();
            allPatientView.Show();
        }

        private void OpenAppointmentView()
        {
            AppointmentView appointmentView = new AppointmentView();
            appointmentView.Show();
        }

        private void OpenEquipmentView()
        {
            EquipmentView equipmentView = new EquipmentView();
            equipmentView.Show();
        }

        private void OpenEmergencyView()
        {
            EmergencyView emergencyView = new EmergencyView();
            emergencyView.Show();
        }

        private void OpenRequestView()
        {
            DaysOffRequestView daysOffRequestView = new DaysOffRequestView();
            daysOffRequestView.Show();
        }

        private void OpenMeetingsView()
        {
            MeetingsView meetingsView = new MeetingsView();
            meetingsView.Show();
        }



    }
}
