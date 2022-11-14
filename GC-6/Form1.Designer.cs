namespace GC_6
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.holst = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // holst
            // 
            this.holst.AccumBits = ((byte)(0));
            this.holst.AutoCheckErrors = false;
            this.holst.AutoFinish = false;
            this.holst.AutoMakeCurrent = true;
            this.holst.AutoSwapBuffers = true;
            this.holst.BackColor = System.Drawing.Color.Black;
            this.holst.ColorBits = ((byte)(32));
            this.holst.DepthBits = ((byte)(16));
            this.holst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.holst.Location = new System.Drawing.Point(0, 0);
            this.holst.Name = "holst";
            this.holst.Size = new System.Drawing.Size(634, 611);
            this.holst.StencilBits = ((byte)(0));
            this.holst.TabIndex = 0;
            this.holst.Load += new System.EventHandler(this.simpleOpenGlControl1_Load);
            this.holst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.holst_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 611);
            this.Controls.Add(this.holst);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl holst;
        private System.Windows.Forms.Timer timer1;
    }
}

