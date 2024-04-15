using System;

namespace TeveControll
{
    public class Domicilio
    {
        public string calle;
        public int numero;
        public string barrio;

        public Domicilio(string calle, int numero, string barrio)
        {
            this.calle = calle;
            this.numero = numero;
            this.barrio = barrio;
        }
    }

    public class Persona
    {
        public string nombre;
        public Domicilio domicilio;

        public Persona(string nombre, Domicilio domicilio)
        {
            this.nombre = nombre;
            this.domicilio = domicilio;
        }
    }

    public class Televisor
    {
        public string marca;
        public string modelo;
        public int pulgadas;
        public bool encendido;
        public int canalActual;
        public Persona dueño;

        public Televisor(string marca, string modelo, int pulgadas, Persona dueño)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.pulgadas = pulgadas;
            this.encendido = false; // Por defecto apagado al inicializar
            this.canalActual = 1; // Por defecto canal 1 al inicializar
            this.dueño = dueño;
        }

        public int obtenerCanalActual()
        {
            return canalActual;
        }

        public bool cambiarCanal(int nuevoCanal)
        {
            if (encendido && nuevoCanal >= 1 && nuevoCanal <= 150)
            {
                canalActual = nuevoCanal;
                return true;
            }
            return false;
        }

        public bool cambiarCanal()
        {
            if (encendido)
            {
                canalActual = (canalActual % 150) + 1; // Cambiar al siguiente canal, si está en 150 vuelve al 1
                return true;
            }
            return false;
        }

        public bool verPrendido()
        {
            return encendido;
        }

        public void cambiarEstado()
        {
            encendido = !encendido;
        }
    }

    public class Test
    {
        static void Main(string[] args)
        {
            // Crear domicilio
            Domicilio domicilio = new Domicilio("Jonte", 5299, "Monte Castro");

            // Crear personas
            Persona facundo = new Persona("Facundo", domicilio);
            Persona camila = new Persona("Camila", domicilio);

            // Crear televisor
            Televisor televisor = new Televisor("Sony", "Smart TV", 55, facundo);

            // Mostrar información inicial
            Console.WriteLine($"Televisor de {televisor.dueño.nombre}");
            Console.WriteLine($"Ubicación: {televisor.dueño.domicilio.calle} {televisor.dueño.domicilio.numero}, {televisor.dueño.domicilio.barrio}");
            Console.WriteLine($"Marca: {televisor.marca}");
            Console.WriteLine($"Modelo: {televisor.modelo}");
            Console.WriteLine($"Pulgadas: {televisor.pulgadas}");

            // Facundo cambia el estado del televisor
            televisor.cambiarEstado();

            // Facundo cambia el canal
            televisor.cambiarCanal();

            // Mostrar estado actual
            Console.WriteLine($"Estado: {televisor.verPrendido()}");
            Console.WriteLine($"Canal actual: {televisor.obtenerCanalActual()}");
        }
    }
}

