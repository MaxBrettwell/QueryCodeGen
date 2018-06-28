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

        private void getSchema() {
            ISchemaService selectedSchemaService = (ISchemaService)this.cmbSchemaService.SelectedItem;
            //MessageBox.Show(selectedSchemaService.SchemaServiceName);

            ICodeGenerator selectedCodeGenerator = (ICodeGenerator)this.cmbGenerator.SelectedItem;
            //MessageBox.Show(selectedCodeGenerator.GeneratorName);

            try
            {
                this.dgvSchema.DataSource = null;
                schemaTable = selectedSchemaService.getSchema(txtConnectionString.Text, txtQuery.Text);

                foreach (DataColumn c in schemaTable.Columns) {
                    c.ReadOnly = false;
                }

                this.Refresh();
                System.Threading.Thread.Sleep(10);
                this.dgvSchema.DataSource = schemaTable;
                


                this.dgvSchema.ReadOnly = false;
                foreach (DataGridViewRow r in this.dgvSchema.Rows) {
                    r.ReadOnly = false;
                }
                foreach (DataGridViewColumn c in this.dgvSchema.Columns)
                {
                    c.ReadOnly = false;
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void generate()
        {
            ICodeGenerator selectedCodeGenerator = (ICodeGenerator)this.cmbGenerator.SelectedItem;
            this.txtGeneratedCode.Text = selectedCodeGenerator.Generate(this.txtClassName.Text, this.schemaTable);
            //MessageBox.Show(selectedSchemaService.SchemaServiceName);

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.generate();            
        }

        private void btnGetSchema_Click(object sender, EventArgs e)
        {
            this.getSchema();
        }

        private void cmbGenerator_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
