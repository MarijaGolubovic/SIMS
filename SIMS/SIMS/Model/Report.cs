﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    public class Report: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        String RoomId {
            get
            {
                return _RoomId;
            }
            set
            {

                if (value != _RoomId)
                {
                    _RoomId = value;
                    OnPropertyChanged("RoomId");
                }
            }
        }

       

        String Reason
        {
            get
            {
                return _Reason;
            }
            set
            {

                if (value != _Reason)
                {
                    _Reason = value;
                    OnPropertyChanged("Reason");
                }
            }
        }

        public Report(String roomId, String reason, String employer)
        {
            RoomId = roomId;
            Reason = reason;
            Employer = employer;
        }

        String Employer {
            get
            {
                return _Employer;
            }
            set
            {

                if (value != _Employer)
                {
                    _Employer = value;
                    OnPropertyChanged("Employer");
                }
            }
        }

        String _RoomId;
        String _Reason;
        String _Employer;
    }
}