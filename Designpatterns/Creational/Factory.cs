namespace DesignPatterns.Creational.Factory
{
    public interface IPayment
    {
        void Pay(decimal amount);
    }

    public class CreditCardPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine("Paid using Credit Card");
        }
    }

    public class UpiPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine("Paid using UPI");
        }
    }
    public abstract class PaymentCreator
    {
        public abstract IPayment CreatePayment();

        public void ProcessPayment(decimal amount)
        {
            IPayment payment = CreatePayment();
            payment.Pay(amount);
        }
    }
    public class CreditCardPaymentCreator : PaymentCreator
    {
        public override IPayment CreatePayment()
        {
            return new CreditCardPayment();
        }
    }

    public class UpiPaymentCreator : PaymentCreator
    {
        public override IPayment CreatePayment()
        {
            return new UpiPayment();
        }
    }

   

    
    // Demo runner inside same file
    public class FactoryDemo
    {
        public static void Run()
        {
            PaymentCreator creator = new CreditCardPaymentCreator();
            creator.ProcessPayment(1000);

            creator = new UpiPaymentCreator();
            creator.ProcessPayment(500);
        }
    }
}