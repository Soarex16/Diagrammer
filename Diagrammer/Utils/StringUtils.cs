using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Diagrammer.Utils {
    static class StringUtils {
        public static double[] ParseDataString(String str) {
            List<double> data = new List<double>();
            string[] splitted = str.Split(' ');

            for (int i = 0; i < splitted.Length; ++i) {
                if (!String.IsNullOrWhiteSpace(splitted[i])) {
                    double d;
                    if (double.TryParse(splitted[i], NumberStyles.Any, NumberFormatInfo.InvariantInfo,out d)) {
                        data.Add(d);
                    }
                }
            }

            return data.ToArray();
        }
    }
}
