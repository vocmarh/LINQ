using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_lab
{
    class Pc
    {
        public string Art { get; set; }
        public string Brand { get; set; }
        public string Cpu { get; set; }
        public int CpuFrequency { get; set; }
        public int Ram { get; set; }
        public int HardVolume { get; set; }
        public int Vram { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Pc> Компьютер = new List<Pc>()
            {
                new Pc(){ Art="81WE00JWRK", Brand="Lenovo IdeaPad 3", Cpu="Intel Core i3 1005G1", CpuFrequency=3400, Ram=8, HardVolume=128, Vram=0, Price=38390, Stock=45 },
                new Pc(){ Art="NH.QBCER.002", Brand="Ноутбук Acer Nitro 5", Cpu="AMD Ryzen 7", CpuFrequency=3200, Ram=8, HardVolume=512, Vram=6144, Price=107990, Stock=5 },
                new Pc(){ Art="KC-5RU1130SH", Brand="Gigabyte G5", Cpu="Intel Core i5", CpuFrequency=2500, Ram=64, HardVolume=512, Vram=6144, Price=110990, Stock=7 },
                new Pc(){ Art="M15-7366", Brand="ALIENWARE m15 R3", Cpu="Intel Core i7 ", CpuFrequency=2600, Ram=16, HardVolume=1000, Vram=8192, Price=209990, Stock=2},
                new Pc(){ Art="NH.Q7XER.00D", Brand="Acer Predator Helios 300", Cpu="Intel Core i5", CpuFrequency=2500, Ram=8, HardVolume=1000, Vram=6144, Price=102690, Stock=6 },
                new Pc(){ Art="GA401QEC-K2064T", Brand="ROG Zephyrus G14", Cpu="AMD Ryzen 9", CpuFrequency=3100, Ram=16, HardVolume=1000, Vram=4096, Price=179990, Stock=8 },
                new Pc(){ Art="GF63 10UC-420RU", Brand="MSI GF63 Thin 10UC", Cpu="Intel Core i7", CpuFrequency=2600, Ram=8, HardVolume=512, Vram=4096, Price=88990, Stock=4 },
                new Pc(){ Art="17Z90P-G.AH79R", Brand="Lп Gram", Cpu="Intel 11th Generation i7", CpuFrequency=2800, Ram=16, HardVolume=1000, Vram=4096, Price=178999, Stock=10 }
            };
            Console.Write("Название процессора из представленных i3, i5, i7, Ryzen 9, Ryzen 7: ");
            string CPU = Console.ReadLine().ToLower();
            List<Pc> cpu = (from c in Компьютер
                            where c.Cpu.ToLower().Contains(CPU)
                            select c).ToList();
            foreach (var c in cpu)
                Console.WriteLine($"{c.Brand} ({c.Art}) процессор: {c.Cpu} - {c.Price} руб");
            Console.WriteLine("------------------------------------------------------------------");
            Console.Write("Объем ОЗУ из представленных - 8, 16, 64: ");
            int Оперативка = Convert.ToInt32(Console.ReadLine());
            var оперативка = Компьютер
                .Where(r => r.Ram >= Оперативка)
                .ToList();
            foreach (var r in оперативка)
                Console.WriteLine($"{r.Brand} ({r.Art}) размер ОЗУ: {r.Ram}Гб - {r.Price} руб.");
            var Сортировка = Компьютер
                .OrderBy(s => s.Price)
                .ToList();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Отсортированный список по стоимости:");
            foreach (var s in Сортировка)
                Console.WriteLine($"{s.Brand} ({s.Art}), {s.Cpu}, {s.CpuFrequency}МГц, RAM {s.Ram}Гб, HDD {s.HardVolume}Гб, VRAM {s.Vram}Мб, ${s.Price}");
            var Группа = from g in Компьютер
                         group g by g.Cpu;
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Группировка списка по типу процессора:");
            foreach (var g in Группа)
            {
                foreach (var t in g)
                {
                    Console.WriteLine($"{t.Brand} {t.Cpu}");
                }
            }
            Console.WriteLine("------------------------------------------------------------------");
            foreach (Pc память in Компьютер)
            {
                if (память.Price == Компьютер.Max(m => m.Price))
                    Console.WriteLine($"Самый дорогой компьютер: {память.Brand} стоимостью {память.Price} руб.");
                if (память.Price == Компьютер.Min(m => m.Price))
                    Console.WriteLine($"Самый бюджетный компьютер: {память.Brand} стоимостью {память.Price} руб.");
            }
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine((Компьютер.Any(s => s.Stock >= 30)) ? "Позиция с количеством более 30" : "Отсутствует позиция с количеством больше 30");
            Console.ReadKey();
        }
    }
}