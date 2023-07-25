﻿using System;
using System.ComponentModel;

namespace SampleMAUI.Models
{
    public class ToDo : INotifyPropertyChanged
    {
        int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id == value)
                    return;
                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        string _todoname;
        public string toDoName
        {
            get => _todoname;
            set
            {
                if (_todoname == value)
                    return;
                _todoname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(toDoName)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

