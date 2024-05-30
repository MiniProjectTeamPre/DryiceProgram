using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DryiceProgram.MiniClass.ForFile {
    public class FileControl {

        public FileControl() {
            pathExe = GetPathExe();
            path = GetPath();
        }
        private string pathExe;

        /// <summary>
        /// ตัวแปรนี้ตอนแรกจะเป็น path exe ต่อมาถ้ามีการ SavePath มันจะเปลี่ยนไปเป็น path ใหม่ที่ถูก save
        /// </summary>
        public string path;

        private string GetPathExe_() {
            string assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            string pathExe = Path.GetDirectoryName(assembly);
            pathExe = pathExe.Replace("file:\\", string.Empty);
            return pathExe;
        }
        private string GetPathExe() {
            try
            {
                string assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
                string pathExe = Path.GetDirectoryName(assembly);
                pathExe = pathExe.Replace("file:\\", string.Empty);
                return pathExe;
            } catch (Exception e)
            {
                MessageBox.Show("An error occurred while retrieving the path of the executable. Details: " + e.Message);
                return string.Empty;
            }
        }


        private string GetPath_() {
            string pathFile = string.Empty;
            try
            {
                pathFile = File.ReadAllText("Path.txt");
            } catch (Exception)
            {

            }
            if (pathFile == string.Empty)
            {
                return pathExe;
            }
            return pathFile;
        }
        private string GetPath() {
            string pathFile = string.Empty;
            try
            {
                pathFile = File.ReadAllText("Path.txt");
            } catch (FileNotFoundException)
            {
                // Path.txt file not found, use default path
                pathFile = pathExe;
            } catch (Exception ex)
            {
                // Error reading Path.txt file, log the exception and use default path
                MessageBox.Show("Error reading Path.txt file: " + ex.Message);
                pathFile = pathExe;
            }
            return pathFile;
        }


        private void SavePath_(string path) {
            File.WriteAllText(pathExe + "\\Path.txt", path);
            this.path = path;
        }
        private void SavePath(string path) {
            try
            {
                if (!string.IsNullOrEmpty(pathExe) && !string.IsNullOrEmpty(path))
                {
                    string filePath = Path.Combine(pathExe, "Path.txt");
                    File.WriteAllText(filePath, path);
                    this.path = path;
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error saving path: " + ex.Message);
            }
        }



        /// <summary>
        /// Find file in folder
        /// </summary>
        /// <param name="nameContains"></param>
        /// <returns></returns>
        public string[] FindNameFile_(string nameContains) {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] infos = directoryInfo.GetFiles();
            List<string> allFile = new List<string>();
            foreach (FileInfo file in infos)
            {
                allFile.Add(file.Name);
            }
            List<string> nameFileSelect = allFile.FindAll(element => element.Contains(nameContains));
            return nameFileSelect.ToArray();
        }
        public string[] FindNameFile(string nameContains) {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    throw new ArgumentException("The path is empty or null.");
                }

                if (!Directory.Exists(path))
                {
                    throw new DirectoryNotFoundException($"The directory '{path}' does not exist.");
                }

                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                FileInfo[] infos = directoryInfo.GetFiles();
                List<string> allFile = new List<string>();
                foreach (FileInfo file in infos)
                {
                    allFile.Add(file.Name);
                }
                List<string> nameFileSelect = allFile.FindAll(element => element.Contains(nameContains));
                return nameFileSelect.ToArray();
            } catch (Exception ex)
            {
                // Handle any exception that may occur
                MessageBox.Show($"An error occurred while finding files: {ex.Message}");
                return null;
            }
        }
        public string[] FindNameFile_(string nameContains, string path) {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] infos = directoryInfo.GetFiles();
            List<string> allFile = new List<string>();
            foreach (FileInfo file in infos)
            {
                allFile.Add(file.Name);
            }
            List<string> nameFileSelect = allFile.FindAll(element => element.Contains(nameContains));
            return nameFileSelect.ToArray();
        }
        public string[] FindNameFile(string nameContains, string path) {
            List<string> nameFileSelect = new List<string>();

            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                if (!directoryInfo.Exists)
                {
                    throw new DirectoryNotFoundException("Directory not found: " + path);
                }

                FileInfo[] infos = directoryInfo.GetFiles();

                if (infos != null)
                {
                    foreach (FileInfo file in infos)
                    {
                        if (file.Name.Contains(nameContains))
                        {
                            nameFileSelect.Add(file.Name);
                        }
                    }
                }
            } catch (Exception e)
            {
                MessageBox.Show("An error occurred while trying to find files: " + e.Message);
            }

            return nameFileSelect.ToArray();
        }



        /// <summary>
        /// Get เฉพาะชื่อไฟล์เท่านั้น
        /// </summary>
        /// <returns></returns>
        public string FolderGetName_() {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = path;
            dialog.Filters.Add(new CommonFileDialogFilter("CSV Files", "*.csv"));
            //dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                SavePath(dialog.FileName.Replace(dialog.FileAsShellObject.Name, string.Empty));
                return dialog.FileAsShellObject.Name;
            }
            return string.Empty;
        }
        public string FolderGetName() {
            try
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = path;
                dialog.Filters.Add(new CommonFileDialogFilter("Hex Files", "*.hex"));
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    SavePath(dialog.FileName.Replace(dialog.FileAsShellObject.Name, string.Empty));
                    return dialog.FileAsShellObject.Name;
                }
            } catch (Exception e)
            {
                MessageBox.Show("An error occurred while trying to get the folder name: " + e.Message);
            }
            return string.Empty;
        }



        /// <summary>
        /// Get ทั้ง path
        /// </summary>
        /// <returns></returns>
        public string FolderGetFullName_() {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = path;
            dialog.Filters.Add(new CommonFileDialogFilter("CSV Files", "*.csv"));
            //dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                SavePath(dialog.FileName.Replace(dialog.FileAsShellObject.Name, string.Empty));
                return dialog.FileName;
            }
            return string.Empty;
        }
        public string FolderGetFullName() {
            try
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = path;
                dialog.Filters.Add(new CommonFileDialogFilter("Hex Files", "*.hex"));
                //dialog.IsFolderPicker = true;  //ยอมให้เลือกเฉพาะโฟลเดอร์
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    SavePath(dialog.FileName.Replace(dialog.FileAsShellObject.Name, string.Empty));
                    return dialog.FileName;
                }
                return string.Empty;
            } catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to select a file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }



        /// <summary>
        /// Get เฉพาะชื่อไฟล์เท่านั้น แบบทีละหลายๆไฟล์
        /// </summary>
        /// <returns></returns>
        public string[] FolderGetMultiName_() {
            List<string> files = new List<string>();
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = path;
            dialog.Filters.Add(new CommonFileDialogFilter("CSV Files", "*.csv"));
            dialog.Multiselect = true;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                foreach (string file in dialog.FileNames)
                {
                    string[] split = file.Split('\\');
                    string name = split[split.Length - 1];
                    string pathNew = file.Replace(name, string.Empty);
                    files.Add(name);
                    SavePath(pathNew);
                }
            }
            return files.ToArray();
        }
        public string[] FolderGetMultiName() {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("The path is not set.");
            }

            List<string> files = new List<string>();

            try
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = path;
                dialog.Filters.Add(new CommonFileDialogFilter("CSV Files", "*.csv"));
                dialog.Multiselect = true;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    foreach (string file in dialog.FileNames)
                    {
                        string name = Path.GetFileName(file);
                        files.Add(name);
                        string pathNew = Path.GetDirectoryName(file);
                        SavePath(pathNew + "\\");
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return files.ToArray();
        }



        /// <summary>
        /// Get ทั้ง path แบบทีละ หลายๆไฟล์
        /// </summary>
        /// <returns></returns>
        public string[] FolderGetMultiFullName_() {
            List<string> files = new List<string>();
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = path;
            dialog.Filters.Add(new CommonFileDialogFilter("CSV Files", "*.csv"));
            dialog.Multiselect = true;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                foreach (string file in dialog.FileNames)
                {
                    files.Add(file);
                }
            }
            return files.ToArray();
        }
        public string[] FolderGetMultiFullName() {
            List<string> files = new List<string>();
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = path;
            dialog.Filters.Add(new CommonFileDialogFilter("CSV Files", "*.csv"));
            dialog.Multiselect = true;
            dialog.RestoreDirectory = true;
            try
            {
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    foreach (string file in dialog.FileNames)
                    {
                        if (Path.GetExtension(file).ToLower() == ".csv")
                        {
                            files.Add(file);
                        }
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error selecting CSV files: " + ex.Message);
            }
            return files.ToArray();
        }



        ///<summary>
        /// Prompts the user to select a folder using a common open file dialog and returns the selected folder's full path.
        /// If an error occurs, a message box is shown with the error message and an empty string is returned.
        ///</summary>
        ///<returns>The full path of the selected folder, or an empty string if no folder was selected or an error occurred.</returns>
        public string FolderGetFullFolder() {
            try
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = path;
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    SavePath(dialog.FileName);
                    return dialog.FileName;
                }
                return string.Empty;
            } catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to select a folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }



        /// <summary>
        /// เอาไว้ค้นหา path ของ exe เพียงแค่ระบุ ชื่อ name.exe เท่านั้น
        /// </summary>
        /// <param name="nameExe"></param>
        /// <returns></returns>
        public string GetExePath(string nameExe) {
            CancellationToken cancellationToken = new CancellationToken();
            string[] drives = Directory.GetLogicalDrives();

            foreach (string drive in drives)
            {
                cancellationToken.ThrowIfCancellationRequested();
                string path = SearchForExe(drive, nameExe, 0, cancellationToken);

                if (!string.IsNullOrEmpty(path))
                {
                    return path;
                }
            }

            return string.Empty;
        }
        public string GetExePath(string nameExe, CancellationToken cancellationToken) {
            string[] drives = Directory.GetLogicalDrives();

            foreach (string drive in drives)
            {
                cancellationToken.ThrowIfCancellationRequested();
                string path = SearchForExe(drive, nameExe, 0, cancellationToken);

                if (!string.IsNullOrEmpty(path))
                {
                    return path;
                }
            }

            return string.Empty;
        }
        private string SearchForExe(string folder, string nameExe, int depth, CancellationToken cancellationToken) {
            try
            {
                if (depth >= 8)
                {
                    return string.Empty; // stop searching if the depth exceeds 10
                }

                int fileCount = Directory.GetFiles(folder).Length;
                if (fileCount > 20)
                {
                    return string.Empty; // skip this folder if it has more than 100 files
                }

                foreach (string file in Directory.GetFiles(folder))
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (Path.GetFileName(file).ToLower() == nameExe.ToLower())
                    {
                        return Path.GetFullPath(file);
                    }
                }

                if (cancellationToken.IsCancellationRequested)
                {
                    return string.Empty;
                }

                foreach (string subFolder in Directory.GetDirectories(folder))
                {
                    string path = SearchForExe(subFolder, nameExe, depth + 1, cancellationToken);

                    if (!string.IsNullOrEmpty(path))
                    {
                        return path;
                    }
                }
            } catch (Exception ex)
            {
                // Handle the exception, e.g. log or display a message
            }

            return string.Empty;
        }



        /// <summary>
        /// Reads the contents of a file asynchronously, with an optional timeout.
        /// </summary>
        /// <param name="filePath">The path to the file to read.</param>
        /// <param name="timeoutMs">The maximum amount of time to wait for the file to become available.</param>
        /// <returns>The contents of the file as a string.</returns>
        public async Task<string> ReadFileAsync(string filePath, int timeoutMs = 5000, CancellationToken cts = default) {
            // Use a StringBuilder to accumulate the contents of the file
            StringBuilder sb = new StringBuilder();
            DateTime start = DateTime.Now;
            while (true)
            {
                try
                {
                    // Try to open the file for reading
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        // Read the entire contents of the file and append to the StringBuilder
                        sb.Append(await sr.ReadToEndAsync());
                        // Exit the loop since the file was successfully read
                        break;
                    }
                } catch
                {
                    // Wait 50ms before trying again if the file is not yet available
                    await Task.Delay(50);
                    // If the timeout has been reached, throw an exception
                    if ((DateTime.Now - start).TotalMilliseconds > timeoutMs | cts.IsCancellationRequested)
                    {
                        return null;
                        //throw new TimeoutException($"Timeout occurred while waiting for file {filePath} to become available.");
                    }
                }
            }
            // Return the contents of the file as a string
            return sb.ToString();
        }

    }
}
