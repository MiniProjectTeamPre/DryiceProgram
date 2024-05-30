using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DryiceProgram.MiniClass.ForFile {
    public class FileStart {

        public FileStart(FormStart main_) {
            main = main_;

            if (!Directory.Exists(pathCommand.Replace($"\\{nameProgramPath}", string.Empty)))
            {
                Directory.CreateDirectory(pathCommand.Replace(nameProgramPath, string.Empty));
            }
            if (!Directory.Exists(pathResult.Replace($"\\{nameProgramPath}", string.Empty)))
            {
                Directory.CreateDirectory(pathResult.Replace(nameProgramPath, string.Empty));
            }
        }

        private FormStart main;

        private const string nameProgramPath = "DryiceProgram_";
        private const string pathCommand = "D:\\PathZero\\Command\\" + nameProgramPath;
        private const string pathResult = "D:\\PathZero\\Result\\" + nameProgramPath;

        private string pathStart = pathCommand + "Start.txt";
        private string pathHead = pathCommand + "Head.txt";
        private string pathAck = pathResult + "Ack.txt";
        private string pathHex = pathCommand + "Hex.txt";
        private string pathStLink = pathCommand + "StLink.txt";
        private string pathCheckSum = pathCommand + "CheckSum.txt";
        private string pathDebug = pathCommand + "Debug.txt";
        private string pathTimeout = pathCommand + "TimeOut.txt";

        /// <summary>
        /// เช็คว่ามีการสั่งให้เริ่มทำงานหรือยัง โดย main จะเป็นตัวสั่ง
        /// </summary>
        /// <returns></returns>
        public bool CheckStart() {
            try
            {
                if (File.Exists(pathStart))
                {
                    using (FileStream fileStream = File.Open(pathStart, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader streamReader = new StreamReader(fileStream))
                        {
                            // Read the contents of the file
                            string contents = streamReader.ReadToEnd();
                            // Do something with the contents, if necessary
                        }
                    }
                    File.Delete(pathStart);
                }
                else
                {
                    // The file does not exist
                    return false;
                }
            } catch (Exception ex)
            {
                //MessageBox.Show("An error occurred while checking for the start file: " + ex.Message);
                return false;
            }

            // The file was successfully read and deleted
            return true;
        }


        /// <summary>
        /// อ่านค่า config ก่อนเริ่มกระบวนการทั้งหมดที่จำเป็น
        /// </summary>
        public void ReadConfig() {
            try
            {
                if (!File.Exists(pathHead) || !File.Exists(pathCheckSum) || !File.Exists(pathHex) ||
                    !File.Exists(pathStLink))
                {
                    //MessageBox.Show("ไม่พบไฟล์ config");
                    main.varConfig.head = "0";
                    main.varConfig.checkSum = "0x";
                    main.varConfig.hex = "File Main Error";
                    main.varConfig.stLink = "File Main Error";
                    return;
                }

                main.varConfig.head = File.ReadAllText(pathHead);
                main.varConfig.checkSum = File.ReadAllText(pathCheckSum);
                main.varConfig.hex = File.ReadAllText(pathHex);
                main.varConfig.stLink = File.ReadAllText(pathStLink);
                main.varConfig.deBug = "FALSE";
                main.varConfig.timeOut = "5000";

                File.Delete(pathHead);
                File.Delete(pathCheckSum);
                File.Delete(pathHex);
                File.Delete(pathStLink);
            } catch
            {
                MessageBox.Show("อ่านไฟล์ config เข้ามา ไม่สำเร็จ");
            }

            try
            {
                if (File.Exists(pathDebug))
                {
                    main.varConfig.deBug = File.ReadAllText(pathDebug);
                }
                if (File.Exists(pathTimeout))
                {
                    main.varConfig.timeOut = File.ReadAllText(pathTimeout);
                }

                File.Delete(pathDebug);
                File.Delete(pathTimeout);
            } catch
            {
                MessageBox.Show("อ่านไฟล์ config เข้ามา ไม่สำเร็จ (สำรอง)");
            }
            File.WriteAllText(pathAck, String.Empty);
        }

        /// <summary>
        /// มันไม่สามารถดึง string Path ไปได้ตรงๆ จากนอก class เลยต้องสร้างฟังก์ชั่นสำหรับ Get Path Result โดยเฉพาะ
        /// </summary>
        /// <returns></returns>
        public string GetPathResult() {
            return pathResult;
        }
        public string GetPathCommand() {
            return pathCommand;
        }
    }
}
