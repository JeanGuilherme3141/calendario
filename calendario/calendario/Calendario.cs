using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace Trabalho1_ProgVis
{
    public class Calendario
    {
        public byte mes { get; set; }
        public ushort ano { get; set; }

        public bool isMesValido()
        {
            if (mes > 0 && mes < 13)
            {
                return true;
            }
            else
            {
                Console.WriteLine("===================================C===================================", Color.Red);
                Console.WriteLine("FORMATO INVÁLIDO!!! USE POR EX: 1 PARA JANEIRO, 2 PARA FEVEREIRO, ETC.", Color.Red);
                Console.WriteLine("===================================C===================================", Color.Red);
                Console.WriteLine("\n");
                return false;
            }
        }
        public bool isAnoValido()
        {
            if (ano > 0 && ano < 10000)
            {
                return true;
            }
            else
            {
                Console.WriteLine("===================================C===================================", Color.Red);
                Console.WriteLine("FORMATO INVÁLIDO!!! USE POR EX: 1983,1987,2022, ETC.", Color.Red);
                Console.WriteLine("===================================C===================================", Color.Red);
                Console.WriteLine("\n");
                return false;
            }
        }

        public string GerarCalendario()
        {
            StringBuilder sb = new StringBuilder();
            DateTime iniciomes = new DateTime(ano, mes, 1);
            int dia = DateTime.DaysInMonth(ano, mes);
            int diasemana = Convert.ToInt32(iniciomes.DayOfWeek.ToString("d"));
            sb.AppendLine("      " + iniciomes.ToString(" MMMM 'de' yyyy"));
            sb.AppendLine(" =============================");
            sb.AppendLine("|  D   S   T   Q   Q   S   S  |");
            sb.AppendLine(" =============================");

            int x = 1;
            int n = 0;
            int[,] vetor = new int[6, 7];
            int diavazio = diasemana;
            sb.Append("  ");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {

                    if (n < diavazio)
                    {
                        vetor[i, j] = ' ';
                        sb.Append("    ");
                        n++;
                    }
                    else if (x <= dia)
                    {
                        vetor[i, j] = x;
                        sb.Append("" + vetor[i, j].ToString().PadLeft(2, '0') + "  ");
                        x++;
                        diasemana++;
                    }

                    if (diasemana % 7 == 0 && diasemana > 0)
                    {
                        sb.Append("\n  ");
                    }
                }
            }
            Console.Clear();
            return sb.ToString();
        }
    }
}
