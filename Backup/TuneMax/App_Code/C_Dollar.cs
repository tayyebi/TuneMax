using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuneMax.Models;

namespace TuneMax.App_Code
{
    public class C_Dollar
    {
        static public int GetPriceInDollar(int PriceInDollar)
        {
            int output = 0;
            try
            {
                DollarRepository _DollarRep = new DollarRepository();
                int CurrentDollarPrice = Convert.ToInt32(_DollarRep.CurrentDollar());
                output = CurrentDollarPrice * PriceInDollar;
            }
            catch
            {
            }
            return output;
        }
    }
}