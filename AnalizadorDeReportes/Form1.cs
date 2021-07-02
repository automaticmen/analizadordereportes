using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorDeReportes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Analizador reporte = new Analizador(@"C:\Users\Jorge Aguilera Perez\Desktop\Borrar");
            reporte.SetDirectorio(@"C:\Users\Jorge Aguilera Perez\Desktop\Borrar");
        }


        private void registroFiltro_YadianBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.registroFiltro_YadianBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.currentDBDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'currentDBDataSet.RegistroFiltro_Yadian' table. You can move, or remove it, as needed.
            this.registroFiltro_YadianTableAdapter.Fill(this.currentDBDataSet.RegistroFiltro_Yadian);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.registroFiltro_YadianTableAdapter.FillBy(this.currentDBDataSet.RegistroFiltro_Yadian);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
