namespace LocadoraDeVeiculos.ModuloAluguel
{
    partial class TelaDevolucaoForm
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
            tabPage2 = new TabPage();
            ContainerTaxasAdicionais = new CheckedListBox();
            label5 = new Label();
            label6 = new Label();
            labelValorTotal = new Label();
            btnCadastrar = new Button();
            button2 = new Button();
            txDataDevolucao = new DateTimePicker();
            label9 = new Label();
            cbNivelTanque = new ComboBox();
            label10 = new Label();
            txKmPercorrido = new TextBox();
            label11 = new Label();
            txCupom = new TextBox();
            tabPage1.SuspendLayout();
            TabControlTaxa.SuspendLayout();
            tabPage2.SuspendLayout();
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
            label2.Location = new Point(66, 77);
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
            label7.Location = new Point(387, 224);
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
            cbFuncionario.Enabled = false;
            cbFuncionario.FormattingEnabled = true;
            cbFuncionario.Location = new Point(140, 27);
            cbFuncionario.Name = "cbFuncionario";
            cbFuncionario.Size = new Size(186, 23);
            cbFuncionario.TabIndex = 14;
            // 
            // cbCliente
            // 
            cbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCliente.Enabled = false;
            cbCliente.FormattingEnabled = true;
            cbCliente.Location = new Point(140, 74);
            cbCliente.Name = "cbCliente";
            cbCliente.Size = new Size(186, 23);
            cbCliente.TabIndex = 15;
            // 
            // cbGrupoAutomoveis
            // 
            cbGrupoAutomoveis.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGrupoAutomoveis.Enabled = false;
            cbGrupoAutomoveis.FormattingEnabled = true;
            cbGrupoAutomoveis.Location = new Point(140, 119);
            cbGrupoAutomoveis.Name = "cbGrupoAutomoveis";
            cbGrupoAutomoveis.Size = new Size(186, 23);
            cbGrupoAutomoveis.TabIndex = 16;
            // 
            // cbPlanoCobranca
            // 
            cbPlanoCobranca.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPlanoCobranca.Enabled = false;
            cbPlanoCobranca.FormattingEnabled = true;
            cbPlanoCobranca.Location = new Point(140, 174);
            cbPlanoCobranca.Name = "cbPlanoCobranca";
            cbPlanoCobranca.Size = new Size(186, 23);
            cbPlanoCobranca.TabIndex = 17;
            // 
            // txDataLocacao
            // 
            txDataLocacao.Enabled = false;
            txDataLocacao.Format = DateTimePickerFormat.Short;
            txDataLocacao.Location = new Point(140, 221);
            txDataLocacao.Name = "txDataLocacao";
            txDataLocacao.Size = new Size(186, 23);
            txDataLocacao.TabIndex = 19;
            // 
            // txDataPrevista
            // 
            txDataPrevista.Enabled = false;
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
            ContainerTaxas.Enabled = false;
            ContainerTaxas.FormattingEnabled = true;
            ContainerTaxas.Location = new Point(6, 6);
            ContainerTaxas.Name = "ContainerTaxas";
            ContainerTaxas.Size = new Size(479, 184);
            ContainerTaxas.TabIndex = 0;
            // 
            // TabControlTaxa
            // 
            TabControlTaxa.Controls.Add(tabPage1);
            TabControlTaxa.Controls.Add(tabPage2);
            TabControlTaxa.Location = new Point(62, 363);
            TabControlTaxa.Name = "TabControlTaxa";
            TabControlTaxa.SelectedIndex = 0;
            TabControlTaxa.Size = new Size(533, 229);
            TabControlTaxa.TabIndex = 27;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(ContainerTaxasAdicionais);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(525, 201);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Taxas Adicionais";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ContainerTaxasAdicionais
            // 
            ContainerTaxasAdicionais.FormattingEnabled = true;
            ContainerTaxasAdicionais.Location = new Point(3, 3);
            ContainerTaxasAdicionais.Name = "ContainerTaxasAdicionais";
            ContainerTaxasAdicionais.Size = new Size(494, 184);
            ContainerTaxasAdicionais.TabIndex = 0;
            ContainerTaxasAdicionais.SelectedValueChanged += ContainerTaxasAdicionais_SelectedValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(49, 612);
            label5.Name = "label5";
            label5.Size = new Size(177, 25);
            label5.TabIndex = 28;
            label5.Text = "Valor Total Previsto:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(232, 612);
            label6.Name = "label6";
            label6.Size = new Size(0, 25);
            label6.TabIndex = 29;
            // 
            // labelValorTotal
            // 
            labelValorTotal.AutoSize = true;
            labelValorTotal.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelValorTotal.ForeColor = Color.Lime;
            labelValorTotal.Location = new Point(232, 612);
            labelValorTotal.Name = "labelValorTotal";
            labelValorTotal.Size = new Size(33, 25);
            labelValorTotal.TabIndex = 30;
            labelValorTotal.Text = "R$";
            // 
            // btnCadastrar
            // 
            btnCadastrar.DialogResult = DialogResult.OK;
            btnCadastrar.Location = new Point(474, 607);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(80, 40);
            btnCadastrar.TabIndex = 31;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(560, 607);
            button2.Name = "button2";
            button2.Size = new Size(80, 40);
            button2.TabIndex = 32;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // txDataDevolucao
            // 
            txDataDevolucao.Format = DateTimePickerFormat.Short;
            txDataDevolucao.Location = new Point(140, 274);
            txDataDevolucao.Name = "txDataDevolucao";
            txDataDevolucao.Size = new Size(186, 23);
            txDataDevolucao.TabIndex = 35;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(42, 274);
            label9.Name = "label9";
            label9.Size = new Size(90, 15);
            label9.TabIndex = 34;
            label9.Text = "Data Devolução";
            // 
            // cbNivelTanque
            // 
            cbNivelTanque.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNivelTanque.FormattingEnabled = true;
            cbNivelTanque.Location = new Point(140, 323);
            cbNivelTanque.Name = "cbNivelTanque";
            cbNivelTanque.Size = new Size(186, 23);
            cbNivelTanque.TabIndex = 37;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(39, 326);
            label10.Name = "label10";
            label10.Size = new Size(93, 15);
            label10.TabIndex = 36;
            label10.Text = "Nivel Do Tanque";
            // 
            // txKmPercorrido
            // 
            txKmPercorrido.Location = new Point(442, 274);
            txKmPercorrido.Name = "txKmPercorrido";
            txKmPercorrido.Size = new Size(186, 23);
            txKmPercorrido.TabIndex = 39;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(356, 277);
            label11.Name = "label11";
            label11.Size = new Size(83, 15);
            label11.TabIndex = 38;
            label11.Text = "Km Percorrido";
            // 
            // txCupom
            // 
            txCupom.Enabled = false;
            txCupom.Location = new Point(442, 224);
            txCupom.Name = "txCupom";
            txCupom.Size = new Size(186, 23);
            txCupom.TabIndex = 40;
            // 
            // TelaDevolucaoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 659);
            Controls.Add(txCupom);
            Controls.Add(txKmPercorrido);
            Controls.Add(label11);
            Controls.Add(cbNivelTanque);
            Controls.Add(label10);
            Controls.Add(txDataDevolucao);
            Controls.Add(label9);
            Controls.Add(button2);
            Controls.Add(btnCadastrar);
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
            Name = "TelaDevolucaoForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Aluguel";
            tabPage1.ResumeLayout(false);
            TabControlTaxa.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
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
        private Button btnCadastrar;
        private Button button2;
        private ComboBox cbCupom;
        private DateTimePicker txDataDevolucao;
        private Label label9;
        private ComboBox cbNivelTanque;
        private Label label10;
        private TextBox txKmPercorrido;
        private Label label11;
        private TabPage tabPage2;
        private CheckedListBox ContainerTaxasAdicionais;
        private TextBox txCupom;
    }
}