using System;

namespace ej5
{
    class Program
    {
        enum Colores : byte
        {

           Azul = 0b_0000_0000, 
           Blanco = 0b_0000_0001,
           Negro = 0b_0000_0010,
           Morado = 0b_0000_0100,
           Amarillo = 0b_0000_1000,
           Rojo = 0b_0001_000,
           Marron = 0b_0010_0000,
           None = 0b_0100_0000,

        }

        static void Main()
        {
            Console.Clear();

            Menu();

        }

        static void Menu()
        {
            int seleccion;
            Colores? colorEscogido=null;
            do
            {
            System.Console.WriteLine("Seleccione la opcion que desea realizar\n[1] Añadir uno o mas colores.\n[2] Eliminar un color.\n[3] Mostrar los colores elegidos.\n[4] Salir.");
            seleccion=int.Parse(Console.ReadLine());

            switch (seleccion)
            {   
                case 1:
                colorEscogido=(Colores)LeeEnum(typeof(Colores),TextoLista(), TextoError());
                break;

                case 2:
                QuitarColor(colorEscogido);
                break;

                case 3:

                break;

                case 4:
                SalirAplicacion();
                break;
                default:
                System.Console.WriteLine("La opcion seleccionada no es válida, por favor, seleccione otra");
                break;
            }
            }
            while(seleccion!=1 && seleccion!=2 && seleccion!=3 && seleccion!=4);
        }

        public static Object LeeEnum(Type tipo, string texto, string textoError)
        {
            bool colorCorrecto;
            Object colorEscogido;
            string color;
            do
            {
                System.Console.WriteLine($"Introduzca el color deseado, los colores disponibles son los siguientes:\n{texto}");
                color = Console.ReadLine();
                colorCorrecto = Enum.IsDefined(tipo, color);

                if(colorCorrecto==false)
                {
                    System.Console.WriteLine(textoError);
                }
            }
            while (colorCorrecto == false);

            colorEscogido=Enum.Parse(tipo, color);

           

            return colorEscogido;
        }

        public static Object QuitarColor(Object colores)
        {
            string colorAQuitar="";
            bool colorAQuitarCorrecto;
            Object quitarColor;
            do{

            
            System.Console.WriteLine("Introduzca el color a quitar");
            colorAQuitar=Console.ReadLine();

            colorAQuitarCorrecto= Enum.IsDefined(typeof(Colores), colorAQuitar);

            if(colorAQuitarCorrecto)
            {
                quitarColor=Enum.Parse(typeof(Colores), colorAQuitar);

                System.Console.WriteLine("Quitando color...");
            }

            }
            while(!colorAQuitarCorrecto);
            return colores;
        }
        static string TextoError()
        {
            string textoError="Lo sentimos el valor introducido no esta en la lista";
            return textoError;
        }
        
        static string TextoLista()
        {
            string[] textoLista;
            string texto="";

            textoLista = Enum.GetNames(typeof(Colores));

            foreach(string textoBusqueda in textoLista)
            {
                texto+=" "+textoBusqueda;
            }
            return texto;
        }

        static void SalirAplicacion()
        {
            System.Console.WriteLine("Saliendo del programa...");
        }
    }
}
