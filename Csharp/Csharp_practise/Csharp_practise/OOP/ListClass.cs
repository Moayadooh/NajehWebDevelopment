using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise.OOP
{
    class ListClass
    {
        public void Run()
        {
            var device = new Devices();
            device.IOS = "iPhone";
            device.Android = "Galaxy";

            var list = new List<Devices>();
            list.Add(device);

            foreach (var item in list)
            {
                Console.WriteLine(item.IOS + " " + item.Android);
            }

            string num = "123a";
            if (int.TryParse(num, out int result))
                Console.WriteLine("The value can be converted to integer --> " + result);
            else
                Console.WriteLine("The value can not be converted to integer");
        }
        class Devices
        {
            public string IOS { get; set; }
            public string Android { get; set; }
        }
        #region other way
        //struct Devices
        //{
        //    public string IOS { get; set; }
        //    public string Android { get; set; }
        //}
        #endregion
    }
}
