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
            string code = Code.Text.Trim();
            string name = Name.Text.Trim();
            string amountStr = Amount.Text;
            string priceStr = Price.Text;

            // Validación de restricciones
            if (!ValidateInputs(code, name, amountStr, priceStr))
            {
                return;
            }

            // Obtener la fecha actual
            DateTime creationDate = DateTime.Now;

            // Crear el producto
            product = new ENProduct(code, name, int.Parse(amountStr), float.Parse(priceStr), Category.SelectedIndex, creationDate);
            bool result = product.Create();

            // Mostrar mensaje de éxito o error
            if (result)
            {
                ShowMessage("Create operation has succeeded.", MessageType.Success);
                // Limpiar los campos del formulario
                Code.Text = "";
                Name.Text = "";
                Amount.Text = "";
                Price.Text = "";
                Category.SelectedIndex = 0; // Otra opción es seleccionar un índice predeterminado según sea necesario
                Creation_Date.Text = "";
            }
            else
            {
                ShowMessage("Create operation has failed.", MessageType.Error);
            }
        }
        //segun sea mensaje de error o no
        private enum MessageType
        {
            Error,
            Success
        }

        private bool ValidateInputs(string code, string name, string amountStr, string priceStr)
        {
            // Validar código
            if (string.IsNullOrEmpty(code) || code.Length > 16)
            {
                ShowMessage("Code must be between 1 and 16 characters.", MessageType.Error);
                return false;
            }

            // Validar nombre
            if (string.IsNullOrEmpty(name) || name.Length > 32)
            {
                ShowMessage("Name must be up to 32 characters.", MessageType.Error);
                return false;
            }

            // Validar cantidad
            if (!int.TryParse(amountStr, out int amount) || amount < 0 || amount > 9999)
            {
                ShowMessage("Amount must be an integer between 0 and 9999.", MessageType.Error);
                return false;
            }

            // Validar precio
            if (!float.TryParse(priceStr, out float price) || price < 0 || price > 9999.99)
            {
                ShowMessage("Price must be a real number between 0 and 9999.99.", MessageType.Error);
                return false;
            }

            return true;
        }

        private void ShowMessage(string message, MessageType type)
        {
            ErrorLabel.Text = message;
            ErrorLabel.ForeColor = type == MessageType.Success ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            ErrorLabel.Visible = true;
        }


        // Método para realizar la operación de actualización
        protected void Update_(object sender, EventArgs e)
        {
            string code = Code.Text.Trim();
            string name = Name.Text.Trim();
            int category = Category.SelectedIndex;

            // Validar las entradas del usuario
            if (!ValidateInputs(code, name, Amount.Text, Price.Text))
            {
                return; // No se procede si la validación falla
            }

            // Crear objeto ENProduct con los datos ingresados
            ENProduct product = new ENProduct(code, name, int.Parse(Amount.Text), float.Parse(Price.Text), category, DateTime.Now);

            // Realizar la operación de actualización
            bool result = product.Update();

            // Mostrar mensaje de éxito o error
            string msg = result ? "Update operation has succeeded." : "Update operation has failed.";
            ShowMessage(msg, result ? MessageType.Success : MessageType.Error);
        }
        // Método para realizar la operación de eliminación
        protected void Delete_(object sender, EventArgs e)
        {
            string code = Code.Text.Trim();

            // Validar que se haya ingresado un código
            if (string.IsNullOrEmpty(code))
            {
                ShowMessage("Please enter a product code.", MessageType.Error);
                return; // No se procede si no se ha ingresado un código
            }

            // Crear objeto ENProduct con el código ingresado
            ENProduct product = new ENProduct();
            product.Code = code;

            // Realizar la operación de eliminación
            bool result = product.Delete();

            // Mostrar mensaje de éxito o error
            string msg = result ? "Delete operation has succeeded." : "Delete operation has failed.";
            ShowMessage(msg, result ? MessageType.Success : MessageType.Error);
        }

        // Método para realizar la operación de lectura
        protected void Read_(object sender, EventArgs e)
        {
            string code = Code.Text.Trim();

            // Validar que se haya ingresado un código
            if (string.IsNullOrEmpty(code))
            {
                ShowMessage("Please enter a product code.", MessageType.Error);
                return; // No se procede si no se ha ingresado un código
            }

            // Crear objeto ENProduct con el código ingresado
            ENProduct product = new ENProduct();
            product.Code = code;

            // Realizar la operación de lectura
            bool result = product.Read();

            // Mostrar mensaje de éxito o error
            if (result)
            {
                // Mostrar los datos del producto en el formulario
                Name.Text = product.Name;
                Amount.Text = product.Amount.ToString();
                Price.Text = product.Price.ToString();
                Category.SelectedIndex = product.Category;
                Creation_Date.Text = product.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");

                // Mostrar mensaje de éxito
                ShowMessage("Read operation has succeeded.", MessageType.Success);
            }
            else
            {
                // Mostrar mensaje de error
                ShowMessage("Read operation has failed.", MessageType.Error);
            }
        }

        // Método para realizar la operación de lectura del primer producto
        protected void ReadFirst_(object sender, EventArgs e)
        {
            // Crear un objeto ENProduct para gestionar los datos del producto
            ENProduct product = new ENProduct();

            // Realizar la operación de lectura del primer producto
            bool result = product.ReadFirst();

            // Mostrar mensaje de éxito o error
            if (result)
            {
                // Mostrar los datos del primer producto en el formulario
                Code.Text = product.Code;
                Name.Text = product.Name;
                Amount.Text = product.Amount.ToString();
                Price.Text = product.Price.ToString();
                Category.SelectedIndex = product.Category;
                Creation_Date.Text = product.CreationDate.ToString();

                // Mostrar mensaje de éxito
                ShowMessage("Read first operation has succeeded.", MessageType.Success);
            }
            else
            {
                // Mostrar mensaje de error
                ShowMessage("Read first operation has failed.", MessageType.Error);
            }
        }

        protected void ReadPrev_(object sender, EventArgs e)
        {
            string code = Code.Text.Trim();

            // Validar que se haya ingresado un código
            if (string.IsNullOrEmpty(code))
            {
                ShowMessage("Please enter a product code.", MessageType.Error);
                return; // No se procede si no se ha ingresado un código
            }

            // Realizar la operación de lectura del producto previo
            ENProduct product = new ENProduct();
            product.Code = code;

            bool result = product.ReadPrev();

            if (result)
            {
                // Mostrar los datos del producto previo en el formulario
                Code.Text = product.Code;
                Name.Text = product.Name;
                Amount.Text = product.Amount.ToString();
                Price.Text = product.Price.ToString();
                Category.SelectedIndex = product.Category;
                Creation_Date.Text = product.CreationDate.ToString();

                // Mostrar mensaje de éxito
                ShowMessage("Read prev operation has succeeded.", MessageType.Success);
            }
            else
            {
                // Mostrar mensaje de error
                ShowMessage("Read prev operation has failed.", MessageType.Error);
            }
        }

        protected void ReadNext_(object sender, EventArgs e)
        {
            string code = Code.Text.Trim();

            // Validar que se haya ingresado un código
            if (string.IsNullOrEmpty(code))
            {
                ShowMessage("Please enter a product code.", MessageType.Error);
                return; // No se procede si no se ha ingresado un código
            }

            // Realizar la operación de lectura del siguiente producto
            ENProduct product = new ENProduct();
            product.Code = code;

            bool result = product.ReadNext();

            if (result)
            {
                // Mostrar los datos del producto siguiente en el formulario
                Code.Text = product.Code;
                Name.Text = product.Name;
                Amount.Text = product.Amount.ToString();
                Price.Text = product.Price.ToString();
                Category.SelectedIndex = product.Category;
                Creation_Date.Text = product.CreationDate.ToString();

                // Mostrar mensaje de éxito
                ShowMessage("Read next operation has succeeded.", MessageType.Success);
            }
            else
            {
                // Mostrar mensaje de error
                ShowMessage("Read next operation has failed.", MessageType.Error);
            }
        }

    }
}