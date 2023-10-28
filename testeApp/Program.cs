using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace testeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            //Console.WriteLine("Hello, World!");
            //Pessoa pessoa = new PessoaFisica("1233");
            cars.Add(new Car
            {
                Brand = "Wolkswagem",
                Model = "celta",
                Price = 1000
            });
            cars.Add(new Car
            {
                Brand = "Wolkswagem",
                Model = "mulina",
                Price = 12000
            });

            cars.Add(new Car
            {
                Brand = "Ford",
                Model = "Ford Mobile",
                Price = 1200
            });
            cars.Add(new Car
            {
                Brand = "Ford",
                Model = "Ford Toro",
                Price = 2200
            });
            cars.Add(new Car
            {
                Brand = "Honda",
                Model = "Honda Fit",
                Price = 3000
            });
            cars.Add(new Car
            {
                Brand = "Honda",
                Model = "Honda Civic",
                Price = 6000
            });

            Console.WriteLine(Program.CarroCaroMarca(cars));
        }

        public static Car MostExpensiveCar(List<Car> cars)
        {
          return  cars.Where(x => x.Price == cars.Min(x => x.Price)).ToList().FirstOrDefault();
            
        }
        public static int MedioPrice(List<Car> cars)
        {
            return Convert.ToInt32(cars.Average(p => p.Price));

        }

        public static Dictionary<string, Car> CarroCaroMarca(List<Car> cars)
        {
            IList<string> marcas = new List<string>();

            Dictionary<string, Car> dicionary  = new Dictionary<string, Car>();
            foreach (var item in cars.OrderBy(x => x.Brand))
            {
                if(!marcas.Contains(item.Brand))
                    marcas.Add(item.Brand); 
            }
            ;

            foreach (var item in marcas)
            {
               var car =   cars.Where(c => c.Brand == item ).ToList();
                var priceMarca = car.Where(c => c.Price == car.Max(p => p.Price)).ToList().FirstOrDefault();
                dicionary.Add(priceMarca.Brand, priceMarca);
            }


            return dicionary;

        }




    }
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
    }
}