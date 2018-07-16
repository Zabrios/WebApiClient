using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Windows.Forms;

namespace WebApiClient
{
    public partial class Form1 : Form
    {
        HttpApiController controller;

        public Form1()
        {
            InitializeComponent();
            GridAlumnos.AutoGenerateColumns = true;
            controller = new HttpApiController();
            //Console.WriteLine(Resources.www);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<AlumnoModelView> alumnos = new List<AlumnoModelView>();
            alumnos = controller.GetCall().Result; //$$$$$$$;
            GridAlumnos.DataSource = alumnos;
            GridAlumnos.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlumnoModelView al = new AlumnoModelView("John", "Vergas", "9999999");
            controller.PostCall(al);

            Form2 f2 = new Form2();
            f2.Show();
            //f2.Close();
        }
    }
}
