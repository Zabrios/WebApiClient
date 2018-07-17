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
        //HttpApiController controller;

        public Form1()
        {
            InitializeComponent();
            GridAlumnos.AutoGenerateColumns = true;
            //controller = new HttpApiController();
            //Console.WriteLine(Resources.www);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<AlumnoModelView> alumnos = new List<AlumnoModelView>();
            alumnos = HttpApiController.GetCall().Result; //$$$$$$$;
            GridAlumnos.DataSource = alumnos;
            GridAlumnos.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            //f2.Close();
        }

        private void GridAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form2 f2 = new Form2();
            var alumnoUpdate = new AlumnoModelView(Convert.ToInt32(GridAlumnos.CurrentRow.Cells[0].Value), GridAlumnos.CurrentRow.Cells[1].Value.ToString(),
                                                   GridAlumnos.CurrentRow.Cells[2].Value.ToString(), GridAlumnos.CurrentRow.Cells[3].Value.ToString());
            f2.UpdateRowForm(alumnoUpdate);
            //f2.txtName.Text = this.GridAlumnos.CurrentRow.Cells[1].Value.ToString();
            //f2.txtLastname.Text = this.GridAlumnos.CurrentRow.Cells[2].Value.ToString();
            //f2.txtDni.Text = this.GridAlumnos.CurrentRow.Cells[3].Value.ToString();
            f2.ShowDialog();
            GridAlumnos.Refresh();

        }
    }
}
