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
        public static bool updateData;
        public static AlumnoModelView updateAlumno;
        public Form2()
        {
            InitializeComponent();
            updateData = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!updateData)
            {
                await AddAlumno(); 
            }
            else
            {
                //var alumno = new AlumnoModelView(txtName.Text, txtLastname.Text, txtDni.Text);
                HttpApiController.PutCall(updateAlumno);
                //bool okStatus = await Task.Run(() => HttpApiController.PutCall(updateAlumno).Result);
                //if (okStatus)
                //{
                //    MessageBox.Show(Resources.InsertOk, Resources.MBHeader);
                //    txtName.Clear(); txtLastname.Clear(); txtDni.Clear();
                //    this.Close();
                //}
                //else
                //{
                //    MessageBox.Show(Resources.InsertionFail, Resources.MBHeader);
                //}
            }
        }

        private async Task AddAlumno()
        {
            AlumnoModelView alumno = new AlumnoModelView(txtName.Text, txtLastname.Text, txtDni.Text);
            bool okStatus = await Task.Run(() => HttpApiController.PostCall(alumno).Result);
            if (okStatus)
            {
                MessageBox.Show(Resources.InsertOk, Resources.MBHeader);
                txtName.Clear(); txtLastname.Clear(); txtDni.Clear();
            }
            else
            {
                MessageBox.Show(Resources.InsertionFail, Resources.MBHeader);
            }
        }

        public void UpdateRowForm(AlumnoModelView alumno)
        {
            updateAlumno = alumno;
            updateData = true;
            txtDni.Text = alumno.Dni;
            txtName.Text = alumno.Nombre;
            txtLastname.Text = alumno.Apellidos;
        }
    }
}
