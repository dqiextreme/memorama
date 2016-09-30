using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memorama.Clase
{
    public class c1
    {
        public event EventHandler Jump;
        public void OnJump()
        {
            EventHandler handler = Jump;
            if (null != handler) handler(this, EventArgs.Empty);
        }
    }
}
