using System;

namespace QueryCodeGen
{
    partial class formQueryCodeGen
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
            this.btnGetSchema = new System.Windows.Forms.Button();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGenerator = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSchemaService = new System.Windows.Forms.ComboBox();
            this.dgvSchema = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtGeneratedCode = new System.Windows.Forms.RichTextBox();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetSchema
            // 
            this.btnGetSchema.Location = new System.Drawing.Point(12, 373);
            this.btnGetSchema.Name = "btnGetSchema";
            this.btnGetSchema.Size = new System.Drawing.Size(75, 23);
            this.btnGetSchema.TabIndex = 0;
            this.btnGetSchema.Text = "GetSchema";
            this.btnGetSchema.UseVisualStyleBackColor = true;
            this.btnGetSchema.Click += new System.EventHandler(this.btnGetSchema_Click);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(12, 101);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(502, 54);
            this.txtConnectionString.TabIndex = 1;
            this.txtConnectionString.Text = "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SQL Query";
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(12, 19);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(172, 20);
            this.txtClassName.TabIndex = 5;
            this.txtClassName.Text = "NewClass";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ConnectionString/Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Class Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(527, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Class";
            // 
            // cmbGenerator
            // 
            this.cmbGenerator.FormattingEnabled = true;
            this.cmbGenerator.Location = new System.Drawing.Point(530, 18);
            this.cmbGenerator.Name = "cmbGenerator";
            this.cmbGenerator.Size = new System.Drawing.Size(409, 21);
            this.cmbGenerator.TabIndex = 9;
            this.cmbGenerator.SelectedIndexChanged += new System.EventHandler(this.cmbGenerator_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(527, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Generator";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Schema Service";
            // 
            // cmbSchemaService
            // 
            this.cmbSchemaService.FormattingEnabled = true;
            this.cmbSchemaService.Location = new System.Drawing.Point(12, 56);
            this.cmbSchemaService.Name = "cmbSchemaService";
            this.cmbSchemaService.Size = new System.Drawing.Size(502, 21);
            this.cmbSchemaService.TabIndex = 11;
            // 
            // dgvSchema
            // 
            this.dgvSchema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchema.Location = new System.Drawing.Point(12, 418);
            this.dgvSchema.Name = "dgvSchema";
            this.dgvSchema.Size = new System.Drawing.Size(1008, 279);
            this.dgvSchema.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 399);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Schema";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(945, 16);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 15;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtGeneratedCode
            // 
            this.txtGeneratedCode.AcceptsTab = true;
            this.txtGeneratedCode.Location = new System.Drawing.Point(530, 73);
            this.txtGeneratedCode.Name = "txtGeneratedCode";
            this.txtGeneratedCode.Size = new System.Drawing.Size(490, 294);
            this.txtGeneratedCode.TabIndex = 16;
            this.txtGeneratedCode.Text = "";
            this.txtGeneratedCode.WordWrap = false;
            // 
            // txtQuery
            // 
            this.txtQuery.AcceptsTab = true;
            this.txtQuery.Location = new System.Drawing.Point(15, 183);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(499, 184);
            this.txtQuery.TabIndex = 17;
            this.txtQuery.Text = "";
            this.txtQuery.WordWrap = false;
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(QueryCodeGen.Program);
            // 
            // formQueryCodeGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 704);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.txtGeneratedCode);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvSchema);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbSchemaService);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbGenerator);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.btnGetSchema);
            this.Name = "formQueryCodeGen";
            this.Text = "Query Code Gen";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetSchema;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGenerator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSchemaService;
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.DataGridView dgvSchema;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RichTextBox txtGeneratedCode;
        private System.Windows.Forms.RichTextBox txtQuery;
    }
}

