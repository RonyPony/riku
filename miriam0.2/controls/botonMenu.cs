using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using riku;

namespace riku.controls
{
    public partial class botonMenu : Button
    {
        public botonMenu()
        {
            InitializeComponent();
            getColor();
            this.BackgroundImageLayout = ImageLayout.Zoom;
            this.Text = "";
        }

        public void getColor()
        {
            string color = riku.Properties.Settings.Default.color;
            switch (color)
            {
                case "rojo":
                    this.BackColor = Color.DarkRed;
                    this.ForeColor = Color.White;
                    break;
                case "azul":
                    this.BackColor = Color.Blue;
                    this.ForeColor = Color.White;
                    
                    break;

                case "blanco":
                    this.BackColor = Color.White;
                    this.ForeColor = Color.Black;
                    
                    break;
                default:
                    break;
            }
        }

        private void botonMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
