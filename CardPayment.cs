public class CardPayment : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        // Aquí simulamos el "Proceso" que menciona Joyanes
        System.Console.WriteLine("Processing card payment of: $" + amount);
        System.Console.WriteLine("Transaction Successful!"); // Salida de datos
    }
}