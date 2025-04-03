namespace WinFormsApp1
{
    partial class StudentPage_Individual
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtCourseYear;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtBirthdate;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtGuardian;
        private System.Windows.Forms.TextBox txtHobbies;
        private System.Windows.Forms.TextBox txtNickname;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtCourseYear = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtBirthdate = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtGuardian = new System.Windows.Forms.TextBox();
            this.txtHobbies = new System.Windows.Forms.TextBox();
            this.txtNickname = new System.Windows.Forms.TextBox();

            this.SuspendLayout();

            
            int startX = 150, startY = 20, spacing = 30;
            System.Windows.Forms.Label[] labels = new System.Windows.Forms.Label[11];
            string[] labelNames = { "Student ID:", "Full Name:", "Course and Year:", "Address:", "Birthdate:", "Age:", "Contact Info:", "Email Address:", "Guardian Info:", "Hobbies:", "Nickname:" };
            System.Windows.Forms.TextBox[] textBoxes = { txtStudentId, txtFullName, txtCourseYear, txtAddress, txtBirthdate, txtAge, txtContact, txtEmail, txtGuardian, txtHobbies, txtNickname };

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new System.Windows.Forms.Label();
                labels[i].Text = labelNames[i];
                labels[i].Location = new System.Drawing.Point(20, startY + (i * spacing));
                labels[i].Size = new System.Drawing.Size(120, 20);
                this.Controls.Add(labels[i]);

                textBoxes[i].Location = new System.Drawing.Point(startX, startY + (i * spacing));
                textBoxes[i].Size = new System.Drawing.Size(200, 20);
                textBoxes[i].ReadOnly = true;
                this.Controls.Add(textBoxes[i]);
            }

            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Name = "StudentPage_Individual";
            this.Text = "Student Individual Form";
            this.Load += new System.EventHandler(this.StudentPage_Individual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
