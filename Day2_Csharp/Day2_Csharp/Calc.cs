using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Csharp
{
    class Calc
    {
        #region MyRegion1
        public int getValue(int x)
        {
            return x;
        }

        public int getMinValue(int v1, int v2)
        {
            int result;
            if (v1 < v2)
            {
                result = v1;
            }
            else
            {
                result = v2;
            }
            return result;
        }
        #endregion

        // Pass by Value
        public void getByVal(int x)
        {
            x = 1000;
        }

        //Pass by Reference
        public void getByRef(ref int y)
        {
            y = 4000;
        }
        //==================================================
        public static void getByVal2(int x)
        {
            x = 1000;
        }

        //Pass by Reference
        public static void getByRef2(ref int y)
        {
            y = 4000;
        }
    }
}
