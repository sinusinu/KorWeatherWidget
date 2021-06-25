/*
 * Copyright © 2021 Woohyun Shin <cpu344@gmail.com>
 * This work is free. You can redistribute it and/or modify it under the
 * terms of the Do What The Fuck You Want To Public License, Version 2,
 * as published by Sam Hocevar. See the LICENSE file for more details.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace WeatherWidget {
    public partial class frmWidget : Form {
        private readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOACTIVATE = 0x0010;

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private const int WS_EX_TOOLWINDOW = 0x80;

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        static extern bool ReleaseCapture();

        private string[] weatherIconFiles = new string[] { 
            "dots-horizontal",
            "weather-sunny",
            "weather-partly-cloudy",
            "weather-cloudy",
            "weather-rainy",
            "weather-snowy-rainy",
            "weather-snowy",
            "weather-pouring"
        };

        private DateTime lastUpdateDate = new DateTime();
        private string zoneId = "1114061500";

        private string weatherLocation = "";
        private string weatherTemp = "";
        private string weatherText = "";
        private int weatherIcon = 0;
        private bool isLastUpdateSuccessful = false;

        public frmWidget() {
            InitializeComponent();
        }

        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.ExStyle |= WS_EX_TOOLWINDOW;
                return cp;
            }
        }

        private void frmWidget_Load(object sender, EventArgs e) {
            Location = new Point(
                Screen.PrimaryScreen.WorkingArea.X + Screen.PrimaryScreen.WorkingArea.Width - Size.Width - 100,
                Screen.PrimaryScreen.WorkingArea.Y + Screen.PrimaryScreen.WorkingArea.Height - Size.Height - 100
            );
            if (File.Exists("zone.txt")) {
                var tmpZoneId = File.ReadAllText("zone.txt");
                if (!tmpZoneId.Any(char.IsWhiteSpace)) {
                    zoneId = tmpZoneId;
                }
            }
            StickToBottom();
            TryUpdateData();
        }

        private void frmWidget_Activated(object sender, EventArgs e) {
            StickToBottom();
        }

        private void TryUpdateData() {
            var currentDate = DateTime.Now;
            var targetUpdateDate = lastUpdateDate.AddHours(1);
            if (targetUpdateDate < currentDate) {
                lastUpdateDate = DateTime.Now;
                bwDataUpdater.RunWorkerAsync();
            }
        }

        private void StickToBottom() {
            // comment this line to prevent window going bottommost
            SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
        }

        private void bwDataUpdater_DoWork(object sender, DoWorkEventArgs e) {
            isLastUpdateSuccessful = false;

            var kmaUrl = "http://www.kma.go.kr/wid/queryDFSRSS.jsp?zone=" + zoneId;
            string kmaData;
            try {
                using (var wc = new WebClient()) {
                    kmaData = wc.DownloadString(kmaUrl);
                }
            } catch (Exception) {
                ttLastUpdateTimeTeller.SetToolTip(pbxIcon, "데이터를 받지 못했습니다, 다음 업데이트 기다리는 중");
                return;
            }

            var kmaXml = new XmlDocument();

            try {
                kmaXml.LoadXml(kmaData);
            } catch (Exception) {
                ttLastUpdateTimeTeller.SetToolTip(pbxIcon, "수신된 데이터가 올바르지 않습니다, 다음 업데이트 기다리는 중");
                return;
            }

            try {
                var loc = kmaXml.GetElementsByTagName("category");
                weatherLocation = loc[0].InnerText;
                var data = kmaXml.GetElementsByTagName("data");
                weatherTemp = data[0].ChildNodes[2].InnerText + "℃";
                weatherText = data[0].ChildNodes[7].InnerText;
                var sky = int.Parse(data[0].ChildNodes[5].InnerText);
                var pty = int.Parse(data[0].ChildNodes[6].InnerText);
                switch (pty) {
                    case 0:
                        // no rain or snow
                        switch (sky) {
                            case 1:
                                // sunny
                                weatherIcon = 1;
                                break;
                            case 3:
                                // partly cloudy
                                weatherIcon = 2;
                                break;
                            case 4:
                                // cloudy
                                weatherIcon = 3;
                                break;
                            default:
                                weatherIcon = 0;
                                break;
                        }
                        break;
                    case 1:
                        // rain
                        weatherIcon = 4;
                        break;
                    case 2:
                        // rain+snow
                        weatherIcon = 5;
                        break;
                    case 3:
                        // snow
                        weatherIcon = 6;
                        break;
                    case 4:
                        // pouring
                        weatherIcon = 7;
                        break;
                    default:
                        weatherIcon = 0;
                        break;
                }
            } catch (Exception) {
                ttLastUpdateTimeTeller.SetToolTip(pbxIcon, "필요한 데이터를 찾을 수 없습니다, 다음 업데이트 기다리는 중");
                return;
            }

            isLastUpdateSuccessful = true;
        }

        private void bwDataUpdater_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (isLastUpdateSuccessful) {
                lblLocation.Text = weatherLocation;
                lblTemperature.Text = weatherTemp;
                lblText.Text = weatherText;
                pbxIcon.Image = Image.FromFile(@"res\" + weatherIconFiles[weatherIcon] + ".png");
                ttLastUpdateTimeTeller.SetToolTip(pbxIcon, "마지막 업데이트: " + DateTime.Now.ToString());
            }
        }

        private void tmrUpdateInvoker_Tick(object sender, EventArgs e) {
            TryUpdateData();
        }

        private void frmWidget_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            } else if (e.Button == MouseButtons.Right) {
                csmContextMenu.Show(new Point(Location.X + e.Location.X, Location.Y + e.Location.Y));
            }
        }

        private void ControlsMouseDown(object sender, MouseEventArgs e) {
            frmWidget_MouseDown(sender, e);
        }

        private void tsmExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void frmWidget_Resize(object sender, EventArgs e) {
            // prevent minimize/maximize
            if (WindowState != FormWindowState.Minimized) {
                WindowState = FormWindowState.Normal;
            }
        }
    }
}
