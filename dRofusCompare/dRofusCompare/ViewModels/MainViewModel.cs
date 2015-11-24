﻿using dRofusCompare.Assets;
using dRofusCompare.Models;
using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace dRofusCompare.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool m_isSettingsOpen;
        private ICommand m_openSettings;
        private ICommand m_fileExplorerCommand;
        public List<DrawingData> DrawingContent;

        public ICommand OpenSettings
        {
            get { return m_openSettings; }
            set
            {
                m_openSettings = value;
                OnPropertyChanged("OpenSettings");
            }
        }

        public ICommand FileExplorerCommand
        {
            get { return m_fileExplorerCommand; }
            set { m_fileExplorerCommand = value; OnPropertyChanged("FileExplorerCommand"); }
        }

        public bool IsSettingsOpen
        {
            get { return m_isSettingsOpen; }
            set
            {
                m_isSettingsOpen = value;
                OnPropertyChanged("IsSettingsOpen");
            }
        }

        public MainViewModel()
        {
            m_openSettings = new DelegateCommand(flip);
            FileExplorerCommand = new DelegateCommand(OpenExplorerExecute);
        }

        private void flip()
        {
            IsSettingsOpen = !IsSettingsOpen;
        }

        private void OpenExplorerExecute()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.ShowDialog();

            if (fileDialog.CheckFileExists)
            {
                DrawingContent = Reader.DrawingReader(fileDialog.FileName);
            }
        }
    }
}