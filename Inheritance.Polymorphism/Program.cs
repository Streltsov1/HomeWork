using System;

namespace Inheritance.Polymorphism
{
    abstract class MusicInstrument
    {
        readonly private string brand;
        public string Brand => brand;
        readonly private string sound;
        public string Sound => sound;
        public int InstrumentLength { get; set; }
        public MusicInstrument(string name, string sound, int length)
        {
            this.brand = name;
            this.sound = sound;
            InstrumentLength = length;
        }
        public abstract void MakeSound();
        public override string ToString()
        {
            return $"It is the musical instrument brand: {Brand}, length {InstrumentLength}, it is make sound {Sound}";
        }
    }
    enum GuitarType { Classic = 0, Electric, Bass}
    sealed class Guitar : MusicInstrument
    {
        public GuitarType Type { get; set; }
        public int StringsNumber { get; set; }
        private bool isDestroyed = false;
        public Guitar(int num, string name, string sound, int length, GuitarType type) : base(name, sound, length)
        {
            Type = type;
            StringsNumber = num;
        }
        public override void MakeSound()
        {
            if(!isDestroyed)
                Console.WriteLine($"Make {Type} guitar sound {base.Sound}");
            else
                Console.WriteLine("Guitar is destroyed");
        }
        public override string ToString()
        {
            return $"This is {Type} guitar {base.Brand}, number of strings {StringsNumber}, length {base.InstrumentLength}";
        }
        public void DestroyGuitar()
        {
            if (isDestroyed)
                Console.WriteLine("Guitar already destroyed");
            else
            {
                isDestroyed = true;
                Console.WriteLine($"I am destroy {Type} guitar");
            }
        }
    }
    sealed class Drum : MusicInstrument
    {
        public int RadiusOfDrum { get; set; }
        public Drum(string name, string sound, int length, int radius) : base(name,sound,length)
        {
            RadiusOfDrum = radius;
        }
        public override void MakeSound()
        {
            Console.WriteLine($"Make drum sound {base.Sound}");
        }
        public override string ToString()
        {
            return $"This is dram {base.Brand}, radius {RadiusOfDrum}";
        }
        public void HitPlates()
        {
            Console.WriteLine("I hit the plates");
        }
    }
    sealed class Synthesizer : MusicInstrument
    {
        public int NumberOfKeys { get; set; }
        public Synthesizer(string name, string sound, int length, int num) : base(name, sound, length)
        {
            NumberOfKeys = num;
        }
        public override void MakeSound()
        {
            Console.WriteLine($"Make synthesizer sound {base.Sound}");
        }
        public override string ToString()
        {
            return $"This is synthesizer {base.Brand}, number of keys {NumberOfKeys}, length {base.InstrumentLength}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Guitar guitar = new Guitar(5, "Fender", "gin", 100, GuitarType.Classic);
            Drum drum = new Drum("YAMAHA", "Boom-boom", 25, 30);
            Synthesizer synthesizer = new Synthesizer("KORG", "pin", 110, 50);
            Console.WriteLine(guitar.ToString());
            Console.WriteLine(drum.ToString());
            Console.WriteLine(synthesizer.ToString());
            guitar.MakeSound();
            drum.MakeSound();
            synthesizer.MakeSound();
        }
    }
}
