using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MasjidRamadhan.UI
{
    public static class ErrorProviderExtensions
    {
        private static int count = 0;

        public static void SetError(this ErrorProvider ep, Control c, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                if (!string.IsNullOrEmpty(ep.GetError(c)))
                    count--;
            }
            else
                if (string.IsNullOrEmpty(ep.GetError(c)))
                    count++;

            ep.SetError(c, message);
        }

        public static bool HasErrors(this ErrorProvider ep)
        {
            return count != 0;
        }

        public static int GetErrorCount(this ErrorProvider ep)
        {
            return count;
        }
    }
}
