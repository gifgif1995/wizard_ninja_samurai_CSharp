using System;
namespace wizard_ninja_samurai{
    public class Human{
        public string Name;
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public Human(string person){
            Name = person;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Health = 100;
        }
        public Human(string player, int str, int intel, int dex, int hp){
            Name = player;
            Strength = str;
            Intelligence =intel;
            Dexterity = dex;
            Health = hp;
        }
        public void attack(object obj){
            Human enemy = obj as Human;
            if(enemy == null){
                Console.WriteLine("Attack Failed");
            }
            else{
                enemy.Health -= Strength * 5;
            }
        }
    }
    public class Wizard : Human{
        public Wizard(string person) : base (person){
            Name = person;
            Intelligence = 25;
            Health = 50;
        }
        public void Heal(object wizard){
            Wizard self = wizard as Wizard;
            if(self == null){
                Console.WriteLine("Sorry, Can only heal Wizard, Heal has failed");
            }
            else{
                self.Health += 10 * Intelligence;
            }
        }
        public void axe(object obj){
            Human enemy = obj as Human;
            Random rand = new Random();
            int attack = rand.Next(20,51);
            enemy.Health -= attack;
        }
    }
    public class Ninja : Human{
        public Ninja(string person) : base (person){
            Name = person;
            Dexterity = 175;
        }
        public void Steal(object obj){
            Ninja self = obj as Ninja;
            if(self == null){
                Health += 10;
            }
            else{
                Console.WriteLine("Failed attack");
            }
        }
        public void punch(){
            Health -= 15;
        }
    }
    public class Samurai : Human{
        public Samurai(string person) : base (person){
            Name = person;
            Health = 200;
        }
        public void burn(object obj){
            Human enemy = obj as Human;
            if (enemy.Health < 50){
                enemy.Health = 0;
            }
        }
        public void Meditate(){
            Health = 200;
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            Human Ryan = new Human("Ryan");
            Wizard Potter = new Wizard("Potter");
            Samurai Chan = new Samurai("Chan");
            Ninja Tucker = new Ninja("Tucker");
            Console.WriteLine($"Name: {Potter.Name}");
            Console.WriteLine($"Health: {Potter.Health}");
            Console.WriteLine($"Strength: {Potter.Strength}");

            Tucker.Steal(Potter);
            Tucker.punch();
            Console.WriteLine($"Name: {Tucker.Name}");
            Console.WriteLine($"Health: {Tucker.Health}");
            Console.WriteLine($"Dexterity: {Tucker.Dexterity}");
            Console.WriteLine($"Chan Health: {Chan.Health}");

            Potter.axe(Chan);
            Console.WriteLine($"Chan Health: {Chan.Health}");
            Ryan.attack(Potter);
            Console.WriteLine($"Potter Health: {Potter.Health}");
            Chan.burn(Potter);
            Console.WriteLine($"Potter Health: {Potter.Health}");
            Chan.Meditate();
            Console.WriteLine($"Chan Health: {Chan.Health}");
            Potter.Heal(Potter);
            Console.WriteLine($"Potter Health: {Potter.Health}");
        }
    }
}