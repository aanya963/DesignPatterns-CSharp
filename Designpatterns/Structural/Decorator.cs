namespace DesignPatterns.Structural
{
    
    //Interface Component : defines a common interface for Mario and all power-ups decorators.
    public interface ICharacter
    {
        string GetAbilities();
    }
    // Concrete component : Basic Mario character with no power-ups
    public class Mario : ICharacter{
        public string GetAbilities()
        {
            return "Mario";
        }
    }
    //Abstract Decorator: CharacterDecorator "is-a" Character and "has-a" Character.
    public abstract class CharacterDecorator : ICharacter
    {
        protected ICharacter character; 
        public CharacterDecorator(ICharacter character)
        {
            this.character=character;
        }
        public virtual string GetAbilities()
        {
            return character.GetAbilities();
        }
    }
    //Concrete Decorator:Height-Increasing power-up
    public class HeightUp : CharacterDecorator
    {
        public HeightUp(ICharacter character): base(character){}
        public override string GetAbilities()
        {
            return character.GetAbilities() + " with HeightUp";
        }
    }
    // Concrete Decorator: Gun Power-Up
    public class GunPowerUp : CharacterDecorator
    {
        public GunPowerUp(ICharacter character) : base(character){}
        public override string GetAbilities()
        {
            return character.GetAbilities() + "with Gun";
        }
    }

    //Concrete Decorator:Star-up
    public class StarPowerUp : CharacterDecorator
    {
        public StarPowerUp(ICharacter character) : base(character){}
        public override string GetAbilities()
        {
            return character.GetAbilities() + "with star power up";
        }
        ~StarPowerUp()
        {
            Console.WriteLine("Destroying StarPowerUp Decorator");
        }
    }

    public class DecoratorDemo
    {
        public static void Run()
        {
            ICharacter mario = new Mario();
            Console.WriteLine("Basic Character: " + mario.GetAbilities());

            mario = new HeightUp(mario);
            Console.WriteLine("After HeightUp: " + mario.GetAbilities());

            mario = new GunPowerUp(mario);
            Console.WriteLine("After GunPowerUp: " + mario.GetAbilities());

            mario = new StarPowerUp(mario);
            Console.WriteLine("After StarPowerUp: " + mario.GetAbilities());
            

            //mario is StarPowerUp 
            //so, mario.GetAbilities -> StarPowerUp.GetAbilities()
            //which returns character.GetAbilities() + "with star power"
            //character inside StarPowerUp = GunPowerUp object
            //so, now it calls, GunPowerUp.GetAbilities()
            //now inside GunPowerUp, it return character.GetAbilities() + " with Gun";
            //character = HeightUp object
            //HeightUp.GetAbilities()
            //return character.GetAbilities() + " with HeightUp";
            //Its character = Mario.
            //Mario.GetAbilities()
            //return "Mario"

            //Now the Return chain builds back 
            //HeightUp reveives : "Mario", Returns : ""Mario with HeightUp"
            //GunPowerUp receives: "Mario with HeightUp", returns : "Mario with HeightUp with Gun"
            //StarPowerUp receives: "Mario with HeightUp with Gun", returns: "Mario with HeightUp with Gun with Star Power (Limited Time)"

        }
    }
}