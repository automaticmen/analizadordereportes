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
        string DirectorioDeTrabajo = "";
        public Form1()
        {
            InitializeComponent();
        }


        private void registroFiltro_YadianBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.registroFiltro_YadianBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.currentDBDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult resultado = folderBrowserDialog1.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                Analizador reporte = new Analizador(folderBrowserDialog1.SelectedPath);
                reporte.Analisis();
            }
        }
    }
}
