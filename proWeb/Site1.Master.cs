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
            _ = int.TryParse(Amount.Text, out int amount);
            _ = float.TryParse(Price.Text, out float price);
            _ = DateTime.Parse(DateTime.Now.ToString("dd'/'MM'/'yyyy' 'HH':'mm':'ss"));
            _ = DateTime.TryParse(DateTime.Now.ToString(("dd'/'MM'/'yyyy' 'HH':'mm':'ss")), out DateTime creationDate);

            product = new ENProduct(code, name, amount, price, category, creationDate);

            bool result = product.Create();

            string msg = result ? "Create operation has sucess" : "Create operation has failed";
            string script = "<script>alert('" + msg + "')</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);

        }

        protected void Update_(object sender, EventArgs e)
        {
            string code = Code.Text;
            string name = Name.Text;
            int category = Category.SelectedIndex;

            // evitar problema de vacio y pasar argumento
            _ = int.TryParse(Amount.Text, out int amount);
            _ = float.TryParse(Price.Text, out float price);
            _ = DateTime.Parse(DateTime.Now.ToString("dd'/'MM'/'yyyy' 'HH':'mm':'ss"));
            _ = DateTime.TryParse(DateTime.Now.ToString(("dd'/'MM'/'yyyy' 'HH':'mm':'ss")), out DateTime creationDate);

            product = new ENProduct(code, name, amount, price, category, creationDate);

            bool result = product.Update();
            string msg = result ? "Update operation has sucess" : "Update operation has failed";
            string script = "<script>alert('" + msg + "')</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);
        }

        protected void Delete_(object sender, EventArgs e)
        {
            product = new ENProduct();
            product.Code = Code.Text;
            bool result = product.Delete();
            string msg = result ? "Delete operation has sucess" : "Delete operation has failed";
            string script = "<script>alert('" + msg + "')</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);
        }

        protected void Read_(object sender, EventArgs e)
        {
            product = new ENProduct();
            product.Code = Code.Text;
            bool result = product.Read();

            string msg;
            string script;

            if (result)
            {
                Name.Text = product.Name;
                Amount.Text = product.Amount.ToString();
                Price.Text = product.Price.ToString();
                Category.SelectedIndex = product.Category;
                Creation_Date.Text = product.CreationDate.ToString();

                msg = "Read operation has sucess";
                script = "<script>alert('" + msg + "')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);
            }
            else
            {
                msg = "Read operation has failed";
                script = "<script>alert('" + msg + "')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);
            }
        }

        protected void ReadFirst_(object sender, EventArgs e)
        {
            product = new ENProduct();
            bool result = product.ReadFirst();

            string msg;
            string script;

            if (result)
            {
                Code.Text = product.Code;
                Name.Text = product.Name;
                Amount.Text = product.Amount.ToString();
                Price.Text = product.Price.ToString();
                Category.SelectedIndex = product.Category;
                Creation_Date.Text = product.CreationDate.ToString();

                msg = "Read first operation has sucess";
                script = "<script>alert('" + msg + "')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);
            }
            else
            {
                msg = "Read first operation has failed";
                script = "<script>alert('" + msg + "')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);
            }
            
        }

        protected void ReadPrev_(object sender, EventArgs e)
        {
            product = new ENProduct();
            product.Code = Code.Text;
            bool result = product.ReadPrev();

            string msg;
            string script;

            if (result)
            {
                Code.Text = product.Code;
                Name.Text = product.Name;
                Amount.Text = product.Amount.ToString();
                Price.Text = product.Price.ToString();
                Category.SelectedIndex = product.Category;
                Creation_Date.Text = product.CreationDate.ToString();

                msg = "Read prev operation has sucess";
                script = "<script>alert('" + msg + "')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);
            }
            else
            {
                msg = "Read prev operation has failed";
                script = "<script>alert('" + msg + "')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);
            }
        }

        protected void ReadNext_(object sender, EventArgs e)
        {
            product = new ENProduct();
            product.Code = Code.Text;
            bool result = product.ReadNext();

            string msg;
            string script;

            if (result)
            {
                Code.Text = product.Code;
                Name.Text = product.Name;
                Amount.Text = product.Amount.ToString();
                Price.Text = product.Price.ToString();
                Category.SelectedIndex = product.Category;
                Creation_Date.Text = product.CreationDate.ToString();

                msg = "Read next operation has sucess";
                script = "<script>alert('" + msg + "')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);
            }
            else
            {
                msg = "Read next operation has failed";
                script = "<script>alert('" + msg + "')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);
            }
        }
        protected void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("hello");
        }
    }
}