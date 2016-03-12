using System;
using Syncfusion.Windows.Forms;

namespace Universal_Inject_Generator
{
    public partial class Splash : MetroForm
    {
        private int _count;
        private int _buffer;

        public Splash()
        {
            InitializeComponent();
            Opacity = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Math.Abs(Opacity - 1) < double.Epsilon)
            {
                timer2.Start();
                timer1.Stop();
            }
            else
            {
                _count++;
                Opacity = _count*0.01;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (_buffer == 3)
            {
                timer3.Start();
                timer2.Stop();
            }
            else
            {
                _buffer++;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Math.Abs(Opacity - 0) < double.Epsilon)
            {
                timer3.Stop();
            }
            else
            {
                _count--;
                Opacity = _count*0.01;
            }
        }
    }
}
