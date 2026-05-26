using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DeviceNetApp
{
    public static class IconHelper
    {
        private static Icon _icon;

        public static Icon GetAppIcon()
        {
            if (_icon == null)
            {
                try
                {
                    _icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
                }
                catch
                {
                }
            }
            return _icon;
        }
    }
}