namespace MineradorDeEmocoes
{
    partial class Form1
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
            this.txt_texto = new System.Windows.Forms.TextBox();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.lbl_instrucao = new System.Windows.Forms.Label();
            this.btn_detectar = new System.Windows.Forms.Button();
            this.txt_message = new System.Windows.Forms.TextBox();
            this.pic_carinha = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_carinha)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_texto
            // 
            this.txt_texto.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_texto.Location = new System.Drawing.Point(49, 123);
            this.txt_texto.Multiline = true;
            this.txt_texto.Name = "txt_texto";
            this.txt_texto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_texto.Size = new System.Drawing.Size(583, 135);
            this.txt_texto.TabIndex = 1;
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.Location = new System.Drawing.Point(208, 37);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(266, 24);
            this.lbl_titulo.TabIndex = 2;
            this.lbl_titulo.Text = "DETECTOR DE EMOÇÕES";
            // 
            // lbl_instrucao
            // 
            this.lbl_instrucao.AutoSize = true;
            this.lbl_instrucao.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_instrucao.Location = new System.Drawing.Point(45, 100);
            this.lbl_instrucao.Name = "lbl_instrucao";
            this.lbl_instrucao.Size = new System.Drawing.Size(162, 20);
            this.lbl_instrucao.TabIndex = 2;
            this.lbl_instrucao.Text = "Escreva o seu texto aqui:";
            // 
            // btn_detectar
            // 
            this.btn_detectar.Location = new System.Drawing.Point(493, 279);
            this.btn_detectar.Name = "btn_detectar";
            this.btn_detectar.Size = new System.Drawing.Size(139, 58);
            this.btn_detectar.TabIndex = 3;
            this.btn_detectar.Text = "DETECTAR";
            this.btn_detectar.UseVisualStyleBackColor = true;
            this.btn_detectar.Click += new System.EventHandler(this.Detectar_Click);
            // 
            // txt_message
            // 
            this.txt_message.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_message.Location = new System.Drawing.Point(214, 279);
            this.txt_message.Multiline = true;
            this.txt_message.Name = "txt_message";
            this.txt_message.ReadOnly = true;
            this.txt_message.Size = new System.Drawing.Size(260, 153);
            this.txt_message.TabIndex = 4;
            // 
            // pic_carinha
            // 
            this.pic_carinha.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pic_carinha.Location = new System.Drawing.Point(49, 279);
            this.pic_carinha.Name = "pic_carinha";
            this.pic_carinha.Size = new System.Drawing.Size(153, 153);
            this.pic_carinha.TabIndex = 0;
            this.pic_carinha.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 479);
            this.Controls.Add(this.txt_message);
            this.Controls.Add(this.btn_detectar);
            this.Controls.Add(this.lbl_instrucao);
            this.Controls.Add(this.lbl_titulo);
            this.Controls.Add(this.txt_texto);
            this.Controls.Add(this.pic_carinha);
            this.Name = "Form1";
            this.Text = "Detector de emoções";
            ((System.ComponentModel.ISupportInitialize)(this.pic_carinha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_carinha;
        private System.Windows.Forms.TextBox txt_texto;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Label lbl_instrucao;
        private System.Windows.Forms.Button btn_detectar;
        private System.Windows.Forms.TextBox txt_message;
    }
}

