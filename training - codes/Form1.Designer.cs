namespace TreinoMineracaoDeEmocoes
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
            this.btn_positive = new System.Windows.Forms.Button();
            this.btn_negative = new System.Windows.Forms.Button();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.btn_treinar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.lbl_instrucao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_texto
            // 
            this.txt_texto.Location = new System.Drawing.Point(21, 96);
            this.txt_texto.Multiline = true;
            this.txt_texto.Name = "txt_texto";
            this.txt_texto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_texto.Size = new System.Drawing.Size(335, 294);
            this.txt_texto.TabIndex = 0;
            // 
            // btn_positive
            // 
            this.btn_positive.BackColor = System.Drawing.Color.GreenYellow;
            this.btn_positive.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_positive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Honeydew;
            this.btn_positive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_positive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_positive.Location = new System.Drawing.Point(375, 96);
            this.btn_positive.Name = "btn_positive";
            this.btn_positive.Size = new System.Drawing.Size(107, 57);
            this.btn_positive.TabIndex = 1;
            this.btn_positive.Text = "POSITIVO";
            this.btn_positive.UseVisualStyleBackColor = false;
            this.btn_positive.Click += new System.EventHandler(this.btn_positive_Click);
            // 
            // btn_negative
            // 
            this.btn_negative.BackColor = System.Drawing.Color.Red;
            this.btn_negative.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
            this.btn_negative.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_negative.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_negative.ForeColor = System.Drawing.Color.White;
            this.btn_negative.Location = new System.Drawing.Point(375, 183);
            this.btn_negative.Name = "btn_negative";
            this.btn_negative.Size = new System.Drawing.Size(107, 57);
            this.btn_negative.TabIndex = 1;
            this.btn_negative.Text = "NEGATIVO";
            this.btn_negative.UseVisualStyleBackColor = false;
            this.btn_negative.Click += new System.EventHandler(this.btn_negative_Click);
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lbl_titulo.Location = new System.Drawing.Point(61, 32);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(392, 25);
            this.lbl_titulo.TabIndex = 2;
            this.lbl_titulo.Text = "TREINO - MINERAÇÃO DE EMOÇÕES";
            // 
            // btn_treinar
            // 
            this.btn_treinar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_treinar.Enabled = false;
            this.btn_treinar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_treinar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_treinar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_treinar.ForeColor = System.Drawing.Color.White;
            this.btn_treinar.Location = new System.Drawing.Point(375, 298);
            this.btn_treinar.Name = "btn_treinar";
            this.btn_treinar.Size = new System.Drawing.Size(107, 46);
            this.btn_treinar.TabIndex = 3;
            this.btn_treinar.Text = "TREINAR";
            this.btn_treinar.UseVisualStyleBackColor = false;
            this.btn_treinar.Click += new System.EventHandler(this.btn_treinar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.DeepPink;
            this.btn_cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Thistle;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_cancelar.Location = new System.Drawing.Point(375, 354);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(107, 36);
            this.btn_cancelar.TabIndex = 3;
            this.btn_cancelar.Text = "CANCELAR";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // lbl_instrucao
            // 
            this.lbl_instrucao.AutoSize = true;
            this.lbl_instrucao.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_instrucao.ForeColor = System.Drawing.Color.White;
            this.lbl_instrucao.Location = new System.Drawing.Point(18, 78);
            this.lbl_instrucao.Name = "lbl_instrucao";
            this.lbl_instrucao.Size = new System.Drawing.Size(159, 15);
            this.lbl_instrucao.TabIndex = 4;
            this.lbl_instrucao.Text = "Escreva o seu texto aqui:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(498, 411);
            this.Controls.Add(this.lbl_instrucao);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_treinar);
            this.Controls.Add(this.lbl_titulo);
            this.Controls.Add(this.btn_negative);
            this.Controls.Add(this.btn_positive);
            this.Controls.Add(this.txt_texto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Training Data Minning";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_texto;
        private System.Windows.Forms.Button btn_positive;
        private System.Windows.Forms.Button btn_negative;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Button btn_treinar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Label lbl_instrucao;
    }
}

