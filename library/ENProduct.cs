using System;

namespace library
{
    public class ENProduct
    {
        // atribute
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;
        // property
        public string Code {get { return _code; }  set { _code = value; } } 
        public string Name { get { return _name; } set { _name = value; } }
        public int Amount { get { return _amount; } set { _amount = value; } }
        public float Price { get { return _price; } set { _price = value; } }
        public int Category { get { return _category; } set { _category = value; } }
        public DateTime CreationDate { get { return _creationDate; } set { _creationDate = value; } }

        // methods
        public ENProduct()
        {
            Code = string.Empty;
            Name = string.Empty;
            Amount = 0;
            Price = 0.0f;
            Category = 0;
            CreationDate = DateTime.Now;
        }
        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            Code = code;
            Name = name;
            Amount = amount;
            Price = price;
            Category = category;
            CreationDate = creationDate;
        }

        public bool Create()
        {
            try
            {
                CADProduct cADProduct = new CADProduct();
                bool result = cADProduct.Create(this);
                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occured, {ex.Message}");
                return false;
            }
        }
        public bool Update()
        {
            try
            {
                CADProduct cADProduct = new CADProduct();
                bool result = cADProduct.Update(this);
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
                return false;
            }
            
        }
        public bool Delete()
        {
            try
            {
                CADProduct cADProduct = new CADProduct();
                bool result = cADProduct.Delete(this);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error ocurred: {ex.Message}");
                return false;
            }
        }
        public bool Read()
        {
            try
            {
                CADProduct cADProduct = new CADProduct();
                bool result = cADProduct.Read(this);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error ocurred: {ex.Message}");
                return false;
            }
        }
        public bool readFirst()
        {
            try
            {
                CADProduct cADProduct = new CADProduct();
                bool result = cADProduct.ReadFirst(this);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error ocurred: {ex.Message}");
                return false;
            }
        }
        public bool readNext()
        {
            try
            {
                CADProduct cADProduct = new CADProduct();
                bool result = cADProduct.ReadNext(this);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error ocurred: {ex.Message}");
                return false;
            }
        }
        public bool readPrev()
        {
            try
            {
                CADProduct cADProduct = new CADProduct();
                bool result = cADProduct.ReadPrev(this);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error ocurred: {ex.Message}");
                return false;
            }
        }
    }
}
