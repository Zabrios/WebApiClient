using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebApiClient
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlumnoModelView alumno = new AlumnoModelView(txtName.Text, txtLastname.Text, txtDni.Text);

            if (HttpApiController.PostCall(alumno).Result)
            {
                MessageBox.Show("Insertion ok.");
            }
            else
            {
                MessageBox.Show("Insertion fail.");

            }
        }
    }
}
