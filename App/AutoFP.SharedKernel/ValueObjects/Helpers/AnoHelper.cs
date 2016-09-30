using System;
using System.Collections.Generic;

namespace AutoFP.SharedKernel.ValueObjects.Helpers
{
    public static class AnoHelper
    {
        public static int AnoMinimo { get; } = 1950;

        public static int AnoMaximo { get; } = DateTime.Now.Year + 2;

        public static IEnumerable<int> GetAnos()
        {
            var anos = new List<int>();
            for (var i = AnoMaximo; i >= AnoMinimo; i--)
                anos.Add(i);
            return anos;
        }
    }
}