namespace AnalizadorDeReportes
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.currentDBDataSet = new AnalizadorDeReportes.CurrentDBDataSet();
            this.registroFiltro_YadianBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.registroFiltro_YadianTableAdapter = new AnalizadorDeReportes.CurrentDBDataSetTableAdapters.RegistroFiltro_YadianTableAdapter();
            this.tableAdapterManager = new AnalizadorDeReportes.CurrentDBDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.currentDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registroFiltro_YadianBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Seleccionar Carpeta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(4, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(335, 208);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // currentDBDataSet
            // 
            this.currentDBDataSet.DataSetName = "CurrentDBDataSet";
            this.currentDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // registroFiltro_YadianBindingSource
            // 
            this.registroFiltro_YadianBindingSource.DataMember = "RegistroFiltro_Yadian";
            this.registroFiltro_YadianBindingSource.DataSource = this.currentDBDataSet;
            // 
            // registroFiltro_YadianTableAdapter
            // 
            this.registroFiltro_YadianTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.RegistroFiltro_YadianTableAdapter = this.registroFiltro_YadianTableAdapter;
            this.tableAdapterManager.UpdateOrder = AnalizadorDeReportes.CurrentDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 264);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(357, 303);
            this.MinimumSize = new System.Drawing.Size(357, 303);
            this.Name = "Form1";
            this.Text = "Analizador de reportes Kronos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.currentDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registroFiltro_YadianBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CurrentDBDataSet currentDBDataSet;
        private System.Windows.Forms.BindingSource registroFiltro_YadianBindingSource;
        private CurrentDBDataSetTableAdapters.RegistroFiltro_YadianTableAdapter registroFiltro_YadianTableAdapter;
        private CurrentDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

