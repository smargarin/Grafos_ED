using System;
using System.Collections.Generic;

namespace Grafos_ED
{
    class Program
    {
        static void Main(string[] args)
        {
            int inicio = 0;
            int final = 0;
            int distancia = 0;
            int n = 0;
            int cantNodos = 7;
            string dato = "";
            int actual = 0;
            int columna = 0;

            CGrafo miGrafo = new CGrafo(cantNodos);

            miGrafo.AdicionarAriste(0, 1, 2);
            miGrafo.AdicionarAriste(0, 3, 1);
            miGrafo.AdicionarAriste(1, 3, 3);
            miGrafo.AdicionarAriste(1, 4, 10);
            miGrafo.AdicionarAriste(2, 0, 4);
            miGrafo.AdicionarAriste(2, 5, 5);
            miGrafo.AdicionarAriste(3, 2, 2);
            miGrafo.AdicionarAriste(3, 4, 2);
            miGrafo.AdicionarAriste(3, 5, 8);
            miGrafo.AdicionarAriste(3, 6, 4);
            miGrafo.AdicionarAriste(4, 6, 6);
            miGrafo.AdicionarAriste(6, 5, 1);

            miGrafo.MuetraAdyacencia();

            Console.WriteLine("Ingrese el indice del nodo de inicio");
            dato = Console.ReadLine();
            inicio = Convert.ToInt32(dato);

            Console.WriteLine("Ingrese el indice del nodo final");
            dato = Console.ReadLine();
            final = Convert.ToInt32(dato);


            // Crear la tabla
            // 0 - Visitado
            // 1 - Distancia
            // 2 - Previo

            int[,] tabla = new int[cantNodos, 3];

            // Se inicializa la tabla

            for (n = 0; n < cantNodos; n++)
            {
                tabla[n, 0] = 0;
                tabla[n, 1] = int.MaxValue;
                tabla[n, 2] = 0;


            }

            tabla[inicio, 1] = 0;

            MostrarTabla(tabla);

            actual = inicio;

            do
            {
                tabla[actual, 0] = 1;

                for (columna = 0; columna < cantNodos; columna++)
                {
                    if (miGrafo.ObtenAdyacencia(actual, columna) != 0)
                    {
                        distancia = miGrafo.ObtenAdyacencia(actual, columna) + tabla[actual, 1];
                        if (distancia < tabla[columna, 1])
                        {
                            tabla[columna, 1] = distancia;

                            tabla[columna, 2] = actual;

                        }

                    }

                }

                int indiceMenor = -1;
                int distanciaMenor = int.MaxValue;

                for (int x = 0; x < cantNodos; x++)

                {

                    if (tabla[x, 1] < distanciaMenor && tabla[x, 0] == 0)
                    {
                        indiceMenor = x;
                        distanciaMenor = tabla[x, 1];

                    }


                }

                actual = indiceMenor;

            }

            while (actual != -1);

            MostrarTabla(tabla);

            List<int> ruta = new List<int>();


            int nodo = final;

            while (nodo != inicio)
            {
                ruta.Add(nodo);
                ruta.Reverse();

                foreach (int posicion in ruta)
                    Console.Write("{0}->", posicion);

                Console.WriteLine();



            }
        }

            public static void MostrarTabla(int[,] pTabla)
            {

            int n = 0;

            for (n = 0; n < pTabla.GetLength(0); n++)

            {
                Console.WriteLine("{0}-> {1}\t{2}\t{3}", n, pTabla[n, 0], pTabla[n, 1], pTabla[n, 2]);


            }

            Console.WriteLine("------------");


            }

        }
    }



         
    
    


    







