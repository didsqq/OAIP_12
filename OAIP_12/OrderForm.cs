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
        private Order order;
        private int flag = 0;
        public Order Order { get; private set; }
        public OrderForm(AppDbContext context, Customer customer, Order order)
        {
            InitializeComponent();
            this.context = context;
            this.customer = customer;
            this.order = order;
            if(order != null)
            {
                flag = 1;
                NameTextBox.Text = order.Name;
                DescriptionTextBox.Text = order.Description;
                StatusTextBox.Text = order.Status;
            }
        }
        private void AddButton_Click(object sender,EventArgs e)
        {
            if(flag == 1)
            {
                context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                order.Name = NameTextBox.Text;
                order.Description = DescriptionTextBox.Text;
                order.Status = StatusTextBox.Text;
                order.CustomerID = customer.CustomerID;
                context.SaveChanges();
            }
            if(flag != 1)
            {
                var ordernew = new Order
                {
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Status = StatusTextBox.Text,
                    CustomerID = customer.CustomerID
                };
                context.Orders.Add(ordernew);
                context.SaveChanges();
                Order = ordernew;
            }

            DialogResult = DialogResult.OK;
        }

    }
}
