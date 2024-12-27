
namespace ProyectoViaje.Views
{
    partial class CartaPorteView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlCartaPorte = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSelecDestino = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnProcessFiles = new System.Windows.Forms.Button();
            this.txtPathFileDestiny = new System.Windows.Forms.TextBox();
            this.lbFilesSources = new System.Windows.Forms.Label();
            this.btnChooseFiles = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tabControlCartaPorte.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 55);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(0, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carta Porte";
            // 
            // tabControlCartaPorte
            // 
            this.tabControlCartaPorte.Controls.Add(this.tabPage1);
            this.tabControlCartaPorte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCartaPorte.Location = new System.Drawing.Point(0, 55);
            this.tabControlCartaPorte.Name = "tabControlCartaPorte";
            this.tabControlCartaPorte.SelectedIndex = 0;
            this.tabControlCartaPorte.Size = new System.Drawing.Size(800, 469);
            this.tabControlCartaPorte.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSelecDestino);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnProcessFiles);
            this.tabPage1.Controls.Add(this.txtPathFileDestiny);
            this.tabPage1.Controls.Add(this.lbFilesSources);
            this.tabPage1.Controls.Add(this.btnChooseFiles);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Importar Datos y Generar Excel";
            // 
            // btnSelecDestino
            // 
            this.btnSelecDestino.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSelecDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecDestino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSelecDestino.Location = new System.Drawing.Point(25, 146);
            this.btnSelecDestino.Name = "btnSelecDestino";
            this.btnSelecDestino.Size = new System.Drawing.Size(120, 59);
            this.btnSelecDestino.TabIndex = 6;
            this.btnSelecDestino.Text = "Seleccionar\r\nRuta Destino\r\n";
            this.btnSelecDestino.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(20, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(342, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Importar Datos y Generar Excel";
            // 
            // btnProcessFiles
            // 
            this.btnProcessFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessFiles.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnProcessFiles.FlatAppearance.BorderSize = 0;
            this.btnProcessFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProcessFiles.Location = new System.Drawing.Point(132, 241);
            this.btnProcessFiles.Name = "btnProcessFiles";
            this.btnProcessFiles.Size = new System.Drawing.Size(532, 34);
            this.btnProcessFiles.TabIndex = 4;
            this.btnProcessFiles.Text = "Procesar";
            this.btnProcessFiles.UseVisualStyleBackColor = false;
            // 
            // txtPathFileDestiny
            // 
            this.txtPathFileDestiny.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathFileDestiny.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathFileDestiny.Location = new System.Drawing.Point(215, 165);
            this.txtPathFileDestiny.Name = "txtPathFileDestiny";
            this.txtPathFileDestiny.ReadOnly = true;
            this.txtPathFileDestiny.Size = new System.Drawing.Size(419, 24);
            this.txtPathFileDestiny.TabIndex = 3;
            // 
            // lbFilesSources
            // 
            this.lbFilesSources.AutoSize = true;
            this.lbFilesSources.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilesSources.ForeColor = System.Drawing.Color.Black;
            this.lbFilesSources.Location = new System.Drawing.Point(211, 83);
            this.lbFilesSources.Name = "lbFilesSources";
            this.lbFilesSources.Size = new System.Drawing.Size(21, 20);
            this.lbFilesSources.TabIndex = 1;
            this.lbFilesSources.Text = "...";
            // 
            // btnChooseFiles
            // 
            this.btnChooseFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(84)))), ((int)(((byte)(18)))));
            this.btnChooseFiles.FlatAppearance.BorderSize = 0;
            this.btnChooseFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnChooseFiles.Location = new System.Drawing.Point(25, 79);
            this.btnChooseFiles.Name = "btnChooseFiles";
            this.btnChooseFiles.Size = new System.Drawing.Size(120, 30);
            this.btnChooseFiles.TabIndex = 0;
            this.btnChooseFiles.Text = "Escoger";
            this.btnChooseFiles.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 471);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 53);
            this.panel2.TabIndex = 2;
            // 
            // CartaPorteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 524);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControlCartaPorte);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CartaPorteView";
            this.Text = "CartaPorteView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControlCartaPorte.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlCartaPorte;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnProcessFiles;
        private System.Windows.Forms.TextBox txtPathFileDestiny;
        private System.Windows.Forms.Label lbFilesSources;
        private System.Windows.Forms.Button btnChooseFiles;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSelecDestino;
    }
}