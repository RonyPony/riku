using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace riku.controls
{
    public partial class menuContextual : UserControl
    {
        bool isOpen = false;

        public menuContextual()
        {
            InitializeComponent();
        }

        public Color color   // property
        {
            get { return this.BackColor; }   // get method
            set { this.BackColor = value; treeView1.BackColor = value; }  // set method
        }

        public Color fontColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks menuOption")]
        public event EventHandler contextOption;


        private void menuContextual_Load(object sender, EventArgs e)
        {
            updateRoles();
        }

        private void updateRoles()
        {
            foreach (TreeNode item in treeView1.Nodes)
            {
                if (item.Nodes.Count>0)
                {

                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                
                if (this.contextOption != null)
                    this.contextOption(this, e);
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {//391; 444
            if (isOpen)
            {
                this.Width = 41;
                button1.Image = riku.Properties.Resources.baseline_menu_black_18dp;
                
                isOpen = false;
            }
            else
            {
                this.Width = 391;
               button1.Image = riku.Properties.Resources.baseline_menu_open_black_18dp;
                isOpen = true;
            }
            
        }
    }
}
