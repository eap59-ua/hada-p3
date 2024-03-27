using library;
using System;
using System.Web.UI;

namespace proWeb
{

    public partial class Site1 : System.Web.UI.MasterPage
    {
        private ENProduct product;

        protected void Page_Load(object sender, EventArgs e)
        {

            
            // cuando f5
            if (!IsPostBack)
            {
                product = new ENProduct();
            }
            
            
        }

        protected void Create_(object sender, EventArgs e)
        {
            string code = Code.Text;
            string name = Name.Text;
            int amount = int.Parse(Amount.Text);
            float price = float.Parse(Price.Text);
            int category = Category.SelectedIndex;
            DateTime creationDate = DateTime.Now;
            
            if (!string.IsNullOrEmpty(Creation_Date.Text))
            {
                creationDate = DateTime.Parse(Creation_Date.Text);
            }

            product = new ENProduct(code, name, amount, price, category, creationDate);

            bool result = product.Create();
            string msg = result ? "success" : "failed";
            Page.Controls.Add(new LiteralControl("alert('" + msg + "')"));




        }

        protected void Update_(object sender, EventArgs e)
        {

        }

        protected void Delete_(object sender, EventArgs e)
        {

        }

        protected void Read_(object sender, EventArgs e)
        {

        }

        protected void ReadFirst_(object sender, EventArgs e)
        {

        }

        protected void ReadPrev_(object sender, EventArgs e)
        {

        }

        protected void ReadNext_(object sender, EventArgs e)
        {

        }
        protected void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("hello");

        }
    }
}