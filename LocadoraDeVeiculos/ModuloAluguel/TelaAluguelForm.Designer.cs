namespace LocadoraDeVeiculos.ModuloAluguel
{
    partial class TelaAluguelForm
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
            label7 = new Label();
            label8 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            cbFuncionario = new ComboBox();
            cbCliente = new ComboBox();
            cbGrupoAutomoveis = new ComboBox();
            cbPlanoCobranca = new ComboBox();
            txDataLocacao = new DateTimePicker();
            txDataPrevista = new DateTimePicker();
            cbCondutor = new ComboBox();
            cbAutomovel = new ComboBox();
            txKmAutomovel = new TextBox();
            tabPage1 = new TabPage();
            ContainerTaxas = new CheckedListBox();
            TabControlTaxa = new TabControl();
            label5 = new Label();
            label6 = new Label();
            labelValorTotal = new Label();
            button1 = new Button();
            button2 = new Button();
            btnCupom = new Button();
            txCupom = new TextBox();
            tabPage1.SuspendLayout();
            TabControlTaxa.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 30);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 0;
            label1.Text = "Funcionário";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 77);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 1;
            label2.Text = "Cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 177);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 3;
            label3.Text = "Plano de Cobrança";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 124);
            label4.Name = "label4";
            label4.Size = new Size(123, 15);
            label4.TabIndex = 2;
            label4.Text = "Grupo de Automóveis";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(345, 224);
            label7.Name = "label7";
            label7.Size = new Size(47, 15);
            label7.TabIndex = 5;
            label7.Text = "Cupom";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(54, 227);
            label8.Name = "label8";
            label8.Size = new Size(78, 15);
            label8.TabIndex = 4;
            label8.Text = "Data Locação";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(332, 174);
            label13.Name = "label13";
            label13.Size = new Size(107, 15);
            label13.TabIndex = 11;
            label13.Text = "Devolução Prevista";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(332, 127);
            label14.Name = "label14";
            label14.Size = new Size(104, 15);
            label14.TabIndex = 10;
            label14.Text = "KM do Automóvel";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(370, 72);
            label15.Name = "label15";
            label15.Size = new Size(66, 15);
            label15.TabIndex = 9;
            label15.Text = "Automóvel";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(378, 27);
            label16.Name = "label16";
            label16.Size = new Size(58, 15);
            label16.TabIndex = 8;
            label16.Text = "Condutor";
            // 
            // cbFuncionario
            // 
            cbFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFuncionario.FormattingEnabled = true;
            cbFuncionario.Location = new Point(140, 27);
            cbFuncionario.Name = "cbFuncionario";
            cbFuncionario.Size = new Size(186, 23);
            cbFuncionario.TabIndex = 14;
            // 
            // cbCliente
            // 
            cbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCliente.FormattingEnabled = true;
            cbCliente.Location = new Point(140, 74);
            cbCliente.Name = "cbCliente";
            cbCliente.Size = new Size(186, 23);
            cbCliente.TabIndex = 15;
            cbCliente.SelectedValueChanged += cbCliente_SelectedValueChanged;
            // 
            // cbGrupoAutomoveis
            // 
            cbGrupoAutomoveis.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGrupoAutomoveis.FormattingEnabled = true;
            cbGrupoAutomoveis.Location = new Point(140, 119);
            cbGrupoAutomoveis.Name = "cbGrupoAutomoveis";
            cbGrupoAutomoveis.Size = new Size(186, 23);
            cbGrupoAutomoveis.TabIndex = 16;
            cbGrupoAutomoveis.SelectedValueChanged += cbGrupoAutomoveis_SelectedValueChanged;
            // 
            // cbPlanoCobranca
            // 
            cbPlanoCobranca.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPlanoCobranca.FormattingEnabled = true;
            cbPlanoCobranca.Location = new Point(140, 174);
            cbPlanoCobranca.Name = "cbPlanoCobranca";
            cbPlanoCobranca.Size = new Size(186, 23);
            cbPlanoCobranca.TabIndex = 17;
            // 
            // txDataLocacao
            // 
            txDataLocacao.Format = DateTimePickerFormat.Short;
            txDataLocacao.Location = new Point(140, 221);
            txDataLocacao.Name = "txDataLocacao";
            txDataLocacao.Size = new Size(186, 23);
            txDataLocacao.TabIndex = 19;
            // 
            // txDataPrevista
            // 
            txDataPrevista.Format = DateTimePickerFormat.Short;
            txDataPrevista.Location = new Point(442, 171);
            txDataPrevista.Name = "txDataPrevista";
            txDataPrevista.Size = new Size(186, 23);
            txDataPrevista.TabIndex = 21;
            // 
            // cbCondutor
            // 
            cbCondutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondutor.Enabled = false;
            cbCondutor.FormattingEnabled = true;
            cbCondutor.Location = new Point(442, 24);
            cbCondutor.Name = "cbCondutor";
            cbCondutor.Size = new Size(186, 23);
            cbCondutor.TabIndex = 23;
            // 
            // cbAutomovel
            // 
            cbAutomovel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAutomovel.Enabled = false;
            cbAutomovel.FormattingEnabled = true;
            cbAutomovel.Location = new Point(442, 69);
            cbAutomovel.Name = "cbAutomovel";
            cbAutomovel.Size = new Size(186, 23);
            cbAutomovel.TabIndex = 24;
            cbAutomovel.SelectedValueChanged += cbAutomovel_SelectedValueChanged;
            // 
            // txKmAutomovel
            // 
            txKmAutomovel.Enabled = false;
            txKmAutomovel.Location = new Point(442, 121);
            txKmAutomovel.Name = "txKmAutomovel";
            txKmAutomovel.Size = new Size(186, 23);
            txKmAutomovel.TabIndex = 25;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(ContainerTaxas);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(525, 201);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Taxas Selecionadas";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // ContainerTaxas
            // 
            ContainerTaxas.FormattingEnabled = true;
            ContainerTaxas.Location = new Point(6, 6);
            ContainerTaxas.Name = "ContainerTaxas";
            ContainerTaxas.Size = new Size(479, 184);
            ContainerTaxas.TabIndex = 0;
            // 
            // TabControlTaxa
            // 
            TabControlTaxa.Controls.Add(tabPage1);
            TabControlTaxa.Location = new Point(65, 268);
            TabControlTaxa.Name = "TabControlTaxa";
            TabControlTaxa.SelectedIndex = 0;
            TabControlTaxa.Size = new Size(533, 229);
            TabControlTaxa.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(37, 514);
            label5.Name = "label5";
            label5.Size = new Size(177, 25);
            label5.TabIndex = 28;
            label5.Text = "Valor Total Previsto:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(220, 514);
            label6.Name = "label6";
            label6.Size = new Size(0, 25);
            label6.TabIndex = 29;
            // 
            // labelValorTotal
            // 
            labelValorTotal.AutoSize = true;
            labelValorTotal.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelValorTotal.ForeColor = Color.Lime;
            labelValorTotal.Location = new Point(220, 514);
            labelValorTotal.Name = "labelValorTotal";
            labelValorTotal.Size = new Size(33, 25);
            labelValorTotal.TabIndex = 30;
            labelValorTotal.Text = "R$";
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(462, 509);
            button1.Name = "button1";
            button1.Size = new Size(80, 40);
            button1.TabIndex = 31;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(548, 509);
            button2.Name = "button2";
            button2.Size = new Size(80, 40);
            button2.TabIndex = 32;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnCupom
            // 
            btnCupom.Location = new Point(504, 216);
            btnCupom.Name = "btnCupom";
            btnCupom.Size = new Size(104, 30);
            btnCupom.TabIndex = 34;
            btnCupom.Text = "Aplicar Cupom";
            btnCupom.UseVisualStyleBackColor = true;
            btnCupom.Click += btnCupom_Click;
            // 
            // txCupom
            // 
            txCupom.Location = new Point(398, 219);
            txCupom.Name = "txCupom";
            txCupom.Size = new Size(100, 23);
            txCupom.TabIndex = 35;
            // 
            // TelaAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 560);
            Controls.Add(txCupom);
            Controls.Add(btnCupom);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(labelValorTotal);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(TabControlTaxa);
            Controls.Add(txKmAutomovel);
            Controls.Add(cbAutomovel);
            Controls.Add(cbCondutor);
            Controls.Add(txDataPrevista);
            Controls.Add(txDataLocacao);
            Controls.Add(cbPlanoCobranca);
            Controls.Add(cbGrupoAutomoveis);
            Controls.Add(cbCliente);
            Controls.Add(cbFuncionario);
            Controls.Add(label13);
            Controls.Add(label14);
            Controls.Add(label15);
            Controls.Add(label16);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "TelaAluguelForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Aluguel";
            tabPage1.ResumeLayout(false);
            TabControlTaxa.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label7;
        private Label label8;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private ComboBox cbFuncionario;
        private ComboBox cbCliente;
        private ComboBox cbGrupoAutomoveis;
        private ComboBox cbPlanoCobranca;
        private DateTimePicker txDataLocacao;
        private DateTimePicker txDataPrevista;
        private ComboBox cbCondutor;
        private ComboBox cbAutomovel;
        private TextBox txKmAutomovel;
        private TabPage tabPage1;
        private CheckedListBox ContainerTaxas;
        private TabControl TabControlTaxa;
        private Label label5;
        private Label label6;
        private Label labelValorTotal;
        private Button button1;
        private Button button2;
        private Button btnCupom;
        private TextBox txCupom;
    }
}