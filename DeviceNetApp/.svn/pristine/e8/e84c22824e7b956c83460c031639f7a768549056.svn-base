using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceNetApp.Lib
{
    class Utils
    {
        public static Int64 GetTickCountDelta(Int64 iStartTime)
        {
            Int64 iDelta = 0;
            try
            {
                Int64 iNow = Environment.TickCount;

                if (iStartTime > iNow)
                {
                    // TickCount jumps from Int32.MaxValue to Int32.MinValue
                    iDelta = (int.MaxValue - iStartTime) + (iNow - int.MinValue);
                }
                else
                {
                    iDelta = iNow - iStartTime;
                }

            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return iDelta;
        }

        public static Boolean CalculateRSTiSize(List<Slot> lstSlot,ProcessImageType eType,ref int iInputSize,ref int iOutputSize)
        {
            try
            {
                //Int32 input = 0;
                //Int32 output = 0;
                //if ()
                //{
                //}
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
                return false;
            }
            return true;
        }
    }
}
