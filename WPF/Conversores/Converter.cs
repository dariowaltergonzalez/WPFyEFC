using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPF.Conversores
{
    public class Converter : IValueConverter
    {

        public Converter() 
        {

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strNum = System.Convert.ToDouble(value.ToString()).ToString("0,000");
            double dNum = System.Convert.ToDouble(strNum);
            //int intNum = System.Convert.ToInt32(dNum);
            //if (intNum == dNum)
            //{
            //    return intNum;
            //}
            //else
            //{
            //    return dNum.ToString("0,000");
            //}
            return dNum.ToString("C");

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
