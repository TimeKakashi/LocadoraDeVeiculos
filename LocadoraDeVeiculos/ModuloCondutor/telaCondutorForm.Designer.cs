namespace LocadoraDeVeiculos.ModuloCondutor
{
    partial class telaCondutorForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            cmbClientes = new ComboBox();
            txtCPF = new TextBox();
            txtNome = new TextBox();
            txtEmail = new TextBox();
            txtTelefone = new TextBox();
            txtCNH = new TextBox();
            dtpValidadeCNH = new DateTimePicker();
            button1 = new Button();
            button2 = new Button();
            chkClienteCondutor = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 42);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Cliente:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 166);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 322);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 2;
            label3.Text = "Validade:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 113);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 3;
            label4.Text = "Nome:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(226, 223);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 4;
            label5.Text = "CPF:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(37, 272);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 5;
            label6.Text = "CNH:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 223);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 6;
            label7.Text = "Telefone:";
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(79, 39);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(303, 23);
            cmbClientes.TabIndex = 8;
            cmbClientes.SelectedValueChanged += cmbClientes_SelectedValueChanged;
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(263, 220);
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(119, 23);
            txtCPF.TabIndex = 9;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(79, 110);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(303, 23);
            txtNome.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(79, 163);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(303, 23);
            txtEmail.TabIndex = 11;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(79, 220);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(141, 23);
            txtTelefone.TabIndex = 12;
            // 
            // txtCNH
            // 
            txtCNH.Location = new Point(79, 269);
            txtCNH.Name = "txtCNH";
            txtCNH.Size = new Size(141, 23);
            txtCNH.TabIndex = 13;
            // 
            // dtpValidadeCNH
            // 
            dtpValidadeCNH.CustomFormat = "DD/MM/YYYY";
            dtpValidadeCNH.Location = new Point(79, 316);
            dtpValidadeCNH.Name = "dtpValidadeCNH";
            dtpValidadeCNH.Size = new Size(141, 23);
            dtpValidadeCNH.TabIndex = 14;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(226, 350);
            button1.Name = "button1";
            button1.Size = new Size(75, 34);
            button1.TabIndex = 15;
            button1.Text = "Gravar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(307, 350);
            button2.Name = "button2";
            button2.Size = new Size(75, 34);
            button2.TabIndex = 16;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // chkClienteCondutor
            // 
            chkClienteCondutor.AutoSize = true;
            chkClienteCondutor.Location = new Point(94, 68);
            chkClienteCondutor.Name = "chkClienteCondutor";
            chkClienteCondutor.Size = new Size(126, 19);
            chkClienteCondutor.TabIndex = 17;
            chkClienteCondutor.Text = "Cliente é Condutor";
            chkClienteCondutor.UseVisualStyleBackColor = true;
            // 
            // telaCondutorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 396);
            Controls.Add(chkClienteCondutor);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dtpValidadeCNH);
            Controls.Add(txtCNH);
            Controls.Add(txtTelefone);
            Controls.Add(txtEmail);
            Controls.Add(txtNome);
            Controls.Add(txtCPF);
            Controls.Add(cmbClientes);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "telaCondutorForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Condutor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox cmbClientes;
        private TextBox txtCPF;
        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtTelefone;
        private TextBox txtCNH;
        private DateTimePicker dtpValidadeCNH;
        private Button button1;
        private Button button2;
        private CheckBox chkClienteCondutor;
    }
}