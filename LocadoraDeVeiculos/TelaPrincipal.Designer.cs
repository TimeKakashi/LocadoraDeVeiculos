namespace LocadoraDeVeiculos
{
    partial class TelaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            exibirToolStripMenuItem = new ToolStripMenuItem();
            funcionáriosToolStripMenuItem = new ToolStripMenuItem();
            automóveisToolStripMenuItem = new ToolStripMenuItem();
            gruposDeAutomóveisToolStripMenuItem = new ToolStripMenuItem();
            planosDeCobrançaToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            condutoresToolStripMenuItem = new ToolStripMenuItem();
            aluguéisToolStripMenuItem = new ToolStripMenuItem();
            taxasEServiçosToolStripMenuItem = new ToolStripMenuItem();
            cuponsEParceirosToolStripMenuItem = new ToolStripMenuItem();
            preçosToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            panelRegistros = new Panel();
            statusStrip1 = new StatusStrip();
            toolStrip1 = new ToolStrip();
            btnInserir = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            btnFiltrar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { exibirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(716, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // exibirToolStripMenuItem
            // 
            exibirToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { funcionáriosToolStripMenuItem, automóveisToolStripMenuItem, clientesToolStripMenuItem, aluguéisToolStripMenuItem });
            exibirToolStripMenuItem.Name = "exibirToolStripMenuItem";
            exibirToolStripMenuItem.Size = new Size(48, 20);
            exibirToolStripMenuItem.Text = "Exibir";
            // 
            // funcionáriosToolStripMenuItem
            // 
            funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            funcionáriosToolStripMenuItem.Size = new Size(180, 22);
            funcionáriosToolStripMenuItem.Text = "Funcionários";
            funcionáriosToolStripMenuItem.Click += funcionáriosToolStripMenuItem_Click;
            // 
            // automóveisToolStripMenuItem
            // 
            automóveisToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gruposDeAutomóveisToolStripMenuItem });
            automóveisToolStripMenuItem.Name = "automóveisToolStripMenuItem";
            automóveisToolStripMenuItem.Size = new Size(180, 22);
            automóveisToolStripMenuItem.Text = "Automóveis";
            automóveisToolStripMenuItem.Click += automóveisToolStripMenuItem_Click;
            // 
            // gruposDeAutomóveisToolStripMenuItem
            // 
            gruposDeAutomóveisToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { planosDeCobrançaToolStripMenuItem });
            gruposDeAutomóveisToolStripMenuItem.Name = "gruposDeAutomóveisToolStripMenuItem";
            gruposDeAutomóveisToolStripMenuItem.Size = new Size(195, 22);
            gruposDeAutomóveisToolStripMenuItem.Text = "Grupos de Automóveis";
            gruposDeAutomóveisToolStripMenuItem.Click += gruposDeAutomóveisToolStripMenuItem_Click;
            // 
            // planosDeCobrançaToolStripMenuItem
            // 
            planosDeCobrançaToolStripMenuItem.Name = "planosDeCobrançaToolStripMenuItem";
            planosDeCobrançaToolStripMenuItem.Size = new Size(179, 22);
            planosDeCobrançaToolStripMenuItem.Text = "Planos de Cobrança";
            planosDeCobrançaToolStripMenuItem.Click += planosDeCobrançaToolStripMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { condutoresToolStripMenuItem });
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(180, 22);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // condutoresToolStripMenuItem
            // 
            condutoresToolStripMenuItem.Name = "condutoresToolStripMenuItem";
            condutoresToolStripMenuItem.Size = new Size(136, 22);
            condutoresToolStripMenuItem.Text = "Condutores";
            condutoresToolStripMenuItem.Click += condutoresToolStripMenuItem_Click;
            // 
            // aluguéisToolStripMenuItem
            // 
            aluguéisToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { taxasEServiçosToolStripMenuItem, cuponsEParceirosToolStripMenuItem, preçosToolStripMenuItem });
            aluguéisToolStripMenuItem.Name = "aluguéisToolStripMenuItem";
            aluguéisToolStripMenuItem.Size = new Size(180, 22);
            aluguéisToolStripMenuItem.Text = "Aluguéis";
            aluguéisToolStripMenuItem.Click += aluguéisToolStripMenuItem_Click;
            // 
            // taxasEServiçosToolStripMenuItem
            // 
            taxasEServiçosToolStripMenuItem.Name = "taxasEServiçosToolStripMenuItem";
            taxasEServiçosToolStripMenuItem.Size = new Size(180, 22);
            taxasEServiçosToolStripMenuItem.Text = "Taxas e Serviços";
            taxasEServiçosToolStripMenuItem.Click += taxasEServiçosToolStripMenuItem_Click;
            // 
            // cuponsEParceirosToolStripMenuItem
            // 
            cuponsEParceirosToolStripMenuItem.Name = "cuponsEParceirosToolStripMenuItem";
            cuponsEParceirosToolStripMenuItem.Size = new Size(180, 22);
            cuponsEParceirosToolStripMenuItem.Text = "Cupons e Parceiros";
            cuponsEParceirosToolStripMenuItem.Click += cuponsEParceirosToolStripMenuItem_Click;
            // 
            // preçosToolStripMenuItem
            // 
            preçosToolStripMenuItem.Name = "preçosToolStripMenuItem";
            preçosToolStripMenuItem.Size = new Size(180, 22);
            preçosToolStripMenuItem.Text = "Preços";
            preçosToolStripMenuItem.Click += preçosToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panelRegistros);
            panel1.Controls.Add(statusStrip1);
            panel1.Controls.Add(toolStrip1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(716, 344);
            panel1.TabIndex = 1;
            // 
            // panelRegistros
            // 
            panelRegistros.Dock = DockStyle.Fill;
            panelRegistros.Location = new Point(0, 31);
            panelRegistros.Name = "panelRegistros";
            panelRegistros.Size = new Size(716, 291);
            panelRegistros.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 322);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(716, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnInserir, btnEditar, btnExcluir, btnFiltrar, toolStripSeparator1, toolStripLabel1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(716, 31);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            btnInserir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnInserir.Image = Properties.Resources.add_circle_FILL0_wght400_GRAD0_opsz24__1_;
            btnInserir.ImageScaling = ToolStripItemImageScaling.None;
            btnInserir.ImageTransparentColor = Color.Magenta;
            btnInserir.Name = "btnInserir";
            btnInserir.Size = new Size(28, 28);
            btnInserir.Text = "toolStripButton1";
            btnInserir.Click += btnInserir_Click;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEditar.Image = Properties.Resources.edit_FILL0_wght400_GRAD0_opsz24;
            btnEditar.ImageScaling = ToolStripItemImageScaling.None;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(28, 28);
            btnEditar.Text = "toolStripButton2";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExcluir.Image = Properties.Resources.delete_FILL0_wght400_GRAD0_opsz24;
            btnExcluir.ImageScaling = ToolStripItemImageScaling.None;
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(28, 28);
            btnExcluir.Text = "toolStripButton3";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFiltrar.Image = Properties.Resources.filter_list_FILL0_wght400_GRAD0_opsz24;
            btnFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            btnFiltrar.ImageTransparentColor = Color.Magenta;
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(28, 28);
            btnFiltrar.Text = "toolStripButton4";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(118, 28);
            toolStripLabel1.Text = "Locadora de Veiculos";
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 368);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "TelaPrincipal";
            Text = "Locadora de Veiculos";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem exibirToolStripMenuItem;
        private ToolStripMenuItem funcionáriosToolStripMenuItem;
        private ToolStripMenuItem automóveisToolStripMenuItem;
        private ToolStripMenuItem gruposDeAutomóveisToolStripMenuItem;
        private ToolStripMenuItem planosDeCobrançaToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem condutoresToolStripMenuItem;
        private ToolStripMenuItem aluguéisToolStripMenuItem;
        private ToolStripMenuItem taxasEServiçosToolStripMenuItem;
        private ToolStripMenuItem cuponsEParceirosToolStripMenuItem;
        private ToolStripMenuItem preçosToolStripMenuItem;
        private Panel panel1;
        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private ToolStripButton btnInserir;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private ToolStripButton btnFiltrar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel1;
        private Panel panelRegistros;
    }
}