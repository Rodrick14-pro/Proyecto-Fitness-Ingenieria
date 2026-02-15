using System;
using System.IO;
using System.Globalization;
using ProfessionalPayments.Models;   // Para encontrar la interfaz
using ProfessionalPayments.Services; // Para encontrar CardPayment y BmiCalculator

class Program
{
    static void Main()
    {
        bool showMenu = true;

        BmiHistoryService historyService = new BmiHistoryService();

        while (showMenu)
        {
            Console.Clear(); // Limpiador de pantalla
            Console.WriteLine("=== FITNESS PROJECT MAIN MENU ===");
            Console.WriteLine("1. Card Payment Processor");
            Console.WriteLine("2. BMI Calculator");
            Console.WriteLine("3. View History");
            Console.WriteLine("4. Exit");
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

                bool repeatBmi = true;

                do
                {
                    Console.Clear(); // ✨ Limpiamos la pantalla al empezar cada nuevo cálculo
                    Console.WriteLine("=== BMI CALCULATOR SERVICE ===");
    
                    double w;
                    Console.Write("Enter weight (kg): ");

                    string inputW = Console.ReadLine() ?? "";
                    inputW = inputW.Replace(',', '.');  //"Limpiamos" la entrada: cambiamos comas por puntos

                    // Mientras el TryParse sea FALSO (usamos el símbolo ! para negar), repetimos
                    while (!double.TryParse(inputW, CultureInfo.InvariantCulture, out w) || w <= 0)
                    {
                        Console.WriteLine("❌ Input must be a positive number.");
                        Console.Write("Enter weight (kg): ");

                        inputW = Console.ReadLine() ?? "";
                        inputW = inputW.Replace(',', '.');
                        
                    }

                    double h;
                    Console.Write("Enter height (m): ");
                    
                    string inputH = Console.ReadLine() ?? "";
                    inputH = inputH.Replace(',', '.');  //"Limpiamos" la entrada: cambiamos comas por puntos

                    while(!double.TryParse(inputH, out h) ||  h <= 0)
                    {
                        Console.WriteLine("❌ Input must be a positive number.");     
                        Console.Write("Enter height (m): ");

                        inputH = Console.ReadLine() ?? "";
                        inputH = inputH.Replace(',', '.');

                    }

                    // 2. Llamar al método para ejecutar la lógica
                    double myResult = myCalculator.CalculateBmi(w, h);

                    Console.WriteLine($"The returned BMI is: {myResult:F2}");

                    // Lógica de clasificación
                    string clasification = myCalculator.GetClassification(myResult);
                    Console.WriteLine(clasification);
                    Console.WriteLine("");
                    

                    historyService.SaveRecord(myResult, clasification);
                    
                    Console.WriteLine("\n✅ Calculation saved to history.");

                    Console.Write("\nWould you like to perform another calculation? (s/n): ");
                    string response = Console.ReadLine()?.ToLower() ?? "";

                    if (response != "s") 
                    {
                        repeatBmi = false;
                    }

                } while(repeatBmi);
                
                Console.WriteLine("\nPress Enter to return to the Main Menu...");
                Console.ReadLine();
                break;

                case "3":
                Console.Clear();
                Console.WriteLine("=== BMI HISTORY ===\n");
    
                // Llamamos al servicio para obtener el texto
                string history = historyService.GetHistory();
                Console.WriteLine(history);
                
                
                Console.WriteLine("\nDo you want to delete the history? S/N");
                string delete = Console.ReadLine()?.ToLower() ?? "";

                if(delete == "s")
                    {
                        string mensaje = historyService.ClearHistory();
                        Console.WriteLine(mensaje); // ¡Ahora sí lo vemos!
                    }

                Console.WriteLine("\nPress Enter to return to menu...");
                Console.ReadLine();
                break;
                
                case "4":
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