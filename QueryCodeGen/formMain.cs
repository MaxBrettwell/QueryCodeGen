using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QueryCodeGen.Factory;
using QueryCodeGen.Service;

namespace QueryCodeGen
{
    public partial class formQueryCodeGen : Form
    {

        System.Data.DataTable schemaTable;

        public formQueryCodeGen()
        {
            InitializeComponent();

            this.cmbSchemaService.DisplayMember = "SchemaServiceName";
            this.cmbSchemaService.DataSource = Program.SchemaServices;

            this.cmbGenerator.DisplayMember = "GeneratorName";
            this.cmbGenerator.DataSource = Program.CodeGenerators;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ISchemaService selectedSchemaService = (ISchemaService)this.cmbSchemaService.SelectedItem;
            //MessageBox.Show(selectedSchemaService.SchemaServiceName);

            ICodeGenerator selectedCodeGenerator = (ICodeGenerator)this.cmbGenerator.SelectedItem;
            //MessageBox.Show(selectedCodeGenerator.GeneratorName);

            try
            {
                this.dgvSchema.DataSource = null;                
                schemaTable = selectedSchemaService.getTableSchema(txtConnectionString.Text, txtQuery.Text);
                this.Refresh();
                System.Threading.Thread.Sleep(10);
                this.dgvSchema.DataSource = schemaTable;
                return;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtQuery_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
