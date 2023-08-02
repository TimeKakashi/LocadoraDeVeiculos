namespace LocadoraDeVeiculos.ModuloGrupoAutomovel
{
    partial class TelaGrupoAutomovelForm
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
            txNome = new TextBox();
            label1 = new Label();
            btnCadastarr = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // txNome
            // 
            txNome.Location = new Point(107, 48);
            txNome.Name = "txNome";
            txNome.Size = new Size(251, 23);
            txNome.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 51);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome";
            // 
            // btnCadastarr
            // 
            btnCadastarr.DialogResult = DialogResult.OK;
            btnCadastarr.Location = new Point(246, 134);
            btnCadastarr.Name = "btnCadastarr";
            btnCadastarr.Size = new Size(88, 36);
            btnCadastarr.TabIndex = 2;
            btnCadastarr.Text = "Cadastrar";
            btnCadastarr.UseVisualStyleBackColor = true;
            btnCadastarr.Click += btnCadastarr_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(341, 134);
            button2.Name = "button2";
            button2.Size = new Size(88, 36);
            button2.TabIndex = 3;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // TelaGrupoAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 182);
            Controls.Add(button2);
            Controls.Add(btnCadastarr);
            Controls.Add(label1);
            Controls.Add(txNome);
            Name = "TelaGrupoAutomovelForm";
            Text = "TelaGrupoAutomovel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txNome;
        private Label label1;
        private Button btnCadastarr;
        private Button button2;
    }
}