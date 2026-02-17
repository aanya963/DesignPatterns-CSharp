using System;

namespace DesignPatterns.Creational.Factory
{
    /*
     ============================================================
     FACTORY METHOD DESIGN PATTERN
     ============================================================

     Intent:
     --------
     Define an interface for creating an object,
     but let subclasses decide which class to instantiate.

     In simple words:
     We move object creation to subclasses.

     Why?
     -----
     So the client code is NOT tightly coupled to concrete classes.

     Instead of:
         new CreditCardPayment()
         new UpiPayment()

     We use:
         PaymentCreator creator = new CreditCardPaymentCreator();
         creator.ProcessPayment(1000);

     This makes the system extensible and loosely coupled.
    */

    // ============================================================
    // 1️⃣ PRODUCT INTERFACE
    // ============================================================
    // This is the common abstraction.
    // Client code depends only on this interface.
    public interface IPayment
    {
        void Pay(decimal amount);
    }

    // ============================================================
    // 2️⃣ CONCRETE PRODUCTS
    // ============================================================

    // Concrete implementation 1
    public class CreditCardPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Credit Card");
        }
    }

    // Concrete implementation 2
    public class UpiPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using UPI");
        }
    }

    // ============================================================
    // 3️⃣ CREATOR (ABSTRACT CLASS)
    // ============================================================
    /*
        This is the core of Factory Method pattern.

        It declares a factory method:
            CreatePayment()

        But DOES NOT implement it.

        It also defines a method:
            ProcessPayment()

        ProcessPayment uses CreatePayment() internally.

        This is important:

        The creator does not know which concrete payment
        it is working with.

        It only works with IPayment abstraction.
    */
    public abstract class PaymentCreator
    {
        // Factory Method (to be implemented by subclasses)
        public abstract IPayment CreatePayment();

        // Business logic method
        // This method uses the factory method internally
        public void ProcessPayment(decimal amount)
        {
            // Instead of "new Something()"
            // we call the factory method.
            IPayment payment = CreatePayment();

            payment.Pay(amount);
        }
    }

    // ============================================================
    // 4️⃣ CONCRETE CREATORS
    // ============================================================

    /*
        Each subclass decides WHICH object to create.

        This is the key idea of Factory Method pattern:
        "Subclass decides which product to instantiate"
    */

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

    // ============================================================
    // 5️⃣ CLIENT
    // ============================================================
    /*
        Client depends only on PaymentCreator.

        It does NOT use:
            new CreditCardPayment()
            new UpiPayment()

        So if tomorrow we add:
            WalletPayment
            NetBankingPayment

        We don't modify existing logic.
        We just create new Creator class.
    */
    public class FactoryDemo
    {
        public static void Run()
        {
            // Using Credit Card
            PaymentCreator creator = new CreditCardPaymentCreator();
            creator.ProcessPayment(1000);

            // Switching to UPI
            creator = new UpiPaymentCreator();
            creator.ProcessPayment(400);
        }
    }
}
