public class CardPayment : IPaymentProcessor
{
   public void ProcessPayment(double amount)
    {
        // Entrada: amount (el monto que recibimos)
        
        // Proceso: Algoritmo de decisión
        if (amount > 1000) 
        {
            // Salida si la condición es verdadera
            System.Console.WriteLine("Payment Rejected: Amount exceeds daily limit.");
        }
        else 
        {
            // Salida si la condición es falsa
            System.Console.WriteLine("Processing card payment of: $" + amount);
            System.Console.WriteLine("Transaction Successful!");
        }
    }
}