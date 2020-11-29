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
        }

         public void ListenToGamepad(object obj)
        {
            var joystick = obj as Joystick;
            while (true)
            {
                joystick.Poll();
                var datas = joystick.GetBufferedData();
                foreach(var state in datas)
                {
                    Console.WriteLine(state);
                }
            }
        }
    }
}
