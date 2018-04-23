using System;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.XtraBars.Alerter;
using DevExpress.ExpressApp.Utils;

namespace WinSolution.Module {
    public class ShowAlertControlMainWindowController : WindowController {
        private AlertControl alertControlCore;
        private Timer alertTimerCore;
        public ShowAlertControlMainWindowController() {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated() {
            base.OnActivated();
            InitAlertControlCore();
            InitAlertTimerCore();
        }
        protected virtual void InitAlertControlCore() {
            alertControlCore = new AlertControl();
        }
        protected virtual void InitAlertTimerCore() {
            alertTimerCore = new Timer();
            alertTimerCore.Tick += alertTimerCore_Tick;
            alertTimerCore.Interval = 2000;
            alertTimerCore.Start();
        }
        private void alertTimerCore_Tick(object sender, EventArgs e) {
            ShowAlertInfo();
        }
        protected override void OnDeactivated() {
            if (alertTimerCore != null)
                alertTimerCore.Stop();
            base.OnDeactivated();
        }
        protected virtual void ShowAlertInfo() {
            Form mainForm = (Form)Application.MainWindow.Template;
            AlertInfo info = new AlertInfo("Frohe Weihnachten! (Merry Christmas!)", DateTime.Now.ToString(), ImageLoader.Instance.GetImageInfo("Attention").Image);
            AlertControl.Show(mainForm, info);
        }
        public AlertControl AlertControl { get { return alertControlCore; } }
        public Timer AlertTimer { get { return alertTimerCore; } }
    }
}