using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryiceProgram.MiniClass.ForFile {
    public class FileBat {

        public FileBat(FormStart main_) {
            main = main_;
        }

        private FormStart main;

        public void CheckStLink() {
            if (!File.Exists("St-Link List.bat"))
            {
                string pathExe = main.fileControl.GetExePath("ST-LINK_CLI.exe");
            }
            
        }
    }
}
