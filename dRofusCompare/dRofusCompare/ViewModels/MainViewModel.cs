using dRofusCompare.Assets;
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
        public List<dRofusData> dRofusContent;
        public List<DataComparison> DifferenceList;
        private List<DataComparison> m_notOkRoomsList;

        public List<DataComparison> NotOkRoomsList
        {
            get { return m_notOkRoomsList; }
            set { m_notOkRoomsList = value; OnPropertyChanged("NotOkRoomsList"); }
        }

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
            //FileExplorerCommand = new DelegateCommand(OpenExplorerExecute);
            DrawingContent = Reader.DrawingReader(@"C:\Users\Frederik\Source\Repos\dRofusCompare\dRofusCompare\dRofusCompare\DrawingData.txt");
            dRofusContent = Reader.dRofusReader(@"C:\Users\Frederik\Source\Repos\dRofusCompare\dRofusCompare\dRofusCompare\dRofusData.txt");
            DifferenceList = Comparer.TotalsList(DrawingContent, dRofusContent);
            NotOkRoomsList = Comparer.RemoveOkRooms(DifferenceList);
        }

        private void flip()
        {
            IsSettingsOpen = !IsSettingsOpen;
        }

        //private void OpenExplorerExecute()
        //{
        //    OpenFileDialog fileDialog = new OpenFileDialog();

        //    fileDialog.ShowDialog();

        //    if (fileDialog.CheckFileExists)
        //    {
        //        DrawingContent = Reader.DrawingReader(fileDialog.FileName);
        //    }
        //}
    }
}
