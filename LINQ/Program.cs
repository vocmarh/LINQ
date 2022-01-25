using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Pc
    {
        public string Code { get; set; }
        public string BrandName { get; set; }
        public string CPU { get; set; }
        public int CPUFrequency { get; set; }
        public int RAM { get; set; }
        public int HDD { get; set; }
        public int VRAM { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Pc> Computer = new List<Pc>()
            {
                new Pc(){ Code="100100", BrandName="Lenovo IdeaPad 3", CPU="Intel Core i3 1005G1", CPUFrequency=3400, RAM=8, HDD=128, VRAM=0, Price=38390, Quantity=45 },
                new Pc(){ Code="100101", BrandName="Ноутбук Acer Nitro 5", CPU="AMD Ryzen 7", CPUFrequency=3200, RAM=8, HDD=512, VRAM=6144, Price=107990, Quantity=5 },
                new Pc(){ Code="100102", BrandName="Gigabyte G5", CPU="Intel Core i5", CPUFrequency=2500, RAM=64, HDD=512, VRAM=6144, Price=110990, Quantity=7 },
                new Pc(){ Code="100103", BrandName="Lenovo", CPU="Intel Core i7 ", CPUFrequency=2600, RAM=16, HDD=1000, VRAM=8192, Price=209990, Quantity=2},
                new Pc(){ Code="100104", BrandName="Acer Predator Helios 300", CPU="Intel Core i5", CPUFrequency=2500, RAM=8, HDD=1000, VRAM=6144, Price=102690, Quantity=6 },
                new Pc(){ Code="100105", BrandName="Asus", CPU="AMD Ryzen 9", CPUFrequency=3100, RAM=16, HDD=1000, VRAM=4096, Price=179990, Quantity=8 },
                new Pc(){ Code="100106", BrandName="MSI GF63 Thin 10UC", CPU="Intel Core i7", CPUFrequency=2600, RAM=8, HDD=512, VRAM=4096, Price=88990, Quantity=4 },
                new Pc(){ Code="100107", BrandName="Lg", CPU="Intel 11th Generation i7", CPUFrequency=2800, RAM=16, HDD=1000, VRAM=4096, Price=178999, Quantity=40 }
            };
            Console.Write("Название процессора из представленных i3, i5, i7, Ryzen 9, Ryzen 7: ");
            string CPU = Console.ReadLine();
            List<Pc> cpu = (from c in Computer
                            where c.CPU.Contains(CPU)
                            select c).ToList();
            foreach (var c in cpu)
                Console.WriteLine($"{c.BrandName} ({c.Code}) процессор: {c.CPU} - {c.Price} ");
            Console.WriteLine("");
            Console.Write("Объем ОЗУ из представленных - 8, 16, 64: ");
            int Memory = Convert.ToInt32(Console.ReadLine());
            var memory = Computer
                .Where(r => r.RAM >= Memory)
                .ToList();
            foreach (var r in memory)
                Console.WriteLine($"{r.BrandName} ({r.Code}) размер ОЗУ: {r.RAM}Гб - {r.Price} ");
            var Sort = Computer
                .OrderBy(s => s.Price)
                .ToList();
            Console.WriteLine("");
            Console.WriteLine("Отсортированный список по стоимости:");
            foreach (var s in Sort)
                Console.WriteLine($"{s.BrandName} ({s.Code}), {s.CPU}, {s.CPUFrequency}МГц, RAM {s.RAM}Гб, HDD {s.HDD}Гб, VRAM {s.VRAM}Мб, ${s.Price}");
            var Group = from g in Computer
                         group g by g.CPU;
            Console.WriteLine("");
            Console.WriteLine("Группировка списка по типу процессора:");
            foreach (var g in Group)
            {
                foreach (var t in g)
                {
                    Console.WriteLine($"{t.BrandName} {t.CPU}");
                }
            }
            Console.WriteLine("");
            foreach (Pc память in Computer)
            {
                if (память.Price == Computer.Max(m => m.Price))
                    Console.WriteLine($"Самый дорогой компьютер: {память.BrandName} стоимостью {память.Price} ");
                if (память.Price == Computer.Min(m => m.Price))
                    Console.WriteLine($"Самый бюджетный компьютер: {память.BrandName} стоимостью {память.Price} ");
            }
            Console.WriteLine("");
            Console.WriteLine((Computer.Any(s => s.Quantity >= 30)) ? "На складе присутствует позиция с количеством больше 40" : "Отсутствует позиция с количеством больше 30");
            Console.ReadKey();
        }
    }
}