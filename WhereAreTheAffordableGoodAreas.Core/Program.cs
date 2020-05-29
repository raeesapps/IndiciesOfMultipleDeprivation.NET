using System;

namespace WhereAreTheAffordableGoodAreas
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrap = new Bootstrap("//Users/raees/Documents/area_data/imd.csv");
            bootstrap.Start();
        }
    }
}