using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grafos_ED
{
    class CGrafo
    {
        private int[,] mAdyacencia;
        private int[] indegree;
        private int nodos;

        public CGrafo(int pNodos)
        {
            nodos = pNodos;

            // Realizamos el instanciameniento de la matriz de adyacencia

            mAdyacencia = new int[nodos, nodos];

            // Realizamos el instanciameniento del arreglo de indegree

            indegree = new int[nodos];

        }

        public void AdicionarAriste(int pNodoInicio, int pNodoFinal)
        {
            mAdyacencia[pNodoInicio, pNodoFinal] = 1;

        }
        public void AdicionarAriste(int pNodoInicio, int pNodoFinal, int pPeso)
        {
            mAdyacencia[pNodoInicio, pNodoFinal] = pPeso;

        }

        public void MuetraAdyacencia()
        {
            int n = 0;
            int m = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (n = 0; n < nodos; n++)
                Console.Write("\t{0}, n");

            Console.WriteLine();

            for (n = 0; n < nodos; n++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(n);
                for (m = 0; m < nodos; m++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\t{0}", mAdyacencia[n, m]);


                }

                Console.WriteLine();

            }

                           
        }

        public int ObtenAdyacencia(int pFila, int pColumna)

        {

            return mAdyacencia[pFila, pColumna];

        }

        public void CalcularIndegree()

        {
            int n = 0;
            int m = 0;

            for (n = 0; n < nodos; n++)
            {
                for (m = 0; m < nodos; m++)
                {
                    if (mAdyacencia[m, n] == 1)

                        indegree[n]++;


                }


            }


        }

        public void MostrarIndegree()

        {
            int n = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (n = 0; n < nodos; n++)
                Console.WriteLine("Nodo: {0} , {1}", n, indegree[n]);

        }

        public int EncuentraIO()
        {
            bool encontrado = false;
            int n = 0;

            for (n = 0; n < nodos; n++)

            {
                if (indegree[n] == 0)
                {
                    encontrado = true;
                    break;


                }

            }

            if (encontrado)
                return n;
            else
                return -1; // para idicar que no se ha encontrado


        }

        public void DecrementarIndegree(int pNodo)
        {
            indegree[pNodo] = -1;
            int n = 0;

            for (n = 0; n < nodos; n++)
            {
                if (mAdyacencia[pNodo, n] == 1)
                    indegree[n]--;


            }

        }

        }
    }

