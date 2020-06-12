namespace SnakeApplication
{
    partial class GameWindow
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
            this.PB_SnakeHead = new System.Windows.Forms.PictureBox();
            this.PB_SnakeBody = new System.Windows.Forms.PictureBox();
            this.PB_SnakeTail = new System.Windows.Forms.PictureBox();
            this.PB_Food = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_SnakeHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_SnakeBody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_SnakeTail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Food)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_SnakeHead
            // 
            this.PB_SnakeHead.BackColor = System.Drawing.Color.Transparent;
            this.PB_SnakeHead.BackgroundImage = global::SnakeApplication.Properties.Resources.SnakeHead;
            this.PB_SnakeHead.ErrorImage = global::SnakeApplication.Properties.Resources.SnakeHead;
            this.PB_SnakeHead.Image = global::SnakeApplication.Properties.Resources.SnakeHead;
            this.PB_SnakeHead.Location = new System.Drawing.Point(114, 114);
            this.PB_SnakeHead.MaximumSize = new System.Drawing.Size(32, 32);
            this.PB_SnakeHead.MinimumSize = new System.Drawing.Size(32, 32);
            this.PB_SnakeHead.Name = "PB_SnakeHead";
            this.PB_SnakeHead.Size = new System.Drawing.Size(32, 32);
            this.PB_SnakeHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PB_SnakeHead.TabIndex = 0;
            this.PB_SnakeHead.TabStop = false;
            // 
            // PB_SnakeBody
            // 
            this.PB_SnakeBody.BackColor = System.Drawing.Color.Transparent;
            this.PB_SnakeBody.Image = global::SnakeApplication.Properties.Resources.SnakeBody;
            this.PB_SnakeBody.Location = new System.Drawing.Point(161, 114);
            this.PB_SnakeBody.MaximumSize = new System.Drawing.Size(32, 32);
            this.PB_SnakeBody.MinimumSize = new System.Drawing.Size(32, 32);
            this.PB_SnakeBody.Name = "PB_SnakeBody";
            this.PB_SnakeBody.Size = new System.Drawing.Size(32, 32);
            this.PB_SnakeBody.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PB_SnakeBody.TabIndex = 1;
            this.PB_SnakeBody.TabStop = false;
            // 
            // PB_SnakeTail
            // 
            this.PB_SnakeTail.BackColor = System.Drawing.Color.Transparent;
            this.PB_SnakeTail.Image = global::SnakeApplication.Properties.Resources.SnakeTail;
            this.PB_SnakeTail.InitialImage = global::SnakeApplication.Properties.Resources.SnakeTail;
            this.PB_SnakeTail.Location = new System.Drawing.Point(208, 114);
            this.PB_SnakeTail.MaximumSize = new System.Drawing.Size(32, 32);
            this.PB_SnakeTail.MinimumSize = new System.Drawing.Size(32, 32);
            this.PB_SnakeTail.Name = "PB_SnakeTail";
            this.PB_SnakeTail.Size = new System.Drawing.Size(32, 32);
            this.PB_SnakeTail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PB_SnakeTail.TabIndex = 2;
            this.PB_SnakeTail.TabStop = false;
            // 
            // PB_Food
            // 
            this.PB_Food.BackColor = System.Drawing.Color.Transparent;
            this.PB_Food.BackgroundImage = global::SnakeApplication.Properties.Resources.Pizza;
            this.PB_Food.ErrorImage = global::SnakeApplication.Properties.Resources.Pizza;
            this.PB_Food.InitialImage = global::SnakeApplication.Properties.Resources.Pizza;
            this.PB_Food.Location = new System.Drawing.Point(377, 258);
            this.PB_Food.MaximumSize = new System.Drawing.Size(32, 32);
            this.PB_Food.MinimumSize = new System.Drawing.Size(32, 32);
            this.PB_Food.Name = "PB_Food";
            this.PB_Food.Size = new System.Drawing.Size(32, 32);
            this.PB_Food.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PB_Food.TabIndex = 3;
            this.PB_Food.TabStop = false;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(778, 784);
            this.Controls.Add(this.PB_Food);
            this.Controls.Add(this.PB_SnakeTail);
            this.Controls.Add(this.PB_SnakeBody);
            this.Controls.Add(this.PB_SnakeHead);
            this.Name = "GameWindow";
            this.Text = "Snake";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameWindow_FormClosed);
            this.Load += new System.EventHandler(this.GameWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameWindow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PB_SnakeHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_SnakeBody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_SnakeTail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Food)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_SnakeHead;
        private System.Windows.Forms.PictureBox PB_SnakeBody;
        private System.Windows.Forms.PictureBox PB_SnakeTail;
        private System.Windows.Forms.PictureBox PB_Food;
    }
}

