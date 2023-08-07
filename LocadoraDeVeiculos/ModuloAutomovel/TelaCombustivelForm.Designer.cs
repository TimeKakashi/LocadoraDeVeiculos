namespace LocadoraDeVeiculos.ModuloAutomovel
{
    partial class TelaCombustivelForm
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
            label9 = new Label();
            label4 = new Label();
            txGasolina = new TextBox();
            txAlcool = new TextBox();
            txGas = new TextBox();
            txDisel = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 29);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 0;
            label1.Text = "Gasolina";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 88);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 1;
            label2.Text = "Alcool";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(44, 147);
            label9.Name = "label9";
            label9.Size = new Size(26, 15);
            label9.TabIndex = 2;
            label9.Text = "Gás";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 201);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 3;
            label4.Text = "Disel";
            // 
            // txGasolina
            // 
            txGasolina.Location = new Point(76, 26);
            txGasolina.Name = "txGasolina";
            txGasolina.Size = new Size(183, 23);
            txGasolina.TabIndex = 4;
            // 
            // txAlcool
            // 
            txAlcool.Location = new Point(76, 85);
            txAlcool.Name = "txAlcool";
            txAlcool.Size = new Size(183, 23);
            txAlcool.TabIndex = 5;
            // 
            // txGas
            // 
            txGas.Location = new Point(76, 144);
            txGas.Name = "txGas";
            txGas.Size = new Size(183, 23);
            txGas.TabIndex = 6;
            // 
            // txDisel
            // 
            txDisel.Location = new Point(76, 198);
            txDisel.Name = "txDisel";
            txDisel.Size = new Size(183, 23);
            txDisel.TabIndex = 7;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(214, 249);
            button1.Name = "button1";
            button1.Size = new Size(75, 35);
            button1.TabIndex = 8;
            button1.Text = "Modificar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(295, 249);
            button2.Name = "button2";
            button2.Size = new Size(75, 35);
            button2.TabIndex = 9;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // TelaCombustivelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 291);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txDisel);
            Controls.Add(txGas);
            Controls.Add(txAlcool);
            Controls.Add(txGasolina);
            Controls.Add(label4);
            Controls.Add(label9);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaCombustivelForm";
            Text = "TelaCombustivelForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label9;
        private Label label4;
        private TextBox txGasolina;
        private TextBox txAlcool;
        private TextBox txGas;
        private TextBox txDisel;
        private Button button1;
        private Button button2;
    }
}