using System;

namespace library
{
    public class ENCategory
    {
        // Atributos privados de la categoría
        private int _id;
        private string _name;

        // Propiedades públicas para acceder a los atributos
        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }

        // Constructor predeterminado
        public ENCategory()
        {
            // Inicializar los atributos
            _id = 0;
            _name = string.Empty;
        }

        // Constructor con parámetros
        public ENCategory(int id, string name)
        {
            // Asignar los valores proporcionados a los atributos
            _id = id;
            _name = name;
        }

        // Otros métodos según sea necesario
    }
}
