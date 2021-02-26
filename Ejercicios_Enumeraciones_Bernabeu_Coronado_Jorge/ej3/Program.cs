using System;

namespace ej3
{
    class Program
    {
            enum Abonos
        {

            QuinceDias = 70, TreintaDias = 60, FamiliasNumerosas = 50, TerceraEdad = 30, Discapacidad = 20, Juvenil = 65, Infantil = 35, Turístico = 90, Sin_Tarifa = 120

        }

        static void Main()
        {
            Console.Clear();

            Abonos tarifaEscogida=(Abonos)LeeEnum(typeof(Abonos),TextoLista(), TextoError(), out int estancia, out string tarifa);

            float coste=CalculaTarifa(estancia, tarifa);

            System.Console.WriteLine($"El coste total de la tarifa {tarifaEscogida} es de {coste}");

        }

        public static Object LeeEnum(Type tipo, string texto, string textoError, out int estancia, out string tarifa)
        {
            bool tarifaCorrecta;
            Object tarifaEscogida;
            
            do
            {
                System.Console.WriteLine($"Introduzca la tarifa deseada, las tarifas disponibles son las siguientes:\n{texto}");
                tarifa = Console.ReadLine();
                tarifaCorrecta = Enum.IsDefined(tipo, tarifa);

                if(tarifaCorrecta==false)
                {
                    System.Console.WriteLine(textoError);
                }
            }
            while (tarifaCorrecta == false);

            tarifaEscogida=Enum.Parse(tipo, tarifa);

            if (tarifa == "QuinceDias")
            {
                estancia = 15;
            }
            else if (tarifa == "TreintaDias")
            {
                estancia = 30;
            }
            else
            {
                do
                {
                    System.Console.WriteLine("Introduzca su estancia");
                    estancia = int.Parse(Console.ReadLine());

                    if(estancia < 7 || estancia > 60)
                    System.Console.WriteLine("Error al introducir la estancia, supera los minimos o maximos permitidos");

                }
                while (estancia < 7 || estancia > 60);

            }

            return tarifaEscogida;
        }

        static float CalculaTarifa(int estancia, string tarifa)
        {

            Abonos ValorTarifa;
            
            ValorTarifa=(Abonos)Enum.Parse(typeof(Abonos), tarifa);

            float coste=((float)ValorTarifa*estancia)/100;

            return coste;
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

            textoLista = Enum.GetNames(typeof(Abonos));

            foreach(string textoBusqueda in textoLista)
            {
                texto+=" "+textoBusqueda;
            }
            return texto;
        }
        
    }
}
