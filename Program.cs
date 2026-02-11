using System;

class Program
{
    static void Main()
    {
        // 1. Creamos el objeto (el procesador de tarjetas)
        CardPayment myProcessor = new CardPayment();

        // 2. Probamos una cantidad pequeña (Entrada de datos 1)
        Console.WriteLine("--- Test 1: Small Amount ---");
        myProcessor.ProcessPayment(250.00);

        Console.WriteLine(); // Espacio en blanco

        // 3. Probamos una cantidad que exceda el límite (Entrada de datos 2)
        Console.WriteLine("--- Test 2: Large Amount ---");
        myProcessor.ProcessPayment(1500.00);

        // 1. Instanciar (crear el objeto)
        BmiCalculator myCalculator = new BmiCalculator();

         // 2. Llamar al método para ejecutar la lógica
        myCalculator.Run();
    }
}