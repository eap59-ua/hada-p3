using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {
        
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        public string Code { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public int Category { get; set; }
        public DateTime CreationDate { get; set; }

        // methods
        ENProduct()
        {
            ;
        }
        ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            ;
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
