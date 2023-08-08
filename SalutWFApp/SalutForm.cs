using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalutWFApp
{
    public partial class SalutForm : Form
    {
        public Brush randomBrush;
        public static Random random = new Random();      
        public SalutForm()
        {
            InitializeComponent();
        }

        private void SalutForm_MouseDown(object sender, MouseEventArgs e)
        {
            var startBall = new StartSalutBall(this, random);
            startBall.Start();                            
        }
        
    }
    }
