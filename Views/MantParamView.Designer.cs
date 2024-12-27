
namespace ProyectoViaje.Views
{
    partial class MantParamView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControlParam = new System.Windows.Forms.TabControl();
            this.tbControlListado = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMant = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMant = new System.Windows.Forms.Button();
            this.txtCodParamMant = new System.Windows.Forms.TextBox();
            this.txtCodIdenMant = new System.Windows.Forms.TextBox();
            this.chkHabilitadoMant = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtValor1Mant = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtValor2Mant = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.chkHabiltaFiltro = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtFiltroCodIden = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltroCodParam = new System.Windows.Forms.TextBox();
            this.dgvParametros = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tabControlParam.SuspendLayout();
            this.tbControlListado.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParametros)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1379, 57);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mantenimiento de Parametros";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 798);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1379, 44);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // tabControlParam
            // 
            this.tabControlParam.Controls.Add(this.tbControlListado);
            this.tabControlParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlParam.Location = new System.Drawing.Point(0, 57);
            this.tabControlParam.Name = "tabControlParam";
            this.tabControlParam.SelectedIndex = 0;
            this.tabControlParam.Size = new System.Drawing.Size(1379, 741);
            this.tabControlParam.TabIndex = 2;
            // 
            // tbControlListado
            // 
            this.tbControlListado.Controls.Add(this.panel4);
            this.tbControlListado.Controls.Add(this.panel3);
            this.tbControlListado.Controls.Add(this.panel2);
            this.tbControlListado.Controls.Add(this.dgvParametros);
            this.tbControlListado.Location = new System.Drawing.Point(4, 22);
            this.tbControlListado.Name = "tbControlListado";
            this.tbControlListado.Padding = new System.Windows.Forms.Padding(3);
            this.tbControlListado.Size = new System.Drawing.Size(1371, 715);
            this.tbControlListado.TabIndex = 0;
            this.tbControlListado.Text = "Mant.";
            this.tbControlListado.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnNuevo);
            this.panel4.Controls.Add(this.btnEditar);
            this.panel4.Location = new System.Drawing.Point(923, 26);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(403, 57);
            this.panel4.TabIndex = 14;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.Salmon;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(12, 7);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(145, 39);
            this.btnNuevo.TabIndex = 5;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Tomato;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(248, 7);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(137, 41);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Seleccionar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblMant);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.btnMant);
            this.panel3.Controls.Add(this.txtCodParamMant);
            this.panel3.Controls.Add(this.txtCodIdenMant);
            this.panel3.Controls.Add(this.chkHabilitadoMant);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtValor1Mant);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtValor2Mant);
            this.panel3.Location = new System.Drawing.Point(923, 89);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(440, 602);
            this.panel3.TabIndex = 13;
            // 
            // lblMant
            // 
            this.lblMant.AutoSize = true;
            this.lblMant.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMant.Location = new System.Drawing.Point(147, 42);
            this.lblMant.Name = "lblMant";
            this.lblMant.Size = new System.Drawing.Size(100, 25);
            this.lblMant.TabIndex = 0;
            this.lblMant.Text = "Registro";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "Código Parámetro";
            // 
            // btnMant
            // 
            this.btnMant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnMant.FlatAppearance.BorderSize = 0;
            this.btnMant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMant.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMant.ForeColor = System.Drawing.Color.Black;
            this.btnMant.Location = new System.Drawing.Point(30, 458);
            this.btnMant.Name = "btnMant";
            this.btnMant.Size = new System.Drawing.Size(233, 39);
            this.btnMant.TabIndex = 12;
            this.btnMant.Text = "Insertar Registro";
            this.btnMant.UseVisualStyleBackColor = false;
            // 
            // txtCodParamMant
            // 
            this.txtCodParamMant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodParamMant.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodParamMant.Location = new System.Drawing.Point(210, 131);
            this.txtCodParamMant.Name = "txtCodParamMant";
            this.txtCodParamMant.Size = new System.Drawing.Size(216, 29);
            this.txtCodParamMant.TabIndex = 1;
            // 
            // txtCodIdenMant
            // 
            this.txtCodIdenMant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodIdenMant.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodIdenMant.Location = new System.Drawing.Point(210, 192);
            this.txtCodIdenMant.Name = "txtCodIdenMant";
            this.txtCodIdenMant.Size = new System.Drawing.Size(216, 29);
            this.txtCodIdenMant.TabIndex = 3;
            // 
            // chkHabilitadoMant
            // 
            this.chkHabilitadoMant.AutoSize = true;
            this.chkHabilitadoMant.Checked = true;
            this.chkHabilitadoMant.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHabilitadoMant.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHabilitadoMant.Location = new System.Drawing.Point(210, 388);
            this.chkHabilitadoMant.Name = "chkHabilitadoMant";
            this.chkHabilitadoMant.Size = new System.Drawing.Size(112, 28);
            this.chkHabilitadoMant.TabIndex = 10;
            this.chkHabilitadoMant.Text = "Habilitado";
            this.chkHabilitadoMant.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "Código Identificador";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(29, 388);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 24);
            this.label9.TabIndex = 9;
            this.label9.Text = "Habilitación";
            // 
            // txtValor1Mant
            // 
            this.txtValor1Mant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor1Mant.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor1Mant.Location = new System.Drawing.Point(210, 262);
            this.txtValor1Mant.Name = "txtValor1Mant";
            this.txtValor1Mant.Size = new System.Drawing.Size(216, 29);
            this.txtValor1Mant.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 323);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 24);
            this.label8.TabIndex = 8;
            this.label8.Text = "Valor 2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Valor 1";
            // 
            // txtValor2Mant
            // 
            this.txtValor2Mant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor2Mant.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor2Mant.Location = new System.Drawing.Point(210, 323);
            this.txtValor2Mant.Name = "txtValor2Mant";
            this.txtValor2Mant.Size = new System.Drawing.Size(216, 29);
            this.txtValor2Mant.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.chkHabiltaFiltro);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Controls.Add(this.txtFiltroCodIden);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtFiltroCodParam);
            this.panel2.Location = new System.Drawing.Point(11, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(891, 143);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Código Identificador";
            // 
            // chkHabiltaFiltro
            // 
            this.chkHabiltaFiltro.AutoSize = true;
            this.chkHabiltaFiltro.Checked = true;
            this.chkHabiltaFiltro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHabiltaFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHabiltaFiltro.Location = new System.Drawing.Point(555, 19);
            this.chkHabiltaFiltro.Name = "chkHabiltaFiltro";
            this.chkHabiltaFiltro.Size = new System.Drawing.Size(112, 28);
            this.chkHabiltaFiltro.TabIndex = 9;
            this.chkHabiltaFiltro.Text = "Habilitado";
            this.chkHabiltaFiltro.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(429, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Habilitación";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Tan;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(673, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(195, 33);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // txtFiltroCodIden
            // 
            this.txtFiltroCodIden.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroCodIden.Location = new System.Drawing.Point(204, 84);
            this.txtFiltroCodIden.Name = "txtFiltroCodIden";
            this.txtFiltroCodIden.Size = new System.Drawing.Size(201, 29);
            this.txtFiltroCodIden.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Código Identificador";
            // 
            // txtFiltroCodParam
            // 
            this.txtFiltroCodParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroCodParam.Location = new System.Drawing.Point(204, 19);
            this.txtFiltroCodParam.Name = "txtFiltroCodParam";
            this.txtFiltroCodParam.Size = new System.Drawing.Size(201, 29);
            this.txtFiltroCodParam.TabIndex = 2;
            // 
            // dgvParametros
            // 
            this.dgvParametros.AllowUserToAddRows = false;
            this.dgvParametros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvParametros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParametros.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParametros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvParametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParametros.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvParametros.Location = new System.Drawing.Point(11, 190);
            this.dgvParametros.Name = "dgvParametros";
            this.dgvParametros.ReadOnly = true;
            this.dgvParametros.Size = new System.Drawing.Size(891, 502);
            this.dgvParametros.TabIndex = 0;
            // 
            // MantParamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 842);
            this.Controls.Add(this.tabControlParam);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MantParamView";
            this.Text = "MantParamView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControlParam.ResumeLayout(false);
            this.tbControlListado.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParametros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlParam;
        private System.Windows.Forms.TabPage tbControlListado;
        private System.Windows.Forms.DataGridView dgvParametros;
        private System.Windows.Forms.TextBox txtFiltroCodParam;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtFiltroCodIden;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblMant;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtValor1Mant;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodIdenMant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodParamMant;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtValor2Mant;
        private System.Windows.Forms.CheckBox chkHabilitadoMant;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnMant;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkHabiltaFiltro;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label2;
    }
}