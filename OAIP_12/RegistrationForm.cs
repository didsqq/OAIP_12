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
    public partial class RegistrationForm : Form
    {
        private readonly AppDbContext context;
        public RegistrationForm(AppDbContext context)
        {
            InitializeComponent();
            this.context = context;
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var customer = new Customer
            {
                FIO = textBoxFIO.Text,
                Email = textBoxEmail.Text,
                Password = textBoxPass.Text
            };
            if (string.IsNullOrEmpty(textBoxFIO.Text))
                MessageBox.Show("Введите имя");
            else if (string.IsNullOrEmpty(textBoxEmail.Text))
                MessageBox.Show("Введите почту");
            else if (string.IsNullOrEmpty(textBoxPass.Text))
                MessageBox.Show("Введите пароль");
            else
            {
                try
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрировались!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                
            }



        }
    }
}
