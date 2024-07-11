namespace StudentManagementSystem
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            grpbox = new GroupBox();
            showPass = new CheckBox();
            button2 = new Button();
            button1 = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label3 = new Label();
            label2 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            grpbox.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(282, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(228, 227);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(203, 253);
            label1.Name = "label1";
            label1.Size = new Size(380, 51);
            label1.TabIndex = 1;
            label1.Text = "Skills International";
            label1.Click += label1_Click;
            // 
            // grpbox
            // 
            grpbox.Controls.Add(showPass);
            grpbox.Controls.Add(button2);
            grpbox.Controls.Add(button1);
            grpbox.Controls.Add(txtPassword);
            grpbox.Controls.Add(txtUsername);
            grpbox.Controls.Add(label3);
            grpbox.Controls.Add(label2);
            grpbox.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpbox.Location = new Point(147, 336);
            grpbox.Name = "grpbox";
            grpbox.Size = new Size(479, 313);
            grpbox.TabIndex = 2;
            grpbox.TabStop = false;
            grpbox.Text = "Login";
            grpbox.Enter += Login_Enter;
            // 
            // showPass
            // 
            showPass.AutoSize = true;
            showPass.Location = new Point(262, 170);
            showPass.Name = "showPass";
            showPass.Size = new Size(189, 31);
            showPass.TabIndex = 5;
            showPass.Text = "Show Password";
            showPass.UseVisualStyleBackColor = true;
            showPass.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.AppWorkspace;
            button2.Location = new Point(331, 225);
            button2.Name = "button2";
            button2.Size = new Size(113, 45);
            button2.TabIndex = 4;
            button2.Text = "Login";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.AppWorkspace;
            button1.Location = new Point(60, 225);
            button1.Name = "button1";
            button1.Size = new Size(113, 45);
            button1.TabIndex = 4;
            button1.Text = "Clear";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(216, 120);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(228, 35);
            txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(216, 63);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(228, 35);
            txtUsername.TabIndex = 2;
            txtUsername.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 124);
            label3.Name = "label3";
            label3.Size = new Size(104, 27);
            label3.TabIndex = 1;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 66);
            label2.Name = "label2";
            label2.Size = new Size(108, 27);
            label2.TabIndex = 0;
            label2.Text = "Username";
            // 
            // button3
            // 
            button3.BackColor = SystemColors.AppWorkspace;
            button3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(12, 668);
            button3.Name = "button3";
            button3.Size = new Size(113, 45);
            button3.TabIndex = 4;
            button3.Text = "Exit";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(780, 722);
            Controls.Add(grpbox);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - Skills International";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            grpbox.ResumeLayout(false);
            grpbox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private GroupBox grpbox;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label3;
        private Label label2;
        private Button button2;
        private Button button1;
        private Button button3;
        private CheckBox showPass;
    }
}
