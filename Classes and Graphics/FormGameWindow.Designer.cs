namespace Classes_and_Graphics
{
    partial class FormGameWindow
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
            this.components = new System.ComponentModel.Container();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 10;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // FormGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.Name = "FormGameWindow";
            this.Text = "Mini Game";
            this.Load += new System.EventHandler(this.FormGameWindow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormGameWindow_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormGameWindow_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormGameWindow_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
    }
}

