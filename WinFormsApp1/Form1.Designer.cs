namespace WinFormsApp1
{
    partial class Form1
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
            nudAlto = new NumericUpDown();
            nudAncho = new NumericUpDown();
            nudLargo = new NumericUpDown();
            btnCalcularArea = new Button();
            btnCalcularPerimetro = new Button();
            lblResultado = new Label();
            lblAlto = new Label();
            lblAncho = new Label();
            lblLargo = new Label();
            ((System.ComponentModel.ISupportInitialize)nudAlto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAncho).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudLargo).BeginInit();
            SuspendLayout();
            // 
            // nudAlto
            // 
            nudAlto.DecimalPlaces = 2;
            nudAlto.Location = new Point(140, 24);
            nudAlto.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudAlto.Name = "nudAlto";
            nudAlto.Size = new Size(140, 27);
            nudAlto.TabIndex = 0;
            // 
            // nudAncho
            // 
            nudAncho.DecimalPlaces = 2;
            nudAncho.Location = new Point(140, 64);
            nudAncho.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudAncho.Name = "nudAncho";
            nudAncho.Size = new Size(140, 27);
            nudAncho.TabIndex = 1;
            // 
            // nudLargo
            // 
            nudLargo.DecimalPlaces = 2;
            nudLargo.Location = new Point(140, 104);
            nudLargo.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudLargo.Name = "nudLargo";
            nudLargo.Size = new Size(140, 27);
            nudLargo.TabIndex = 2;
            // 
            // btnCalcularArea
            // 
            btnCalcularArea.Location = new Point(28, 152);
            btnCalcularArea.Name = "btnCalcularArea";
            btnCalcularArea.Size = new Size(120, 29);
            btnCalcularArea.TabIndex = 3;
            btnCalcularArea.Text = "Calcular Área";
            btnCalcularArea.UseVisualStyleBackColor = true;
            btnCalcularArea.Click += btnCalcularArea_Click;
            // 
            // btnCalcularPerimetro
            // 
            btnCalcularPerimetro.Location = new Point(160, 152);
            btnCalcularPerimetro.Name = "btnCalcularPerimetro";
            btnCalcularPerimetro.Size = new Size(144, 29);
            btnCalcularPerimetro.TabIndex = 4;
            btnCalcularPerimetro.Text = "Calcular Perímetro";
            btnCalcularPerimetro.UseVisualStyleBackColor = true;
            btnCalcularPerimetro.Click += btnCalcularPerimetro_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(28, 206);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(173, 20);
            lblResultado.TabIndex = 5;
            lblResultado.Text = "Resultado: sin calcular";
            // 
            // lblAlto
            // 
            lblAlto.AutoSize = true;
            lblAlto.Location = new Point(28, 26);
            lblAlto.Name = "lblAlto";
            lblAlto.Size = new Size(38, 20);
            lblAlto.TabIndex = 6;
            lblAlto.Text = "Alto";
            // 
            // lblAncho
            // 
            lblAncho.AutoSize = true;
            lblAncho.Location = new Point(28, 66);
            lblAncho.Name = "lblAncho";
            lblAncho.Size = new Size(52, 20);
            lblAncho.TabIndex = 7;
            lblAncho.Text = "Ancho";
            // 
            // lblLargo
            // 
            lblLargo.AutoSize = true;
            lblLargo.Location = new Point(28, 106);
            lblLargo.Name = "lblLargo";
            lblLargo.Size = new Size(48, 20);
            lblLargo.TabIndex = 8;
            lblLargo.Text = "Largo";
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 260);
            Controls.Add(lblLargo);
            Controls.Add(lblAncho);
            Controls.Add(lblAlto);
            Controls.Add(lblResultado);
            Controls.Add(btnCalcularPerimetro);
            Controls.Add(btnCalcularArea);
            Controls.Add(nudLargo);
            Controls.Add(nudAncho);
            Controls.Add(nudAlto);
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudAlto).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAncho).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudLargo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown nudAlto;
        private NumericUpDown nudAncho;
        private NumericUpDown nudLargo;
        private Button btnCalcularArea;
        private Button btnCalcularPerimetro;
        private Label lblResultado;
        private Label lblAlto;
        private Label lblAncho;
        private Label lblLargo;
    }
}
