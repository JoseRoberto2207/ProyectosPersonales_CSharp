using System;
using System.Windows.Forms;
using Sydn.CRUD.LogicEngine;
using System.Runtime.InteropServices;

namespace Sydn.CRUD.Presentacion
{
    public partial class Form1 : Form
    {
        Logic logic = new Logic();
        private bool Editar = false;
        private string idProducto = null;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }
        private void MostrarProductos()
        {            
            dataGridView1.DataSource = logic.MostrarProd();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Insertar
            if (Editar == false)
            {
                try
                {
                    logic.InsertProduct(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Registro insertado correctamente");
                    MostrarProductos();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar los datos: " + ex);
                }
            }
            //Editar
            else if (Editar == true)
            {
                try
                {
                    logic.EditProduct(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Registro editado correctamente");
                    limpiarForm();
                    MostrarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error el editar el registro: " + ex);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un registro para editar");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                logic.EliminarProduct(idProducto);
                MessageBox.Show("Registro eliminado correctamente");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar");
            }
        }
        private void limpiarForm()
        {
            txtNombre.Clear();
            txtDesc.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }        
    }
}
