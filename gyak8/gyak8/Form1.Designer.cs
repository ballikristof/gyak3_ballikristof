namespace gyak8
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
            this.components = new System.ComponentModel.Container();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Ball = new System.Windows.Forms.Button();
            this.btn_Car = new System.Windows.Forms.Button();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.btn_Present = new System.Windows.Forms.Button();
            this.btn_Ribbonclr = new System.Windows.Forms.Button();
            this.btn_Boxclr = new System.Windows.Forms.Button();
            this.mainpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainpanel
            // 
            this.mainpanel.Controls.Add(this.btn_Boxclr);
            this.mainpanel.Controls.Add(this.btn_Ribbonclr);
            this.mainpanel.Controls.Add(this.btn_Present);
            this.mainpanel.Controls.Add(this.button1);
            this.mainpanel.Controls.Add(this.label1);
            this.mainpanel.Controls.Add(this.btn_Ball);
            this.mainpanel.Controls.Add(this.btn_Car);
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(0, 0);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1136, 450);
            this.mainpanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(279, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 28);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(670, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Coming next:";
            // 
            // btn_Ball
            // 
            this.btn_Ball.Location = new System.Drawing.Point(279, 29);
            this.btn_Ball.Name = "btn_Ball";
            this.btn_Ball.Size = new System.Drawing.Size(134, 82);
            this.btn_Ball.TabIndex = 1;
            this.btn_Ball.Text = "BALL";
            this.btn_Ball.UseVisualStyleBackColor = true;
            this.btn_Ball.Click += new System.EventHandler(this.btn_Ball_Click);
            // 
            // btn_Car
            // 
            this.btn_Car.Location = new System.Drawing.Point(80, 29);
            this.btn_Car.Name = "btn_Car";
            this.btn_Car.Size = new System.Drawing.Size(134, 82);
            this.btn_Car.TabIndex = 0;
            this.btn_Car.Text = "CAR";
            this.btn_Car.UseVisualStyleBackColor = true;
            this.btn_Car.Click += new System.EventHandler(this.btn_Car_Click);
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // btn_Present
            // 
            this.btn_Present.Location = new System.Drawing.Point(484, 29);
            this.btn_Present.Name = "btn_Present";
            this.btn_Present.Size = new System.Drawing.Size(134, 82);
            this.btn_Present.TabIndex = 4;
            this.btn_Present.Text = "PRESENT";
            this.btn_Present.UseVisualStyleBackColor = true;
            this.btn_Present.Click += new System.EventHandler(this.btn_Present_Click);
            // 
            // btn_Ribbonclr
            // 
            this.btn_Ribbonclr.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Ribbonclr.Location = new System.Drawing.Point(484, 132);
            this.btn_Ribbonclr.Name = "btn_Ribbonclr";
            this.btn_Ribbonclr.Size = new System.Drawing.Size(134, 28);
            this.btn_Ribbonclr.TabIndex = 5;
            this.btn_Ribbonclr.UseVisualStyleBackColor = false;
            this.btn_Ribbonclr.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Boxclr
            // 
            this.btn_Boxclr.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Boxclr.Location = new System.Drawing.Point(484, 166);
            this.btn_Boxclr.Name = "btn_Boxclr";
            this.btn_Boxclr.Size = new System.Drawing.Size(134, 28);
            this.btn_Boxclr.TabIndex = 6;
            this.btn_Boxclr.UseVisualStyleBackColor = false;
            this.btn_Boxclr.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 450);
            this.Controls.Add(this.mainpanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainpanel.ResumeLayout(false);
            this.mainpanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Ball;
        private System.Windows.Forms.Button btn_Car;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Boxclr;
        private System.Windows.Forms.Button btn_Ribbonclr;
        private System.Windows.Forms.Button btn_Present;
    }
}

