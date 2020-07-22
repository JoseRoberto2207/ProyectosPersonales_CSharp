using Sydn.CRUD.LogicEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sydn.CRUD.Forms
{
    public partial class Form1 : Form
    {
        //Logic logic = new Logic();


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void MostrarProductos()
        {
            Logic logic = new Logic();
            dataGridView1.DataSource = logic.MostrarProd();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
