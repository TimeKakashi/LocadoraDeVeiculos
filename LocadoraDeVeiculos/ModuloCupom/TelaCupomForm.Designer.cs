namespace LocadoraDeVeiculos.ModuloCupom
{
    partial class TelaCupomForm
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
            label2 = new Label();
            txtNome = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtDataDeValidade = new DateTimePicker();
            comboBoxListaParceiro = new ComboBox();
            txtValor = new TextBox();
            btnGravar = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 22);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 9;
            label2.Text = "Nome :";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(118, 19);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(249, 23);
            txtNome.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 64);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 11;
            label1.Text = "Valor :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 108);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 12;
            label3.Text = "Data de Validade :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 156);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 13;
            label4.Text = "Parceiro :";
            // 
            // txtDataDeValidade
            // 
            txtDataDeValidade.Location = new Point(118, 102);
            txtDataDeValidade.Name = "txtDataDeValidade";
            txtDataDeValidade.Size = new Size(249, 23);
            txtDataDeValidade.TabIndex = 14;
            // 
            // comboBoxListaParceiro
            // 
            comboBoxListaParceiro.FormattingEnabled = true;
            comboBoxListaParceiro.Location = new Point(118, 153);
            comboBoxListaParceiro.Name = "comboBoxListaParceiro";
            comboBoxListaParceiro.Size = new Size(148, 23);
            comboBoxListaParceiro.TabIndex = 15;
            comboBoxListaParceiro.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(118, 61);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(88, 23);
            txtValor.TabIndex = 16;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(180, 227);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(86, 42);
            btnGravar.TabIndex = 17;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += button1_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(281, 227);
            button2.Name = "button2";
            button2.Size = new Size(86, 42);
            button2.TabIndex = 18;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // TelaCupomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 293);
            Controls.Add(button2);
            Controls.Add(btnGravar);
            Controls.Add(txtValor);
            Controls.Add(comboBoxListaParceiro);
            Controls.Add(txtDataDeValidade);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txtNome);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "TelaCupomForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Cupom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtNome;
        private Label label1;
        private Label label3;
        private Label label4;
        private DateTimePicker txtDataDeValidade;
        private ComboBox comboBoxListaParceiro;
        private TextBox txtValor;
        private Button btnGravar;
        private Button button2;
    }
}