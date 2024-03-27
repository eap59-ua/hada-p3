using library;
using System;


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
            Console.WriteLine("hello world");
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