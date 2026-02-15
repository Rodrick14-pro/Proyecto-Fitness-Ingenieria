using System;
namespace ProfessionalPayments.Services;

public class BmiCalculator
{
    public double CalculateBmi(double weight, double height)
    {
        double bmi = weight / (height * height);
        return bmi;

    }

    public string GetClassification(double bmi)
    {
        if(bmi < 18.5) return "Underweight 🦴";
        if (bmi <= 24.9) return "Normal weight ✅";
        return "Overweight ⚠️";
    }
}