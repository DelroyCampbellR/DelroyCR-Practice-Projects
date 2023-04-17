namespace LibrosWindowsForms
{
    partial class FormEditar
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
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.tbUbicacion = new System.Windows.Forms.TextBox();
            this.lbUbicacion = new System.Windows.Forms.Label();
            this.tbPaginas = new System.Windows.Forms.TextBox();
            this.lbPaginas = new System.Windows.Forms.Label();
            this.tbTitulo = new System.Windows.Forms.TextBox();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.tbAutor = new System.Windows.Forms.TextBox();
            this.lbAutor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(315, 172);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(100, 28);
            this.btCancelar.TabIndex = 19;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // btAceptar
            // 
            this.btAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAceptar.Location = new System.Drawing.Point(197, 173);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(100, 28);
            this.btAceptar.TabIndex = 18;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // tbUbicacion
            // 
            this.tbUbicacion.Location = new System.Drawing.Point(125, 140);
            this.tbUbicacion.Margin = new System.Windows.Forms.Padding(4);
            this.tbUbicacion.Name = "tbUbicacion";
            this.tbUbicacion.Size = new System.Drawing.Size(289, 22);
            this.tbUbicacion.TabIndex = 17;
            // 
            // lbUbicacion
            // 
            this.lbUbicacion.AutoSize = true;
            this.lbUbicacion.Location = new System.Drawing.Point(55, 140);
            this.lbUbicacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUbicacion.Name = "lbUbicacion";
            this.lbUbicacion.Size = new System.Drawing.Size(70, 17);
            this.lbUbicacion.TabIndex = 16;
            this.lbUbicacion.Text = "Ubicacion";
            // 
            // tbPaginas
            // 
            this.tbPaginas.Location = new System.Drawing.Point(125, 108);
            this.tbPaginas.Margin = new System.Windows.Forms.Padding(4);
            this.tbPaginas.Name = "tbPaginas";
            this.tbPaginas.Size = new System.Drawing.Size(289, 22);
            this.tbPaginas.TabIndex = 15;
            // 
            // lbPaginas
            // 
            this.lbPaginas.AutoSize = true;
            this.lbPaginas.Location = new System.Drawing.Point(55, 108);
            this.lbPaginas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPaginas.Name = "lbPaginas";
            this.lbPaginas.Size = new System.Drawing.Size(59, 17);
            this.lbPaginas.TabIndex = 14;
            this.lbPaginas.Text = "Páginas";
            // 
            // tbTitulo
            // 
            this.tbTitulo.Location = new System.Drawing.Point(125, 76);
            this.tbTitulo.Margin = new System.Windows.Forms.Padding(4);
            this.tbTitulo.Name = "tbTitulo";
            this.tbTitulo.Size = new System.Drawing.Size(289, 22);
            this.tbTitulo.TabIndex = 13;
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Location = new System.Drawing.Point(55, 76);
            this.lbTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(43, 17);
            this.lbTitulo.TabIndex = 12;
            this.lbTitulo.Text = "Titulo";
            // 
            // tbAutor
            // 
            this.tbAutor.Location = new System.Drawing.Point(125, 44);
            this.tbAutor.Margin = new System.Windows.Forms.Padding(4);
            this.tbAutor.Name = "tbAutor";
            this.tbAutor.Size = new System.Drawing.Size(289, 22);
            this.tbAutor.TabIndex = 11;
            // 
            // lbAutor
            // 
            this.lbAutor.AutoSize = true;
            this.lbAutor.Location = new System.Drawing.Point(55, 44);
            this.lbAutor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAutor.Name = "lbAutor";
            this.lbAutor.Size = new System.Drawing.Size(42, 17);
            this.lbAutor.TabIndex = 10;
            this.lbAutor.Text = "Autor";
            // 
            // FormEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 246);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.tbUbicacion);
            this.Controls.Add(this.lbUbicacion);
            this.Controls.Add(this.tbPaginas);
            this.Controls.Add(this.lbPaginas);
            this.Controls.Add(this.tbTitulo);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.tbAutor);
            this.Controls.Add(this.lbAutor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormEditar";
            this.Text = "Editar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.TextBox tbUbicacion;
        private System.Windows.Forms.Label lbUbicacion;
        private System.Windows.Forms.TextBox tbPaginas;
        private System.Windows.Forms.Label lbPaginas;
        private System.Windows.Forms.TextBox tbTitulo;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.TextBox tbAutor;
        private System.Windows.Forms.Label lbAutor;
    }
}