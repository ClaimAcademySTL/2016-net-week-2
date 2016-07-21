using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Boundary
    {
        protected Boolean CheckAddBound(double fNum, double sNum)
        {
            if (fNum > 0 && sNum > 0 && sNum > (Double.MaxValue - fNum))
            {
                return false;
            }
            else if (fNum < 0 && sNum < 0 && sNum < (Double.MinValue - fNum))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected Boolean CheckSubBound(double fNum, double sNum)
        {
            if (fNum > 0 && sNum < 0 && sNum < (fNum - Double.MaxValue))
            {
                return false;
            }
            else if (fNum < 0 && sNum > 0 && sNum > (fNum - Double.MinValue))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected Boolean CheckDivBound(double fNum, double sNum)
        {
            if (sNum == 0)
            {
                return false;
            }
            else if (fNum > 0 && sNum > 0 && sNum < (fNum / Double.MaxValue))
            {
                return false;
            }
            else if (fNum < 0 && sNum < 0 && sNum > (fNum / Double.MaxValue))
            {
                return false;
            }
            else if (GetAbsVal(sNum) < (GetAbsVal(fNum / Double.MinValue)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected Boolean CheckMultBound(double fNum, double sNum)
        {
            if (fNum > 0 && sNum > 0 && sNum > (Double.MaxValue / fNum))
            {
                return false;
            }
            else if (fNum < 0 && sNum < 0 && sNum < (Double.MaxValue / fNum))
            {
                return false;
            }
            else if (fNum > 0 && sNum < 0 && sNum < (Double.MinValue / fNum))
            {
                return false;
            }
            else if (fNum < 0 && sNum > 0 && GetAbsVal(sNum) > (Double.MinValue / fNum))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private double GetAbsVal(double num)
        {
            if (num < 0)
            {
                return -(num);
            }
            return num;
        }
    }
}
