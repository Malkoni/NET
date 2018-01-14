using System.Windows.Forms;

namespace Kalkulator
{
    class Przycisk : Button
    {
        public Przycisk()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
