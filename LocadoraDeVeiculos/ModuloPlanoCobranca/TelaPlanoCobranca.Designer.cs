namespace LocadoraDeVeiculos.ModuloPlanoCobranca
{
    partial class TelaPlanoCobranca
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
            panel = new Panel();
            txKmDisponiveis = new TextBox();
            label5 = new Label();
            label3 = new Label();
            txPrecoKm = new TextBox();
            label4 = new Label();
            label2 = new Label();
            txPrecoDiaria = new TextBox();
            cbTipoPlano = new ComboBox();
            cbGrupo = new ComboBox();
            btnCadastrar = new Button();
            button2 = new Button();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 44);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 0;
            label1.Text = "Grupo de Automovel";
            // 
            // panel
            // 
            panel.Controls.Add(txKmDisponiveis);
            panel.Controls.Add(label5);
            panel.Controls.Add(label3);
            panel.Controls.Add(txPrecoKm);
            panel.Controls.Add(label4);
            panel.Controls.Add(label2);
            panel.Controls.Add(txPrecoDiaria);
            panel.Controls.Add(cbTipoPlano);
            panel.Location = new Point(31, 104);
            panel.Name = "panel";
            panel.Size = new Size(358, 207);
            panel.TabIndex = 1;
            // 
            // txKmDisponiveis
            // 
            txKmDisponiveis.AccessibleRole = AccessibleRole.None;
            txKmDisponiveis.Location = new Point(106, 164);
            txKmDisponiveis.Name = "txKmDisponiveis";
            txKmDisponiveis.Size = new Size(195, 23);
            txKmDisponiveis.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 167);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 4;
            label5.Text = "Km Disponíveis";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 81);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 4;
            label3.Text = "Preço Diária";
            // 
            // txPrecoKm
            // 
            txPrecoKm.AccessibleName = "txPrecoKm";
            txPrecoKm.Location = new Point(106, 121);
            txPrecoKm.Name = "txPrecoKm";
            txPrecoKm.Size = new Size(195, 23);
            txPrecoKm.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 124);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 3;
            label4.Text = "Preço Por Km";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 34);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 3;
            label2.Text = "Tipo Do Plano";
            // 
            // txPrecoDiaria
            // 
            txPrecoDiaria.Location = new Point(106, 73);
            txPrecoDiaria.Name = "txPrecoDiaria";
            txPrecoDiaria.Size = new Size(195, 23);
            txPrecoDiaria.TabIndex = 3;
            // 
            // cbTipoPlano
            // 
            cbTipoPlano.FormattingEnabled = true;
            cbTipoPlano.Location = new Point(106, 31);
            cbTipoPlano.Name = "cbTipoPlano";
            cbTipoPlano.Size = new Size(195, 23);
            cbTipoPlano.TabIndex = 3;
            // 
            // cbGrupo
            // 
            cbGrupo.FormattingEnabled = true;
            cbGrupo.Location = new Point(155, 41);
            cbGrupo.Name = "cbGrupo";
            cbGrupo.Size = new Size(234, 23);
            cbGrupo.TabIndex = 2;
            // 
            // btnCadastrar
            // 
            btnCadastrar.DialogResult = DialogResult.OK;
            btnCadastrar.Location = new Point(268, 317);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(75, 38);
            btnCadastrar.TabIndex = 3;
            btnCadastrar.Text = "button1";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(349, 317);
            button2.Name = "button2";
            button2.Size = new Size(75, 38);
            button2.TabIndex = 4;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // TelaPlanoCobranca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 367);
            Controls.Add(button2);
            Controls.Add(btnCadastrar);
            Controls.Add(cbGrupo);
            Controls.Add(panel);
            Controls.Add(label1);
            Name = "TelaPlanoCobranca";
            Text = "TelaPlanoCobranca";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private ComboBox cbGrupo;
        private Panel panel;
        private TextBox txKmDisponiveis;
        private Label label5;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private Label label2;
        private TextBox txPrecoDiaria;
        private ComboBox cbTipoPlano;
        private Button btnCadastrar;
        private Button button2;
        private TextBox txPrecoKm;
    }
}