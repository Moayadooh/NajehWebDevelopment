using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise
{
    class PassByValueReference
    {
        public void Run()
        {
            int x = 2;
            PassByVal(x);
            Console.WriteLine(x);

            PassByRef(ref x);
            Console.WriteLine(x);

            Device device = new Device();
            device.deviceName = "Galaxy";
            Console.WriteLine(device.deviceName);
            PassObj(device);
            Console.WriteLine(device.deviceName);
        }

        public void PassByVal(int x)
        {
            x = 5;
        }

        public void PassByRef(ref int x)
        {
            x = 10;
        }

        public void PassObj(Device obj)
        {
            obj.deviceName = "iPhone";
        }
    }

    class Device
    {
        public string deviceName;
    }
}
