using System;

namespace library
{
    public class ENCategory
    {
        // Propiedades de la categoría
        public int Id { get; set; }
        public string Name { get; set; }

        // Constructor predeterminado
        public ENCategory()
        {
            Id = 0;
            Name = string.Empty;
        }

        // Constructor con parámetros
        public ENCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
