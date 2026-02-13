using System;
using ProfessionalPayments.Models;   // Para encontrar la interfaz
using ProfessionalPayments.Services; // Para encontrar CardPayment y BmiCalculator

class Program
{
    static void Main()
    {
        bool showMenu = true;

        while (showMenu)
        {
            Console.Clear(); // Limpiador de pantalla
            Console.WriteLine("=== FITNESS PROJECT MAIN MENU ===");
            Console.WriteLine("1. Card Payment Processor");
            Console.WriteLine("2. BMI Calculator");
            Console.WriteLine("3. Exit");
            Console.Write("\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                Console.WriteLine("Loading Payments...");
                // 1. Creamos el objeto (el procesador de tarjetas)
                CardPayment myProcessor = new CardPayment();

                // 2. Probamos una cantidad pequeña (Entrada de datos 1)
                Console.WriteLine("--- Test 1: Small Amount ---");
                myProcessor.ProcessPayment(250.00);

                Console.WriteLine(); // Espacio en blanco

                // 3. Probamos una cantidad que exceda el límite (Entrada de datos 2)
                Console.WriteLine("--- Test 2: Large Amount ---");
                myProcessor.ProcessPayment(1500.00);

                Console.WriteLine("\nPress Enter to return to the Main Menu...");
                Console.ReadLine();
                break;
                
                case "2":
                Console.WriteLine("Loading Fitness...");

                Console.WriteLine(); // Espacio en blanco

                // 1. Instanciar (crear el objeto)
                BmiCalculator myCalculator = new BmiCalculator();

                // 2. Llamar al método para ejecutar la lógica
                myCalculator.Run();
                Console.WriteLine("\nPress Enter to return to the Main Menu...");
                Console.ReadLine();
                break;

                case "3":
                showMenu = false;
                break;

                default:
                Console.WriteLine("Invalid option. Press Enter to try again");
                Console.ReadLine();
                break;
            }
        }
        

    }
}