using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memorama.Clase
{
    class Btn_M
    {
        public event EventHandler Btn_Cl;
        public void OnBtn_Cl()
        {
            EventHandler handler = Btn_Cl;
            if (null != handler) handler(this, EventArgs.Empty);
        }
    }
}
