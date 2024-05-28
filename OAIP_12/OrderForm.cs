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
    public partial class OrderForm : Form
    {
        private AppDbContext context;
        private Customer customer;
        public Order Order { get; private set; }
        public OrderForm(AppDbContext context, Customer customer)
        {
            InitializeComponent();
            this.context = context;
            this.customer = customer;
        }
        private void AddButton_Click(object sender,EventArgs e)
        {
            var order = new Order
            {
                Name = NameTextBox.Text,
                Description = DescriptionTextBox.Text,
                Status = StatusTextBox.Text,
                CustomerID = customer.CustomerID
            };
            context.Orders.Add(order);
            context.SaveChanges();
            Order = order;
            DialogResult = DialogResult.OK;
        }

    }
}
