// Abstract Factory is a creational design pattern that provides an interface for creating 
// families of related or dependent objects without specifying their concrete classes.

// Factory Method : Creates one product
// Abstract Factory : Creates a family of related products
// instead of only creating Payment, now we also want: IPayment, IRefund
// And we want : CreditCard Payment + CreditCard Refund, UPI Payment + UPI Refund

using System;

namespace DesignPatterns.Creational.AbstractFactory
{
    // ============================================================
    // 1️⃣ ABSTRACT PRODUCTS
    // These are interfaces for product families.
    // Every payment system will have:
    //    - Payment
    //    - Refund
    // ============================================================

    public interface IPayment
    {
        void Pay(decimal amount);
    }

    public interface IRefund
    {
        void Refund(decimal amount);
    }

    // ============================================================
    // 2️⃣ CONCRETE PRODUCTS - CREDIT CARD FAMILY
    // These belong to CreditCard factory
    // ============================================================

    public class CreditCardPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Credit Card.");
        }
    }

    public class CreditCardRefund : IRefund
    {
        public void Refund(decimal amount)
        {
            Console.WriteLine($"Refunded {amount} to Credit Card.");
        }
    }

    // ============================================================
    // 3️⃣ CONCRETE PRODUCTS - UPI FAMILY
    // These belong to UPI factory
    // ============================================================

    public class UpiPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using UPI.");
        }
    }

    public class UpiRefund : IRefund
    {
        public void Refund(decimal amount)
        {
            Console.WriteLine($"Refunded {amount} to UPI.");
        }
    }

    // ============================================================
    // 4️⃣ ABSTRACT FACTORY
    // This factory defines methods to create
    // ALL related products.
    //
    // Important:
    // It does NOT create concrete objects.
    // It only declares methods.
    // ============================================================

    public interface IPaymentFactory
    {
        IPayment CreatePayment();
        IRefund CreateRefund();
    }

    // ============================================================
    // 5️⃣ CONCRETE FACTORIES
    // Each factory creates a COMPLETE FAMILY of products.
    // ============================================================

    public class CreditCardFactory : IPaymentFactory
    {
        public IPayment CreatePayment()
        {
            return new CreditCardPayment();
        }

        public IRefund CreateRefund()
        {
            return new CreditCardRefund();
        }
    }

    public class UpiFactory : IPaymentFactory
    {
        public IPayment CreatePayment()
        {
            return new UpiPayment();
        }

        public IRefund CreateRefund()
        {
            return new UpiRefund();
        }
    }

    // ============================================================
    // 6️⃣ CLIENT
    // The client works only with interfaces.
    // It never knows about concrete classes.
    // ============================================================

    public class PaymentService
    {
        private readonly IPayment _payment;
        private readonly IRefund _refund;

        // Constructor receives factory
        public PaymentService(IPaymentFactory factory)
        {
            // Create products using factory
            _payment = factory.CreatePayment();
            _refund = factory.CreateRefund();
        }

        public void ProcessPayment(decimal amount)
        {
            _payment.Pay(amount);
        }

        public void ProcessRefund(decimal amount)
        {
            _refund.Refund(amount);
        }
    }

    // ============================================================
    // 7️⃣ DEMO RUNNER
    // ============================================================

    public class AbstractFactoryDemo
    {
        public static void Run()
        {
            // Create Credit Card family
            IPaymentFactory creditCardFactory = new CreditCardFactory();
            PaymentService creditService = new PaymentService(creditCardFactory);

            creditService.ProcessPayment(1000);
            creditService.ProcessRefund(200);

            Console.WriteLine("---------------------");

            // Create UPI family
            IPaymentFactory upiFactory = new UpiFactory();
            PaymentService upiService = new PaymentService(upiFactory);

            upiService.ProcessPayment(500);
            upiService.ProcessRefund(100);
        }
    }
}
