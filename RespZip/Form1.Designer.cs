namespace RespZip
{
    partial class form_respaldo
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_respaldo));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_respaldar = new System.Windows.Forms.ToolStripButton();
            this.tsb_configurar = new System.Windows.Forms.ToolStripButton();
            this.pan_respaldar = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pb_respaldar = new System.Windows.Forms.PictureBox();
            this.panel_check2 = new System.Windows.Forms.Panel();
            this.txb_nombre = new System.Windows.Forms.TextBox();
            this.pan_configurar = new System.Windows.Forms.Panel();
            this.pb_guardar_configuracion = new System.Windows.Forms.PictureBox();
            this.pb_actualizar_destino = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pb_actualizar_origen = new System.Windows.Forms.PictureBox();
            this.panel_check1 = new System.Windows.Forms.Panel();
            this.txb_destino = new System.Windows.Forms.TextBox();
            this.txb_origen = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.pan_respaldar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_respaldar)).BeginInit();
            this.pan_configurar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_guardar_configuracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_actualizar_destino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_actualizar_origen)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_respaldar,
            this.tsb_configurar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(373, 58);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_respaldar
            // 
            this.tsb_respaldar.AutoSize = false;
            this.tsb_respaldar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_respaldar.Image = global::RespZip.Properties.Resources.File_Zip_Rar_Archive_icon;
            this.tsb_respaldar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_respaldar.Name = "tsb_respaldar";
            this.tsb_respaldar.Size = new System.Drawing.Size(55, 55);
            this.tsb_respaldar.Text = "Respaldar";
            this.tsb_respaldar.ToolTipText = "Crear Respaldo";
            this.tsb_respaldar.Click += new System.EventHandler(this.tsb_respaldar_Click);
            // 
            // tsb_configurar
            // 
            this.tsb_configurar.AutoSize = false;
            this.tsb_configurar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_configurar.Image = global::RespZip.Properties.Resources.Settings_icon;
            this.tsb_configurar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_configurar.Name = "tsb_configurar";
            this.tsb_configurar.Size = new System.Drawing.Size(55, 55);
            this.tsb_configurar.Text = "Configurar Opciones";
            this.tsb_configurar.ToolTipText = "Opciones de Configuracion";
            this.tsb_configurar.Click += new System.EventHandler(this.tsb_configurar_Click);
            // 
            // pan_respaldar
            // 
            this.pan_respaldar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pan_respaldar.Controls.Add(this.label3);
            this.pan_respaldar.Controls.Add(this.button1);
            this.pan_respaldar.Controls.Add(this.progressBar1);
            this.pan_respaldar.Controls.Add(this.pb_respaldar);
            this.pan_respaldar.Controls.Add(this.panel_check2);
            this.pan_respaldar.Controls.Add(this.txb_nombre);
            this.pan_respaldar.Location = new System.Drawing.Point(12, 55);
            this.pan_respaldar.Name = "pan_respaldar";
            this.pan_respaldar.Size = new System.Drawing.Size(348, 426);
            this.pan_respaldar.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Prenombre de Archivo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(27, 390);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(226, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // pb_respaldar
            // 
            this.pb_respaldar.Image = global::RespZip.Properties.Resources.ZIP_icon;
            this.pb_respaldar.Location = new System.Drawing.Point(266, 314);
            this.pb_respaldar.Name = "pb_respaldar";
            this.pb_respaldar.Size = new System.Drawing.Size(67, 55);
            this.pb_respaldar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_respaldar.TabIndex = 3;
            this.pb_respaldar.TabStop = false;
            this.pb_respaldar.Click += new System.EventHandler(this.pb_respaldar_Click);
            // 
            // panel_check2
            // 
            this.panel_check2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel_check2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_check2.Location = new System.Drawing.Point(27, 108);
            this.panel_check2.Name = "panel_check2";
            this.panel_check2.Size = new System.Drawing.Size(226, 261);
            this.panel_check2.TabIndex = 1;
            // 
            // txb_nombre
            // 
            this.txb_nombre.Location = new System.Drawing.Point(134, 14);
            this.txb_nombre.Name = "txb_nombre";
            this.txb_nombre.Size = new System.Drawing.Size(199, 20);
            this.txb_nombre.TabIndex = 0;
            // 
            // pan_configurar
            // 
            this.pan_configurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pan_configurar.Controls.Add(this.pb_guardar_configuracion);
            this.pan_configurar.Controls.Add(this.pb_actualizar_destino);
            this.pan_configurar.Controls.Add(this.label2);
            this.pan_configurar.Controls.Add(this.label1);
            this.pan_configurar.Controls.Add(this.pb_actualizar_origen);
            this.pan_configurar.Controls.Add(this.panel_check1);
            this.pan_configurar.Controls.Add(this.txb_destino);
            this.pan_configurar.Controls.Add(this.txb_origen);
            this.pan_configurar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pan_configurar.Location = new System.Drawing.Point(12, 58);
            this.pan_configurar.Name = "pan_configurar";
            this.pan_configurar.Size = new System.Drawing.Size(351, 426);
            this.pan_configurar.TabIndex = 1;
            // 
            // pb_guardar_configuracion
            // 
            this.pb_guardar_configuracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_guardar_configuracion.Image = global::RespZip.Properties.Resources.Floppy_Small_icon;
            this.pb_guardar_configuracion.Location = new System.Drawing.Point(275, 338);
            this.pb_guardar_configuracion.Name = "pb_guardar_configuracion";
            this.pb_guardar_configuracion.Size = new System.Drawing.Size(61, 58);
            this.pb_guardar_configuracion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_guardar_configuracion.TabIndex = 9;
            this.pb_guardar_configuracion.TabStop = false;
            this.pb_guardar_configuracion.Click += new System.EventHandler(this.pb_guardar_configuracion_Click);
            // 
            // pb_actualizar_destino
            // 
            this.pb_actualizar_destino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_actualizar_destino.Image = global::RespZip.Properties.Resources.Folder_Open_icon_blue;
            this.pb_actualizar_destino.Location = new System.Drawing.Point(299, 78);
            this.pb_actualizar_destino.Name = "pb_actualizar_destino";
            this.pb_actualizar_destino.Size = new System.Drawing.Size(34, 37);
            this.pb_actualizar_destino.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_actualizar_destino.TabIndex = 8;
            this.pb_actualizar_destino.TabStop = false;
            this.pb_actualizar_destino.Click += new System.EventHandler(this.pb_actualizar_destino_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Seleccione la Ruta donde se guardara el Respaldo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Seleccione la Ruta de las carpetas a Respaldar";
            // 
            // pb_actualizar_origen
            // 
            this.pb_actualizar_origen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_actualizar_origen.Image = global::RespZip.Properties.Resources.Folder_Open_icon_;
            this.pb_actualizar_origen.Location = new System.Drawing.Point(298, 34);
            this.pb_actualizar_origen.Name = "pb_actualizar_origen";
            this.pb_actualizar_origen.Size = new System.Drawing.Size(35, 38);
            this.pb_actualizar_origen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_actualizar_origen.TabIndex = 5;
            this.pb_actualizar_origen.TabStop = false;
            this.pb_actualizar_origen.Click += new System.EventHandler(this.pb_actualizar_origen_Click);
            // 
            // panel_check1
            // 
            this.panel_check1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_check1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel_check1.Location = new System.Drawing.Point(21, 122);
            this.panel_check1.Name = "panel_check1";
            this.panel_check1.Size = new System.Drawing.Size(248, 274);
            this.panel_check1.TabIndex = 1;
            // 
            // txb_destino
            // 
            this.txb_destino.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txb_destino.Location = new System.Drawing.Point(21, 87);
            this.txb_destino.Name = "txb_destino";
            this.txb_destino.Size = new System.Drawing.Size(271, 20);
            this.txb_destino.TabIndex = 0;
            // 
            // txb_origen
            // 
            this.txb_origen.Location = new System.Drawing.Point(21, 40);
            this.txb_origen.Name = "txb_origen";
            this.txb_origen.Size = new System.Drawing.Size(271, 20);
            this.txb_origen.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // form_respaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 490);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pan_respaldar);
            this.Controls.Add(this.pan_configurar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_respaldo";
            this.Opacity = 0.95D;
            this.Text = "Formulario de Respaldo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.form_respaldo_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pan_respaldar.ResumeLayout(false);
            this.pan_respaldar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_respaldar)).EndInit();
            this.pan_configurar.ResumeLayout(false);
            this.pan_configurar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_guardar_configuracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_actualizar_destino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_actualizar_origen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_respaldar;
        private System.Windows.Forms.ToolStripButton tsb_configurar;
        private System.Windows.Forms.TextBox txb_nombre;
        private System.Windows.Forms.TextBox txb_destino;
        private System.Windows.Forms.TextBox txb_origen;
        private System.Windows.Forms.Panel panel_check1;
        private System.Windows.Forms.Panel panel_check2;
        private System.Windows.Forms.PictureBox pb_actualizar_origen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.PictureBox pb_guardar_configuracion;
        private System.Windows.Forms.PictureBox pb_actualizar_destino;
        private System.Windows.Forms.PictureBox pb_guardar_configuracion;
        private System.Windows.Forms.PictureBox pb_respaldar;
        public System.Windows.Forms.Panel pan_respaldar;
        public System.Windows.Forms.Panel pan_configurar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
    }
}

