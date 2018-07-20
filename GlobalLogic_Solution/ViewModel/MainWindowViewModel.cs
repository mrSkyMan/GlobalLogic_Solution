using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using Newtonsoft.Json;

namespace GlobalLogic_Solution.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Private Members

        private string dirPath;
        private Folder folder;
        #endregion

        #region Public Properties

        public string DirPath
        {
            get { return dirPath; }
            private set { dirPath = value; }
        }

        #endregion

        #region Commands

        public ICommand ChooseDirectoryCommand { get; set; }
        public ICommand SaveJSONFileCommand { get; set; }
        

        #endregion

        public MainWindowViewModel()
        {
            ChooseDirectoryCommand = new RelayCommand(() => ChooseDirectory());
            SaveJSONFileCommand = new RelayCommand(() => SaveJSONFile());
        }

        #region Private Methods

        private void ChooseDirectory()
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DirPath = dialog.SelectedPath;
                    folder = new Folder(new DirectoryInfo(dialog.SelectedPath));
                }
            }
        }

        private void SaveJSONFile()
        {
            if (folder != null)
            {
                Microsoft.Win32.SaveFileDialog fileDialog = new Microsoft.Win32.SaveFileDialog();
                    fileDialog.Filter = "JSON |*.json";
                    if (fileDialog.ShowDialog() == true)
                    {
                        var json = JsonConvert.SerializeObject(folder, Formatting.Indented);
                        File.WriteAllText(fileDialog.FileName, json);
                        MessageBox.Show("File saved successfully!");
                    }
            }
        }

        #endregion
    }
}
