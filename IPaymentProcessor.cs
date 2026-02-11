// Este es nuestro contrato universal para pagos
public interface IPaymentProcessor 
{
    // El método para procesar un monto (amount)
    void ProcessPayment(double amount);
}