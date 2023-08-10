namespace LocadoraDeVeiculos.ModuloFuncionario
{
    partial class telaFuncionarioForm
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
            txNome = new TextBox();
            txData = new DateTimePicker();
            txSalario = new TextBox();
            button1 = new Button();
            btnCadastrar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 51);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 108);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = "Admissão";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 159);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Salário";
            // 
            // txNome
            // 
            txNome.Location = new Point(101, 48);
            txNome.Name = "txNome";
            txNome.Size = new Size(268, 23);
            txNome.TabIndex = 3;
            // 
            // txData
            // 
            txData.Format = DateTimePickerFormat.Short;
            txData.Location = new Point(101, 102);
            txData.Name = "txData";
            txData.Size = new Size(113, 23);
            txData.TabIndex = 4;
            // 
            // txSalario
            // 
            txSalario.Location = new Point(101, 156);
            txSalario.Name = "txSalario";
            txSalario.Size = new Size(113, 23);
            txSalario.TabIndex = 5;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.Cancel;
            button1.Location = new Point(344, 198);
            button1.Name = "button1";
            button1.Size = new Size(82, 41);
            button1.TabIndex = 6;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnCadastrar
            // 
            btnCadastrar.DialogResult = DialogResult.OK;
            btnCadastrar.Location = new Point(256, 198);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(82, 41);
            btnCadastrar.TabIndex = 7;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // telaFuncionarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 251);
            Controls.Add(btnCadastrar);
            Controls.Add(button1);
            Controls.Add(txSalario);
            Controls.Add(txData);
            Controls.Add(txNome);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "telaFuncionarioForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Funcionário";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txNome;
        private DateTimePicker txData;
        private TextBox txSalario;
        private Button button1;
        private Button btnCadastrar;
    }
}