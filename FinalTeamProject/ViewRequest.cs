using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FinalTeamProject
{
    public partial class ViewRequest : Form
    {
        public ViewRequest(string Changed, string Original)
        {
            InitializeComponent();
            GetText(Original, 1);
            GetText(Changed, 2);
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void GetText (string Path, int Process)
        {
            byte[] data = File.ReadAllBytes(Path);
            string contents = Encoding.ASCII.GetString(data);

            if (Process == 1)
                orig_box.Text = contents;
            else
                changed_box.Text = contents;
        }
    }
}
