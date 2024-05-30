using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryiceProgram.MiniClass.ForVariable {
    public class VariableConfig {

        public VariableConfig() {

        }

        //สำหรับแมนนวล 
        public string hexMain;
        public string stLinkMain;

        //ใช้ร่วมกัน
        public string pathStLink;

        //สำหรับออโต้
        public string head;
        public string hex;
        public string stLink;
        public string checkSum;
        public string deBug;
        public string timeOut;
    }
}
