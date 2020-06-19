// using Library;
using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Drawing;
// using System.Linq;
// using System.ServiceProcess;
// using System.Text;
// using System.Threading;
// using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp = System.Windows.Forms.Application;

namespace Library
{   
    public class Notifier : Form
    {         
        private NotifyIcon  notifyIcon;
        
        public Notifier(string message)
        {            
            try
            {
                this.notifyIcon = new NotifyIcon();                            
                this.notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);      
                this.notifyIcon.Visible = true;
                this.ShowInfoBalloon(message);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Notifier constructor failed");
                throw;
            }                                   
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible       = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar. 
            base.OnLoad(e);
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {                
                notifyIcon.Dispose();
            } 
            base.Dispose(isDisposing);
        }

        public void ShowInfoBalloon(string message)
        {   
            int timeout = 8192;         
            this.notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            this.notifyIcon.BalloonTipTitle = "";
            this.notifyIcon.BalloonTipText = message;
            this.notifyIcon.ShowBalloonTip(timeout);
        }

        public static int Main(string[] args)
        {
            string message = string.Join(" ", args).Trim();
            if (message.Length > 0)
            {
                var app = new Notifier(message);
                Application.Run(app);
                return 0;
            }
            else
                return -1;
        }
    }
}