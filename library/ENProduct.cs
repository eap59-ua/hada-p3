using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        ENProduct()
        {
            ;
        }
        ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            Code = code;
            Name = name;
            Amount = amount;
            Price = price;
            Category = category;
            CreationDate = creationDate;
        }

        bool Create()
        {
            return false;
        }
        bool Update()
        {
            return false;
        }
        bool delete()
        {
            return false;
        }
        bool Read()
        {
            return false;
        }
        bool readFirst()
        {
            return false;
        }
        bool readNext()
        {
            return false;
        }
        bool readPrev()
        {
            return false;
        }
    }
}
