using System;

namespace ej2
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

            PideTarifa(out int estancia, out string tarifa);

            float coste=CalculaTarifa(estancia, tarifa);

            System.Console.WriteLine($"El coste total de la tarifa es de {coste}");

        }

        static void PideTarifa(out int estancia, out string tarifa)
        {
            bool tarifaCorrecta;
            
            
            do
            {
                System.Console.WriteLine("Introduzca la tarifa deseada");
                tarifa = Console.ReadLine();
                tarifaCorrecta = ComprobarTarifa(tarifa);
            }
            while (tarifaCorrecta == false);

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


        }

        static bool ComprobarTarifa(string tarifa)
        {
            bool tarifaCorrecta = false;
            
            if (Enum.IsDefined(typeof(Abonos), tarifa))
            {
                tarifaCorrecta = true;


                System.Console.WriteLine("Tarifa introducida correctamente");
            }
            else
            {
                System.Console.WriteLine("La tarifa introducida no es correcta, por favor, introduzcala otra vez");
            }

            return tarifaCorrecta;
        }

        static float CalculaTarifa(int estancia, string tarifa)
        {

            Abonos ValorTarifa;
            
            ValorTarifa=(Abonos)Enum.Parse(typeof(Abonos), tarifa);

            float coste=((float)ValorTarifa*estancia)/100;

            return coste;
        }
    }
}
