namespace LocadoraDeVeiculos.ModuloAutomovel
{
    partial class TelaAutomovelForm
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
            openFileDialog1 = new OpenFileDialog();
            txtFoto = new PictureBox();
            label1 = new Label();
            btnBuscar = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txModelo = new TextBox();
            txMarca = new TextBox();
            txCor = new TextBox();
            cbCombustivel = new ComboBox();
            cbGrupo = new ComboBox();
            btnCadastrar = new Button();
            button2 = new Button();
            label8 = new Label();
            txKilometragem = new TextBox();
            label9 = new Label();
            txPlaca = new TextBox();
            txCapacidade = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)txtFoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txCapacidade).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtFoto
            // 
            txtFoto.Location = new Point(131, 41);
            txtFoto.Name = "txtFoto";
            txtFoto.Size = new Size(125, 93);
            txtFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            txtFoto.TabIndex = 0;
            txtFoto.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 75);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 1;
            label1.Text = "Foto:";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(262, 111);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 485);
            label2.Name = "label2";
            label2.Size = new Size(121, 15);
            label2.TabIndex = 3;
            label2.Text = "Capacidade em Litros";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 300);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 4;
            label3.Text = "Modelo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(80, 344);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 5;
            label4.Text = "Marca";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(88, 389);
            label5.Name = "label5";
            label5.Size = new Size(26, 15);
            label5.TabIndex = 6;
            label5.Text = "Cor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 438);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 7;
            label6.Text = "Tipo Combustivel";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 167);
            label7.Name = "label7";
            label7.Size = new Size(107, 15);
            label7.TabIndex = 8;
            label7.Text = "Grupo Automóveis";
            // 
            // txModelo
            // 
            txModelo.Location = new Point(131, 297);
            txModelo.Name = "txModelo";
            txModelo.Size = new Size(187, 23);
            txModelo.TabIndex = 10;
            // 
            // txMarca
            // 
            txMarca.Location = new Point(131, 341);
            txMarca.Name = "txMarca";
            txMarca.Size = new Size(187, 23);
            txMarca.TabIndex = 11;
            // 
            // txCor
            // 
            txCor.Location = new Point(131, 386);
            txCor.Name = "txCor";
            txCor.Size = new Size(187, 23);
            txCor.TabIndex = 12;
            // 
            // cbCombustivel
            // 
            cbCombustivel.FormattingEnabled = true;
            cbCombustivel.Location = new Point(131, 430);
            cbCombustivel.Name = "cbCombustivel";
            cbCombustivel.Size = new Size(187, 23);
            cbCombustivel.TabIndex = 14;
            // 
            // cbGrupo
            // 
            cbGrupo.FormattingEnabled = true;
            cbGrupo.Location = new Point(131, 167);
            cbGrupo.Name = "cbGrupo";
            cbGrupo.Size = new Size(187, 23);
            cbGrupo.TabIndex = 15;
            // 
            // btnCadastrar
            // 
            btnCadastrar.DialogResult = DialogResult.OK;
            btnCadastrar.Location = new Point(300, 507);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(88, 38);
            btnCadastrar.TabIndex = 16;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += brnCadastrar_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(402, 507);
            button2.Name = "button2";
            button2.Size = new Size(88, 36);
            button2.TabIndex = 17;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(38, 214);
            label8.Name = "label8";
            label8.Size = new Size(82, 15);
            label8.TabIndex = 18;
            label8.Text = "Kilometragem";
            // 
            // txKilometragem
            // 
            txKilometragem.Location = new Point(131, 214);
            txKilometragem.Name = "txKilometragem";
            txKilometragem.Size = new Size(187, 23);
            txKilometragem.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(76, 258);
            label9.Name = "label9";
            label9.Size = new Size(35, 15);
            label9.TabIndex = 20;
            label9.Text = "Placa";
            // 
            // txPlaca
            // 
            txPlaca.Location = new Point(131, 255);
            txPlaca.Name = "txPlaca";
            txPlaca.Size = new Size(187, 23);
            txPlaca.TabIndex = 21;
            // 
            // txCapacidade
            // 
            txCapacidade.Location = new Point(131, 483);
            txCapacidade.Name = "txCapacidade";
            txCapacidade.Size = new Size(125, 23);
            txCapacidade.TabIndex = 22;
            // 
            // TelaAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 552);
            Controls.Add(txCapacidade);
            Controls.Add(txPlaca);
            Controls.Add(label9);
            Controls.Add(txKilometragem);
            Controls.Add(label8);
            Controls.Add(button2);
            Controls.Add(btnCadastrar);
            Controls.Add(cbGrupo);
            Controls.Add(cbCombustivel);
            Controls.Add(txCor);
            Controls.Add(txMarca);
            Controls.Add(txModelo);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnBuscar);
            Controls.Add(label1);
            Controls.Add(txtFoto);
            Name = "TelaAutomovelForm";
            Text = "TelaAutomovelForm";
            ((System.ComponentModel.ISupportInitialize)txtFoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)txCapacidade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private PictureBox txtFoto;
        private Label label1;
        private Button btnBuscar;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txModelo;
        private TextBox txMarca;
        private TextBox txCor;
        private ComboBox cbCombustivel;
        private ComboBox cbGrupo;
        private Button btnCadastrar;
        private Button button2;
        private Label label8;
        private TextBox txKilometragem;
        private Label label9;
        private TextBox txPlaca;
        private NumericUpDown txCapacidade;
    }
}