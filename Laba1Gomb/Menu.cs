using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1Gomb
{
    internal class Menu
    {
        private List<AVDevice> devices = new List<AVDevice>();

        public void Run()
        {
            while (true)
            {
                try
                {
                    ShowMenu();
                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        HandleChoice(choice);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: Введите корректное число!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("\n=== Меню ===");
            Console.WriteLine("1. Добавить AV устройство");
            Console.WriteLine("2. Добавить телевизор");
            Console.WriteLine("3. Добавить радиоприёмник");
            Console.WriteLine("4. Показать все устройства");
            Console.WriteLine("5. Выйти");
            Console.Write("Выберите опцию: ");
        }

        private void HandleChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddAVDevice();
                    break;
                case 2:
                    AddTelevision();
                    break;
                case 3:
                    AddRadioReceiver();
                    break;
                case 4:
                    PrintAllDevices();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ошибка: Неверный номер опции!");
                    break;
            }
        }

        private void AddAVDevice()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("--- Cоздание аудио-видео устройства ---");

                Console.Write("Введите фирму: ");
                string? firm = Console.ReadLine();

                Console.Write("Введите цену: ");
                if (!float.TryParse(Console.ReadLine(), out float price))
                {
                    Console.WriteLine("Ошибка: Некорректный формат цены");
                    return;
                }

                AVDevice device = new AVDevice(firm, price);
                devices.Add(device);
                Console.WriteLine("Аудио-видео устройство успешно добавлено!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении аудио-видео устройства:");
                Console.WriteLine(ex.Message);
            }
        }

        private void AddTelevision()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("--- Cоздание телевизора ---");

                Console.Write("Введите фирму: ");
                string? firm = Console.ReadLine();

                Console.Write("Введите цену: ");
                if (!float.TryParse(Console.ReadLine(), out float price))
                {
                    Console.WriteLine("Ошибка: Некорректный формат цены");
                    return;
                }

                Console.WriteLine("Доступные разрешения экрана:");
                foreach (TypeOfScreenResolution TOSR in Enum.GetValues(typeof(TypeOfScreenResolution)))
                    Console.WriteLine(TOSR);

                Console.Write("Введите разрешение экрана: ");
                if (!Enum.TryParse(Console.ReadLine(), true, out TypeOfScreenResolution resolution))
                {
                    Console.WriteLine("Ошибка: Некорректный формат разрешения экрана");
                    return;
                }

                Console.Write("Введите диагональ экрана (дюймы): ");
                if (!byte.TryParse(Console.ReadLine(), out byte diagonal))
                {
                    Console.WriteLine("Ошибка: Некорректный формат диагонали");
                    return;
                }

                Television tv = new Television(firm, price, resolution, diagonal);
                devices.Add(tv);
                Console.WriteLine("Телевизор успешно добавлен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении телевизора: ");
                Console.WriteLine(ex.Message);
            }
        }

        private void AddRadioReceiver()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("--- Cоздание радиоприемника ---");

                Console.Write("Введите фирму: ");
                string? firm = Console.ReadLine();

                Console.Write("Введите цену: ");
                if (!float.TryParse(Console.ReadLine(), out float price))
                {
                    Console.WriteLine("Ошибка: Некорректный формат цены");
                    return;
                }

                Console.Write("Введите модель: ");
                string? model = Console.ReadLine();

                Console.WriteLine("Доступные диапазоны работы: ");
                foreach (TypeOfOperatingRanges TOOR in Enum.GetValues(typeof(TypeOfOperatingRanges)))
                    Console.WriteLine(TOOR);
                Console.Write("Введите диапазон работы: ");
                string? rangeInput = Console.ReadLine();

                if (!Enum.TryParse(rangeInput, true, out TypeOfOperatingRanges range))
                {
                    Console.WriteLine("Ошибка: Некорректный формат диапазона работы");
                    return;
                }

                RadioReceiver radio = new RadioReceiver(firm, price, model, range);
                devices.Add(radio);
                Console.WriteLine("Радиоприёмник успешно добавлен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении радиоприёмника:");
                Console.WriteLine(ex.Message);
            }
        }

        private void PrintAllDevices()
        {
            Console.Clear();

            if (devices.Count == 0)
            {
                Console.WriteLine("Список устройств пуст.");
                return;
            }

            Console.WriteLine("\n=== Список всех устройств ===");

            int i = 1;
            foreach (var device in devices)
            {
                Console.WriteLine($"Устройство #{i}:");
                Console.WriteLine(device.Print());
                Console.WriteLine("-----------------------------");
                i++;
            }
        }
    }
}
