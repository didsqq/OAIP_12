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
            context.Customers.Add(customer);
            context.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрировались!",
           "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
