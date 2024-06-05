using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAIP_12
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender,EventArgs e)
        {
            Customer customer;
            using (var context = new AppDbContext())
            {
                var email = textBoxEmail.Text;
                var password = textBoxPass.Text;
                customer = context.Customers.FirstOrDefault(u =>
               u.Email == email && u.Password == password);
            }
            if (string.IsNullOrEmpty(textBoxEmail.Text))
                MessageBox.Show("Введите почту");
            else if (string.IsNullOrEmpty(textBoxPass.Text))
                MessageBox.Show("Введите пароль");
            else if (customer != null)
            {
                MessageBox.Show("Вы успешно авторизовались!", "Авторизация", MessageBoxButtons.OK,MessageBoxIcon.Information);
                MainForm mainForm = new MainForm(new AppDbContext(), customer);
                Hide();
                mainForm.ShowDialog();
                DialogResult dialogResult = MessageBox.Show("Закрыть программу?", "Думай",MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    Close();
                else if (dialogResult == DialogResult.No)
                    Show();
            }
            else
            {
                MessageBox.Show("Неправильный email или пароль", "Ошибка авторизации", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm(new AppDbContext());
            Hide();
            registrationForm.ShowDialog();
            Show();
        }
    }
}
