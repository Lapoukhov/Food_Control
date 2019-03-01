namespace Food_Control
{
    partial class formAuthorization
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelAutarization = new System.Windows.Forms.Panel();
            this.buttonRegistration = new System.Windows.Forms.Button();
            this.buttonAuthorization = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textboxPassword = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textboxLogin = new System.Windows.Forms.TextBox();
            this.labelAuthorization = new System.Windows.Forms.Label();
            this.panelRegistration = new System.Windows.Forms.Panel();
            this.buttonToAutorization = new System.Windows.Forms.Button();
            this.buttonRegistrationOK = new System.Windows.Forms.Button();
            this.textboxPassword2 = new System.Windows.Forms.TextBox();
            this.textboxPasswordReg = new System.Windows.Forms.TextBox();
            this.textboxLoginReg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPasswordReg = new System.Windows.Forms.Label();
            this.labelLoginReg = new System.Windows.Forms.Label();
            this.labelRegistration = new System.Windows.Forms.Label();
            this.panelAutarization.SuspendLayout();
            this.panelRegistration.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAutarization
            // 
            this.panelAutarization.BackColor = System.Drawing.Color.PaleGreen;
            this.panelAutarization.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelAutarization.Controls.Add(this.buttonRegistration);
            this.panelAutarization.Controls.Add(this.buttonAuthorization);
            this.panelAutarization.Controls.Add(this.labelPassword);
            this.panelAutarization.Controls.Add(this.textboxPassword);
            this.panelAutarization.Controls.Add(this.labelLogin);
            this.panelAutarization.Controls.Add(this.textboxLogin);
            this.panelAutarization.Controls.Add(this.labelAuthorization);
            this.panelAutarization.Location = new System.Drawing.Point(347, 153);
            this.panelAutarization.Name = "panelAutarization";
            this.panelAutarization.Size = new System.Drawing.Size(354, 372);
            this.panelAutarization.TabIndex = 0;
            // 
            // buttonRegistration
            // 
            this.buttonRegistration.BackColor = System.Drawing.Color.LightGreen;
            this.buttonRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegistration.ForeColor = System.Drawing.Color.DarkGreen;
            this.buttonRegistration.Location = new System.Drawing.Point(41, 282);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(159, 43);
            this.buttonRegistration.TabIndex = 6;
            this.buttonRegistration.Text = "Регистрация";
            this.buttonRegistration.UseVisualStyleBackColor = false;
            this.buttonRegistration.Click += new System.EventHandler(this.buttonRegistration_Click);
            // 
            // buttonAuthorization
            // 
            this.buttonAuthorization.BackColor = System.Drawing.Color.LightGreen;
            this.buttonAuthorization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAuthorization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAuthorization.ForeColor = System.Drawing.Color.DarkGreen;
            this.buttonAuthorization.Location = new System.Drawing.Point(217, 282);
            this.buttonAuthorization.Name = "buttonAuthorization";
            this.buttonAuthorization.Size = new System.Drawing.Size(95, 43);
            this.buttonAuthorization.TabIndex = 5;
            this.buttonAuthorization.Text = "Вход";
            this.buttonAuthorization.UseVisualStyleBackColor = false;
            this.buttonAuthorization.Click += new System.EventHandler(this.buttonAuthorization_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelPassword.Location = new System.Drawing.Point(36, 167);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(86, 29);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Пароль:";
            // 
            // textboxPassword
            // 
            this.textboxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxPassword.Location = new System.Drawing.Point(41, 199);
            this.textboxPassword.Name = "textboxPassword";
            this.textboxPassword.PasswordChar = '*';
            this.textboxPassword.Size = new System.Drawing.Size(271, 38);
            this.textboxPassword.TabIndex = 3;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelLogin.Location = new System.Drawing.Point(36, 70);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(71, 29);
            this.labelLogin.TabIndex = 2;
            this.labelLogin.Text = "Логин:";
            // 
            // textboxLogin
            // 
            this.textboxLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxLogin.Location = new System.Drawing.Point(41, 102);
            this.textboxLogin.Name = "textboxLogin";
            this.textboxLogin.Size = new System.Drawing.Size(271, 38);
            this.textboxLogin.TabIndex = 1;
            // 
            // labelAuthorization
            // 
            this.labelAuthorization.AutoSize = true;
            this.labelAuthorization.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAuthorization.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelAuthorization.Location = new System.Drawing.Point(92, 0);
            this.labelAuthorization.Name = "labelAuthorization";
            this.labelAuthorization.Size = new System.Drawing.Size(163, 35);
            this.labelAuthorization.TabIndex = 0;
            this.labelAuthorization.Text = "Авторизация";
            // 
            // panelRegistration
            // 
            this.panelRegistration.BackColor = System.Drawing.Color.PaleGreen;
            this.panelRegistration.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRegistration.Controls.Add(this.buttonToAutorization);
            this.panelRegistration.Controls.Add(this.buttonRegistrationOK);
            this.panelRegistration.Controls.Add(this.textboxPassword2);
            this.panelRegistration.Controls.Add(this.textboxPasswordReg);
            this.panelRegistration.Controls.Add(this.textboxLoginReg);
            this.panelRegistration.Controls.Add(this.label1);
            this.panelRegistration.Controls.Add(this.labelPasswordReg);
            this.panelRegistration.Controls.Add(this.labelLoginReg);
            this.panelRegistration.Controls.Add(this.labelRegistration);
            this.panelRegistration.Location = new System.Drawing.Point(347, 153);
            this.panelRegistration.Name = "panelRegistration";
            this.panelRegistration.Size = new System.Drawing.Size(354, 517);
            this.panelRegistration.TabIndex = 1;
            this.panelRegistration.Visible = false;
            // 
            // buttonToAutorization
            // 
            this.buttonToAutorization.BackColor = System.Drawing.Color.LightGreen;
            this.buttonToAutorization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToAutorization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToAutorization.ForeColor = System.Drawing.Color.DarkGreen;
            this.buttonToAutorization.Location = new System.Drawing.Point(40, 443);
            this.buttonToAutorization.Name = "buttonToAutorization";
            this.buttonToAutorization.Size = new System.Drawing.Size(272, 46);
            this.buttonToAutorization.TabIndex = 8;
            this.buttonToAutorization.Text = "Уже зарегистрированы?";
            this.buttonToAutorization.UseVisualStyleBackColor = false;
            this.buttonToAutorization.Click += new System.EventHandler(this.buttonToAutorization_Click);
            // 
            // buttonRegistrationOK
            // 
            this.buttonRegistrationOK.BackColor = System.Drawing.Color.LightGreen;
            this.buttonRegistrationOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistrationOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegistrationOK.ForeColor = System.Drawing.Color.DarkGreen;
            this.buttonRegistrationOK.Location = new System.Drawing.Point(40, 373);
            this.buttonRegistrationOK.Name = "buttonRegistrationOK";
            this.buttonRegistrationOK.Size = new System.Drawing.Size(272, 46);
            this.buttonRegistrationOK.TabIndex = 7;
            this.buttonRegistrationOK.Text = "Зарегистрироваться";
            this.buttonRegistrationOK.UseVisualStyleBackColor = false;
            this.buttonRegistrationOK.Click += new System.EventHandler(this.buttonRegistrationOK_Click);
            // 
            // textboxPassword2
            // 
            this.textboxPassword2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxPassword2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxPassword2.Location = new System.Drawing.Point(40, 296);
            this.textboxPassword2.Name = "textboxPassword2";
            this.textboxPassword2.PasswordChar = '*';
            this.textboxPassword2.Size = new System.Drawing.Size(272, 38);
            this.textboxPassword2.TabIndex = 6;
            // 
            // textboxPasswordReg
            // 
            this.textboxPasswordReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxPasswordReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxPasswordReg.Location = new System.Drawing.Point(40, 199);
            this.textboxPasswordReg.Name = "textboxPasswordReg";
            this.textboxPasswordReg.PasswordChar = '*';
            this.textboxPasswordReg.Size = new System.Drawing.Size(272, 38);
            this.textboxPasswordReg.TabIndex = 5;
            // 
            // textboxLoginReg
            // 
            this.textboxLoginReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxLoginReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxLoginReg.Location = new System.Drawing.Point(40, 102);
            this.textboxLoginReg.Name = "textboxLoginReg";
            this.textboxLoginReg.Size = new System.Drawing.Size(272, 38);
            this.textboxLoginReg.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(35, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Повторите пароль:";
            // 
            // labelPasswordReg
            // 
            this.labelPasswordReg.AutoSize = true;
            this.labelPasswordReg.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPasswordReg.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelPasswordReg.Location = new System.Drawing.Point(35, 167);
            this.labelPasswordReg.Name = "labelPasswordReg";
            this.labelPasswordReg.Size = new System.Drawing.Size(164, 29);
            this.labelPasswordReg.TabIndex = 2;
            this.labelPasswordReg.Text = "Введите пароль:";
            // 
            // labelLoginReg
            // 
            this.labelLoginReg.AutoSize = true;
            this.labelLoginReg.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLoginReg.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelLoginReg.Location = new System.Drawing.Point(35, 70);
            this.labelLoginReg.Name = "labelLoginReg";
            this.labelLoginReg.Size = new System.Drawing.Size(161, 29);
            this.labelLoginReg.TabIndex = 1;
            this.labelLoginReg.Text = "Создайте логин:";
            // 
            // labelRegistration
            // 
            this.labelRegistration.AutoSize = true;
            this.labelRegistration.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRegistration.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelRegistration.Location = new System.Drawing.Point(94, 0);
            this.labelRegistration.Name = "labelRegistration";
            this.labelRegistration.Size = new System.Drawing.Size(160, 35);
            this.labelRegistration.TabIndex = 0;
            this.labelRegistration.Text = "Регистрация";
            // 
            // formAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(1049, 737);
            this.Controls.Add(this.panelRegistration);
            this.Controls.Add(this.panelAutarization);
            this.MinimumSize = new System.Drawing.Size(1067, 784);
            this.Name = "formAuthorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Food Control";
            this.panelAutarization.ResumeLayout(false);
            this.panelAutarization.PerformLayout();
            this.panelRegistration.ResumeLayout(false);
            this.panelRegistration.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAutarization;
        private System.Windows.Forms.Label labelAuthorization;
        public System.Windows.Forms.TextBox textboxLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textboxPassword;
        private System.Windows.Forms.Button buttonAuthorization;
        private System.Windows.Forms.Button buttonRegistration;
        private System.Windows.Forms.Panel panelRegistration;
        private System.Windows.Forms.TextBox textboxLoginReg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPasswordReg;
        private System.Windows.Forms.Label labelLoginReg;
        private System.Windows.Forms.Label labelRegistration;
        private System.Windows.Forms.Button buttonRegistrationOK;
        private System.Windows.Forms.TextBox textboxPassword2;
        private System.Windows.Forms.TextBox textboxPasswordReg;
        private System.Windows.Forms.Button buttonToAutorization;
    }
}

