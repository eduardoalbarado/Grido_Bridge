﻿namespace GridoPuente
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bot_clientes = new System.Windows.Forms.Button();
            this.bot_productos = new System.Windows.Forms.Button();
            this.textBoxString = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 71);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(486, 211);
            this.textBox1.TabIndex = 1;
            // 
            // bot_clientes
            // 
            this.bot_clientes.Location = new System.Drawing.Point(103, 44);
            this.bot_clientes.Name = "bot_clientes";
            this.bot_clientes.Size = new System.Drawing.Size(120, 23);
            this.bot_clientes.TabIndex = 2;
            this.bot_clientes.Text = "ClientesProduccion";
            this.bot_clientes.UseVisualStyleBackColor = true;
            this.bot_clientes.Click += new System.EventHandler(this.bot_clientes_Click);
            // 
            // bot_productos
            // 
            this.bot_productos.Location = new System.Drawing.Point(242, 44);
            this.bot_productos.Name = "bot_productos";
            this.bot_productos.Size = new System.Drawing.Size(120, 23);
            this.bot_productos.TabIndex = 3;
            this.bot_productos.Text = "Productos Dev";
            this.bot_productos.UseVisualStyleBackColor = true;
            this.bot_productos.Click += new System.EventHandler(this.bot_productos_Click);
            // 
            // textBoxString
            // 
            this.textBoxString.Location = new System.Drawing.Point(12, 12);
            this.textBoxString.Name = "textBoxString";
            this.textBoxString.Size = new System.Drawing.Size(486, 20);
            this.textBoxString.TabIndex = 4;
            this.textBoxString.Text = "Server=.\\SQLEXPRESS;Database=GESTION;Trusted_Connection=True;MultipleActiveResult" +
    "Sets=true; Integrated Security=true";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 294);
            this.Controls.Add(this.textBoxString);
            this.Controls.Add(this.bot_productos);
            this.Controls.Add(this.bot_clientes);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Loader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bot_clientes;
        private System.Windows.Forms.Button bot_productos;
        private System.Windows.Forms.TextBox textBoxString;
    }
}

