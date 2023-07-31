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
            clientesToolStripMenuItem = new ToolStripMenuItem();
            aluguéisToolStripMenuItem = new ToolStripMenuItem();
            gruposDeAutomóveisToolStripMenuItem = new ToolStripMenuItem();
            planosDeCobrançaToolStripMenuItem = new ToolStripMenuItem();
            condutoresToolStripMenuItem = new ToolStripMenuItem();
            taxasEServiçosToolStripMenuItem = new ToolStripMenuItem();
            cuponsEParceirosToolStripMenuItem = new ToolStripMenuItem();
            preçosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
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
            // 
            // automóveisToolStripMenuItem
            // 
            automóveisToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gruposDeAutomóveisToolStripMenuItem });
            automóveisToolStripMenuItem.Name = "automóveisToolStripMenuItem";
            automóveisToolStripMenuItem.Size = new Size(180, 22);
            automóveisToolStripMenuItem.Text = "Automóveis";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { condutoresToolStripMenuItem });
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(180, 22);
            clientesToolStripMenuItem.Text = "Clientes";
            // 
            // aluguéisToolStripMenuItem
            // 
            aluguéisToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { taxasEServiçosToolStripMenuItem, cuponsEParceirosToolStripMenuItem, preçosToolStripMenuItem });
            aluguéisToolStripMenuItem.Name = "aluguéisToolStripMenuItem";
            aluguéisToolStripMenuItem.Size = new Size(180, 22);
            aluguéisToolStripMenuItem.Text = "Aluguéis";
            // 
            // gruposDeAutomóveisToolStripMenuItem
            // 
            gruposDeAutomóveisToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { planosDeCobrançaToolStripMenuItem });
            gruposDeAutomóveisToolStripMenuItem.Name = "gruposDeAutomóveisToolStripMenuItem";
            gruposDeAutomóveisToolStripMenuItem.Size = new Size(195, 22);
            gruposDeAutomóveisToolStripMenuItem.Text = "Grupos de Automóveis";
            // 
            // planosDeCobrançaToolStripMenuItem
            // 
            planosDeCobrançaToolStripMenuItem.Name = "planosDeCobrançaToolStripMenuItem";
            planosDeCobrançaToolStripMenuItem.Size = new Size(180, 22);
            planosDeCobrançaToolStripMenuItem.Text = "Planos de Cobrança";
            // 
            // condutoresToolStripMenuItem
            // 
            condutoresToolStripMenuItem.Name = "condutoresToolStripMenuItem";
            condutoresToolStripMenuItem.Size = new Size(180, 22);
            condutoresToolStripMenuItem.Text = "Condutores";
            // 
            // taxasEServiçosToolStripMenuItem
            // 
            taxasEServiçosToolStripMenuItem.Name = "taxasEServiçosToolStripMenuItem";
            taxasEServiçosToolStripMenuItem.Size = new Size(180, 22);
            taxasEServiçosToolStripMenuItem.Text = "Taxas e Serviços";
            // 
            // cuponsEParceirosToolStripMenuItem
            // 
            cuponsEParceirosToolStripMenuItem.Name = "cuponsEParceirosToolStripMenuItem";
            cuponsEParceirosToolStripMenuItem.Size = new Size(180, 22);
            cuponsEParceirosToolStripMenuItem.Text = "Cupons e Parceiros";
            // 
            // preçosToolStripMenuItem
            // 
            preçosToolStripMenuItem.Name = "preçosToolStripMenuItem";
            preçosToolStripMenuItem.Size = new Size(180, 22);
            preçosToolStripMenuItem.Text = "Preços";
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 368);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "TelaPrincipal";
            Text = "Locadora de Veiculos";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
    }
}