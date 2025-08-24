using System;
using System.Collections.Generic;

namespace csharp_odev_manav
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Manav Projesi

            // Haldeki ürünler (Meyve ve Sebze)
            Dictionary<string, double> halMeyve = new Dictionary<string, double>()
            {
                {"Elma", 50},
                {"Armut", 40},
                {"Muz", 30},
                {"Portakal", 60},
                {"Çilek", 20}
            };

            Dictionary<string, double> halSebze = new Dictionary<string, double>()
            {
                {"Domates", 70},
                {"Salatalık", 50},
                {"Biber", 40},
                {"Patlıcan", 30},
                {"Soğan", 100}
            };

            // Manav, haldeki ürünleri alıyor (kopya oluşturuyoruz)
            Dictionary<string, double> manavMeyve = new Dictionary<string, double>(halMeyve);
            Dictionary<string, double> manavSebze = new Dictionary<string, double>(halSebze);

            // Müşterinin aldığı ürünler
            Dictionary<string, double> musteriSepet = new Dictionary<string, double>();

            Console.WriteLine("=== MANAV OTOMASYONU ===");

            bool devam = true;

            while (devam)
            {
                Console.Write("Meyve mi Sebze mi? (Çıkış için: hayır): ");
                string secim = Console.ReadLine().Trim().ToLower();

                if (secim == "hayır")
                {
                    devam = false;
                    Console.WriteLine("Afiyet olsun! Alışverişiniz tamamlandı.");
                    break;
                }
                else if (secim == "meyve")
                {
                    Console.WriteLine("\nManavdaki Meyveler:");
                    foreach (var urun in manavMeyve)
                    {
                        Console.WriteLine($"{urun.Key} - {urun.Value} kg");
                    }

                    Console.Write("Hangi meyveyi almak istersiniz?: ");
                    string urunAdi = Console.ReadLine();

                    if (manavMeyve.ContainsKey(urunAdi))
                    {
                        Console.Write("Kaç kilo almak istiyorsunuz?: ");
                        double kilo = Convert.ToDouble(Console.ReadLine());

                        if (manavMeyve[urunAdi] >= kilo)
                        {
                            manavMeyve[urunAdi] -= kilo;

                            if (musteriSepet.ContainsKey(urunAdi))
                                musteriSepet[urunAdi] += kilo;
                            else
                                musteriSepet.Add(urunAdi, kilo);

                            Console.WriteLine($"{urunAdi} - {kilo} kg sepete eklendi.");

                            if (manavMeyve[urunAdi] == 0)
                            {
                                manavMeyve.Remove(urunAdi);
                                Console.WriteLine($"{urunAdi} manavdan tükendi!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yeterli stok yok!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bu meyve mevcut değil!");
                    }
                }
                else if (secim == "sebze")
                {
                    Console.WriteLine("\nManavdaki Sebzeler:");
                    foreach (var urun in manavSebze)
                    {
                        Console.WriteLine($"{urun.Key} - {urun.Value} kg");
                    }

                    Console.Write("Hangi sebzeyi almak istersiniz?: ");
                    string urunAdi = Console.ReadLine();

                    if (manavSebze.ContainsKey(urunAdi))
                    {
                        Console.Write("Kaç kilo almak istiyorsunuz?: ");
                        double kilo = Convert.ToDouble(Console.ReadLine());

                        if (manavSebze[urunAdi] >= kilo)
                        {
                            manavSebze[urunAdi] -= kilo;

                            if (musteriSepet.ContainsKey(urunAdi))
                                musteriSepet[urunAdi] += kilo;
                            else
                                musteriSepet.Add(urunAdi, kilo);

                            Console.WriteLine($"{urunAdi} - {kilo} kg sepete eklendi.");

                            if (manavSebze[urunAdi] == 0)
                            {
                                manavSebze.Remove(urunAdi);
                                Console.WriteLine($"{urunAdi} manavdan tükendi!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yeterli stok yok!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bu sebze mevcut değil!");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim!");
                }

                Console.WriteLine("\nBaşka bir arzunuz var mı? (evet/hayır)");
                string cevap = Console.ReadLine().Trim().ToLower();
                if (cevap == "hayır")
                {
                    devam = false;
                }
            }

            // Müşterinin aldığı ürünleri yazdır
            Console.WriteLine("\n=== MÜŞTERİ SEPETİ ===");
            foreach (var item in musteriSepet)
            {
                Console.WriteLine($"{item.Key} - {item.Value} kg");
            }

            Console.WriteLine("Teşekkürler! İyi günler :)");

            #endregion
        }
    }
}
