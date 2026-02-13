using System;

namespace DesignPatterns.Behavioral.Strategy
{
    public interface IPaymentStrategy
    {
        void Pay(int amount);
    }
    public class UPIPaymentStrategy : IPaymentStrategy
    {
        public void Pay(int amount)
        {
            Console.WriteLine($"Paid {amount} using UPI");
        }
    }

    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public void Pay(int amount)
        {
            Console.WriteLine($"Paid {amount} using Credit Card");
        }
    }
    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy;

        public PaymentContext(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void Pay(int amount)
        {
            _paymentStrategy.Pay(amount);
        }
    }

    public class StrategyDemo
    {
        public static void Run()
        {
            PaymentContext context = new PaymentContext(new UPIPaymentStrategy());

            context.Pay(500);
        }
    }
}
