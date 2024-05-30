using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DryiceProgram.MiniClass.ForGUI {
    public class Delay {

        public Delay() {
            //วิธีเรียกใช้
            //1.หน้าฟังก์ชั่นนั้นต้องประกาศเป็น async
            //2.ฟังก์ชั่นที่จะเรียกต้องประกาศเป็น async Task
            //await DelayAsync(1000); 
        }

        public void DelaymS(int milliseconds) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();

            while (milliseconds > stopwatch.ElapsedMilliseconds)
            {
                if (!stopwatch.IsRunning)
                    stopwatch.Start();

                Application.DoEvents();
                Thread.Sleep(1);
            }

            stopwatch.Stop();
        }

        public async Task DelayAsync(int millisecondsDelay) {
            Stopwatch stopwatch = Stopwatch.StartNew();
            System.Timers.Timer timer = new System.Timers.Timer(10) { AutoReset = true };
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            timer.Elapsed += (sender, args) => {
                if (stopwatch.ElapsedMilliseconds >= millisecondsDelay)
                {
                    timer.Stop();
                    tcs.TrySetResult(true);
                }
            };
            timer.Start();
            await tcs.Task;
        }
    }
}
