using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bead_teszt
{
    public class Eloadas
    {
        private bool[,] foglalasok;

        public Eloadas(int sorokSzama, int helyekSzama)
        {
            if (sorokSzama <= 0 || helyekSzama <= 0)
            {
                throw new ArgumentException("A sorok és helyek száma nem lehet 0 vagy annál kisebb!");
            }

            foglalasok = new bool[sorokSzama, helyekSzama];
        }

        public bool Lefoglal()
        {
            for (int sor = 0; sor < foglalasok.GetLength(0); sor++)
            {
                for (int hely = 0; hely < foglalasok.GetLength(1); hely++)
                {
                    if (!foglalasok[sor, hely])
                    {
                        foglalasok[sor, hely] = true;
                        return true;
                    }
                }
            }

            return false;
        }

        public int GetSzabadHelyek()
        {
            int szabadHelyek = 0;

            for (int sor = 0; sor < foglalasok.GetLength(0); sor++)
            {
                for (int hely = 0; hely < foglalasok.GetLength(1); hely++)
                {
                    if (!foglalasok[sor, hely])
                    {
                        szabadHelyek++;
                    }
                }
            }

            return szabadHelyek;
        }

        public bool GetTeli()
        {
            for (int sor = 0; sor < foglalasok.GetLength(0); sor++)
            {
                for (int hely = 0; hely < foglalasok.GetLength(1); hely++)
                {
                    if (!foglalasok[sor, hely])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool Foglalt(int sorSzam, int helySzam)
        {
            if (sorSzam <= 0 || sorSzam > foglalasok.GetLength(0) ||
                helySzam <= 0 || helySzam > foglalasok.GetLength(1))
            {
                throw new ArgumentException("Érvénytelen sor- és helyszám!");
            }

            return foglalasok[sorSzam - 1, helySzam - 1];
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Példa használat
            Eloadas eloadas = new Eloadas(5, 10);

            Console.WriteLine("Szabad helyek: {0}", eloadas.GetSzabadHelyek());

            eloadas.Lefoglal();
            eloadas.Lefoglal();

            Console.WriteLine("Szabad helyek: {0}", eloadas.GetSzabadHelyek());
            Console.WriteLine("Tele van az előadás? {0}", eloadas.GetTeli());

            Console.WriteLine("A 2. sor 3. helye foglalt? {0}", eloadas.Foglalt(2, 3));
        }
    }
}
