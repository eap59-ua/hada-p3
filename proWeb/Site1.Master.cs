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
            int category = Category.SelectedIndex;

            // evitar problema de vacio y pasar argumento
            int amount = 0;
            bool amount_tryParse = int.TryParse(Amount.Text, out amount);
            float price = 0;
            bool price_tryParse = float.TryParse(Price.Text, out price);
            
            DateTime creationDate = DateTime.Parse(DateTime.Now.ToString("dd'/'MM'/'yyyy' 'HH':'mm':'ss"));
            bool creationDate_tryParse = DateTime.TryParse(DateTime.Now.ToString(("dd'/'MM'/'yyyy' 'HH':'mm':'ss")), out creationDate);
            

            product = new ENProduct(code, name, amount, price, category, creationDate);

            bool result = product.Create();

            string msg = result ? "Create operation has sucess" : "Create operation has failed";
            string script = "<script>alert('" + msg + "')</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);

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