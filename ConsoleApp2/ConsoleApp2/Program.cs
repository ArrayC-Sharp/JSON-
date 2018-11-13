using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Serialization
{
    [DataContract]
    public class Dress
    {
        [DataMember]
        public string Name { get; set; }
        public string S { get; set; }
        public string CD { get; set; }
        public string G { get; set; }

        [DataMember]
        public int SZ { get; set; }
        public Dress(string name,  string color_dress, string style, string gender, int size)
        {
          
            Name = name;
            CD = color_dress;
            S = style;
            G = gender;
            SZ = size;



        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // объект для сериализации
            Dress dress1 = new Dress("Платье","Blue","Evening", "W",32);
            Dress dress2 = new Dress("Туфли", "Black", "Classic", "M", 43);
            Dress dress3 = new Dress("Шапка", "White", "Winter", "W", 30);
            Dress dress4 = new Dress("Рубашка", "Grey", "Classic", "M", 50);
            Dress dress5 = new Dress("Джинсы", "Blue", "Evening", "W", 42);
            Dress[] dr = new Dress[] { dress1, dress2, dress3, dress4, dress5 };

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Dress[]));

            using (FileStream fs = new FileStream("123.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, dr);
            }

            using (FileStream fs = new FileStream("123.json", FileMode.OpenOrCreate))
            {
                Dress[] newdr = (Dress[])jsonFormatter.ReadObject(fs);

                foreach (Dress p in newdr)
                {
                    Console.WriteLine("Имя: {0} --- Пол: {1} --- Стиль: {2} --- Цвет: {3} --- Размер: {4}", p.Name, p.G,p.S, p.CD, p.SZ);
                }
            }

            Console.ReadLine();
        }
    }
}