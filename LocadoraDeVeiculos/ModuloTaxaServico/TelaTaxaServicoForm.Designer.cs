namespace LocadoraDeVeiculos.ModuloTaxaServico
{
    partial class TelaTaxaServicoForm
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
            button1 = new Button();
            button2 = new Button();
            PrecoFixo = new RadioButton();
            CobrancaDiaria = new RadioButton();
            txtNome = new TextBox();
            txPreco = new TextBox();
            gbRadioBTN = new Panel();
            Plano = new Label();
            label1 = new Label();
            label2 = new Label();
            gbRadioBTN.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(287, 196);
            button1.Name = "button1";
            button1.Size = new Size(86, 42);
            button1.TabIndex = 0;
            button1.Text = "Gravar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(379, 196);
            button2.Name = "button2";
            button2.Size = new Size(86, 42);
            button2.TabIndex = 1;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // PrecoFixo
            // 
            PrecoFixo.AutoSize = true;
            PrecoFixo.Location = new Point(3, 47);
            PrecoFixo.Name = "PrecoFixo";
            PrecoFixo.Size = new Size(80, 19);
            PrecoFixo.TabIndex = 2;
            PrecoFixo.TabStop = true;
            PrecoFixo.Text = "Preço Fixo";
            PrecoFixo.UseVisualStyleBackColor = true;
            // 
            // CobrancaDiaria
            // 
            CobrancaDiaria.AutoSize = true;
            CobrancaDiaria.Location = new Point(103, 47);
            CobrancaDiaria.Name = "CobrancaDiaria";
            CobrancaDiaria.Size = new Size(109, 19);
            CobrancaDiaria.TabIndex = 3;
            CobrancaDiaria.TabStop = true;
            CobrancaDiaria.Text = "Cobrança Diaria";
            CobrancaDiaria.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(80, 31);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(249, 23);
            txtNome.TabIndex = 4;
            // 
            // txPreco
            // 
            txPreco.Location = new Point(80, 70);
            txPreco.Name = "txPreco";
            txPreco.Size = new Size(83, 23);
            txPreco.TabIndex = 5;
            // 
            // gbRadioBTN
            // 
            gbRadioBTN.Controls.Add(Plano);
            gbRadioBTN.Controls.Add(PrecoFixo);
            gbRadioBTN.Controls.Add(CobrancaDiaria);
            gbRadioBTN.Location = new Point(80, 109);
            gbRadioBTN.Name = "gbRadioBTN";
            gbRadioBTN.Size = new Size(249, 69);
            gbRadioBTN.TabIndex = 6;
            // 
            // Plano
            // 
            Plano.AutoSize = true;
            Plano.Location = new Point(3, 0);
            Plano.Name = "Plano";
            Plano.Size = new Size(96, 15);
            Plano.TabIndex = 9;
            Plano.Text = "Plano de Calculo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 70);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 7;
            label1.Text = "Preço :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 31);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 8;
            label2.Text = "Nome :";
            // 
            // TelaTaxaServicoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 267);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(gbRadioBTN);
            Controls.Add(txPreco);
            Controls.Add(txtNome);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "TelaTaxaServicoForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Taxa e Serviço";
            gbRadioBTN.ResumeLayout(false);
            gbRadioBTN.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private RadioButton PrecoFixo;
        private RadioButton CobrancaDiaria;
        private TextBox txtNome;
        private TextBox txPreco;
        private Panel gbRadioBTN;
        private Label label1;
        private Label label2;
        private Label Plano;
    }
}