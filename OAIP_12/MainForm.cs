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
    public partial class MainForm : Form
    {
        private AppDbContext context;
        private Customer customer;
        public MainForm(AppDbContext context, Customer customer)
        {
            InitializeComponent();
            this.context = context;
            this.customer = customer;
            customer.Orders = context.Orders.Where(b => b.CustomerID == customer.CustomerID).ToList();
            Text = $"Заказы пользователя {customer.FIO}";
            OrdersDataGridView.AutoGenerateColumns = true;
            OrdersDataGridView.DataSource = customer.Orders;
        }
        private void AddOrderButton_Click(object sender, EventArgs e)
        {
            var orderForm = new OrderForm(context, customer);
            if (orderForm.ShowDialog() == DialogResult.OK)
            {
                customer.Orders.Add(orderForm.Order);
                context.SaveChanges();
                OrdersDataGridView.DataSource = null;
                OrdersDataGridView.DataSource = customer.Orders;
            }
        }
        private void DeleteOrderButton_Click(object sender, EventArgs e)
        {
            var selectedRow = OrdersDataGridView.SelectedRows[0];
            var order = (Order)selectedRow.DataBoundItem;
            customer.Orders.Remove(order);
            context.SaveChanges();
            OrdersDataGridView.DataSource = null;
            OrdersDataGridView.DataSource = customer.Orders;
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
