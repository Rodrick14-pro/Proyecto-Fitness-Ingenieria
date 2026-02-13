
using System;
namespace ProfessionalPayments.Services;

public class BmiCalculator
{
    public void Run()
    {
        Console.WriteLine("--- Fitness Project: BMI Calculator ---");

        // 1. Entrada de datos (Input)
        Console.Write("Enter your weight (kg): ");
        double weight = double.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter your height (m): ");
        double height = double.Parse(Console.ReadLine() ?? "0");

        // 2. Proceso (Lógica de Joyanes)
        double bmi = weight / (height * height);

        // 3. Salida (Output)
        Console.WriteLine("Your BMI is: " + bmi.ToString("F2")); // F2 es para 2 decimales

        if (bmi <= 16)
        {
            Console.Write("Classification: Severe Thinness");
        }
        else if (bmi <= 17)
        {
            Console.Write("Classification: Moderate Thinness");
        }
        else if (bmi <= 18.5)
        {
            Console.Write("Classification: Moderate Thinness");
        }
        else if (bmi <= 25)
        {
            Console.Write("Classification: Normal");
        }
        else 
        {
            Console.Write("Classification: FAKING OBESO");
        }

    }
}