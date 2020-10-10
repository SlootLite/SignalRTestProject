using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Common
{
    public class PercentCalculator
    {
        public int CalculatePercent(int count, int maxIndex)
        {
            double percent = count * 100 / maxIndex;
            return (int)Math.Round(percent, 0);
        }
    }
}
