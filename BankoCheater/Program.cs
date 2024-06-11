using System.Security.Cryptography.X509Certificates;

namespace BankoCheater
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string gamestate = "1Row";

            List<Plader> plates = new List<Plader>();
            plates.Add(new Plader(
                "Boris",
                new List<int> { 15, 41, 51, 71, 81 },
                new List<int> { 6, 18, 25, 34, 57 },
                new List<int> { 8, 19, 47, 59, 68 }
                ));
            plates.Add(new Plader(
                "Gustav",
                new List<int> { 1, 24, 31, 40, 70 },
                new List<int> { 7, 12, 25, 33, 87 },
                new List<int> { 19, 38, 43, 56, 67 }
                ));


            //foreach (var plateData in platesData)
            //{
            //    plates.Add(new Plader(
            //        plateData.Name,
            //        plateData.Row1,
            //        plateData.Row2,
            //        plateData.Row3
            //        ));
            //}
            DrawNumber("Please enter a number:");

            void DrawNumber(string message)
            {
                Console.WriteLine(message);
                int drawnNumber = 0;
                try
                {
                    drawnNumber = int.Parse(Console.ReadLine());
                    if (drawnNumber <= 0 || drawnNumber > 90)
                    {
                        Console.WriteLine("Number must be between 1 and 90");
                    }
                }
                catch (Exception ex)
                {
                    DrawNumber("That is not a number");
                }


                foreach (Plader p in plates) { p.RemoveDrawnNumber(drawnNumber); }

                if (gamestate == "1Row")
                {
                    foreach (Plader plade in plates)
                    {
                        if (plade.CheckForOneRow())
                        {
                            gamestate = "2Rows";
                        }
                    }
                }
                else if (gamestate == "2Rows")
                {
                    foreach (Plader plade in plates)
                    {
                        if (plade.CheckForTwoRows())
                        {
                            gamestate = "Full";
                        }
                    }
                }
                else if (gamestate == "Full")
                {
                    foreach (Plader plade in plates)
                    {
                        if (plade.CheckForFullPlate())
                        {
                            gamestate = "Done";
                            Console.WriteLine("Game is over");
                        }
                    }

                }
                if (gamestate != "Done")
                {
                    DrawNumber("Enter next number");
                }
            }
        }
        public class Plader
        {
            public string Name { get; set; }
            public List<int> Row1 { get; set; }
            public List<int> Row2 { get; set; }
            public List<int> Row3 { get; set; }

            public Plader(string name, List<int> row1, List<int> row2, List<int> row3)
            {
                this.Name = name;
                this.Row1 = row1;
                this.Row2 = row2;
                this.Row3 = row3;
            }

            public void RemoveDrawnNumber(int nummer)
            {
                Row1.Remove(nummer);
                Row2.Remove(nummer);
                Row3.Remove(nummer);
            }

            public bool CheckForOneRow()
            {
                if (Row1.Count == 0 || Row2.Count == 0 || Row3.Count == 0)
                {
                    Console.WriteLine($"One of the rows is full: {Name}");
                    return true;
                }
                else
                {
                    return false;
                }

            }
            public bool CheckForTwoRows()
            {
                if ((Row1.Count == 0 && Row2.Count == 0) || (Row1.Count == 0 && Row3.Count == 0) || (Row2.Count == 0 && Row3.Count == 0))
                {
                    Console.WriteLine($"Two of the rows is full: {Name}");
                    return true;
                }
                else
                {
                    return false;
                }

            }
            public bool CheckForFullPlate()
            {
                if (Row1.Count == 0 && Row2.Count == 0 && Row3.Count == 0)
                {
                    Console.WriteLine($"The plate is full: {Name}");
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}


