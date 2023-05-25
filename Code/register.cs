using System;
using System.Windows.Forms;

namespace YourApplication
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.Text = "Registration Form";

            nameTextBox.Text = "Your name"; 
            emailTextBox.Text = "example@example.com";

            nameTextBox.Focus();

            saveButton.Enabled = false;

            nameTextBox.TextChanged += InputTextChanged;
            emailTextBox.TextChanged += InputTextChanged;
        }

        private void InputTextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameTextBox.Text) && !string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                saveButton.Enabled = true;
            }
            else
            {
                saveButton.Enabled = false;
            }
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            
            string name = nameTextBox.Text;
            string email = emailTextBox.Text;
    
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            try
            {
                string filePath = "Login_Informations.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"Name: {name}");
                    writer.WriteLine($"Email: {email}");
                    writer.WriteLine();
                }

                MessageBox.Show("Registration information saved successfully.");
                this.Close(); 
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while saving registration information: " + ex.Message);
            }
        }
    }
}