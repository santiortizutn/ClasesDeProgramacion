﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 10";

            string cad = "*";
            int contador;
            int medida;
            int contadorDos;

            Console.Write("\nIngrese altura de la piramide: ");
            medida = int.Parse(Console.ReadLine());

            for (contadorDos = 0; contadorDos < medida; contadorDos++)
            {
                for (contador = 0; contador < contadorDos; contador++)
                {
                    cad = cad + "\t**";
                }

                cad = cad + "\n";
            }

            Console.Write(cad);
            Console.ReadLine();
        }
    }
}
