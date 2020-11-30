using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBCar_Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckJoyStick();
            ServerManager.Init();
        }

        private void CheckJoyStick()
        {
            var directInput = new DirectInput();
            var joystickGuid = Guid.Empty;
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
                joystickGuid = deviceInstance.InstanceGuid;

            if (joystickGuid == Guid.Empty)
            {
                textGPStatus.Text = "手柄状态：未连接";
                return;
            }

            textGPStatus.Text = "手柄状态：已连接";

            var joystick = new Joystick(directInput, joystickGuid);

            joystick.Properties.BufferSize = 128;
            joystick.Acquire();

            ParameterizedThreadStart ts = new ParameterizedThreadStart(ListenToGamepad);
            Thread thread = new Thread(ts);
            thread.Start(joystick);

            new Thread(new ThreadStart(UpdateUI)).Start();

        }

        public void ListenToGamepad(object obj)
        {
            var joystick = obj as Joystick;
            while (true)
            {
                var state = joystick.GetCurrentState();
                DataManager.Cauculate(state.X, state.Y, state.Z);
                Thread.Sleep(20);
            }
        }

        public void UpdateUI()
        {
            while (true)
            {
                this.Invoke(new AsynUpdateUI(delegate ()
                {
                    labelLeftPower.Text = "左马达：" + (DataManager.GetLeftPower() * 100 / DataManager.MAX_POWER) + "%";
                    labelRightPower.Text = "右马达：" + (DataManager.GetRightPower() * 100 / DataManager.MAX_POWER) + "%";
                    labelServer.Text = "小车状态：" + (ServerManager.IsConnect() ? "已连接" : "等待");
                    
                }));
                Thread.Sleep(20);
            }
        }

        delegate void AsynUpdateUI();
    }
}
