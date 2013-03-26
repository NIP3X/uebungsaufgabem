using System;
using System.Collections.Generic;

class Auto
{
    public string Beschreibung;
    public uint Tankkapazitaet;
    public float Tankinhalt;
    public uint Verbrauch;
    public float Tachostand;

    public Auto(string Beschreibung, uint Tankkapazitaet, float Tankinhalt, uint Verbrauch, float Tachostand)
    {
        this.Beschreibung = Beschreibung;
        this.Tankkapazitaet = Tankkapazitaet;
        this.Tankinhalt = Tankinhalt;
        this.Verbrauch = Verbrauch;
        this.Tachostand = Tachostand;
    }

    public Auto(string Beschreibung, uint Tankkapazitaet, uint Verbrauch, float Tachostand)
    {
        this.Beschreibung = Beschreibung;
        this.Tankkapazitaet = Tankkapazitaet;
        this.Tankinhalt = Tankkapazitaet;
        this.Verbrauch = Verbrauch;
        this.Tachostand = Tachostand;
    }

    public void Ausgabe()
    {
        Console.WriteLine("Typ : " + Beschreibung);
        Console.WriteLine("Tankkapazität : " + Tankkapazitaet + " l"); 
        Console.WriteLine("Tankinhalt : " + Tankinhalt + " l"); 
        Console.WriteLine("Verbrauch : " + Verbrauch + " l/100km"); 
        Console.WriteLine("Tachostand : " + Tachostand + " m"); 
    }
    
    public void Fahre(uint Meter, bool MacheAusgabe = false)
    {
        float VerbrauchMeter = Verbrauch / 100000f;
        uint GefahrendeMeter = 0;

        int MeterInkrement = 10000;
        for(int i = (int)Meter / MeterInkrement; i > 0; i--)
        {        
            
            float Teilverbrauch = VerbrauchMeter * MeterInkrement;
            Tachostand += MeterInkrement;
            Tankinhalt -= Teilverbrauch;
            GefahrendeMeter = GefahrendeMeter + (uint)MeterInkrement;

            if(MacheAusgabe)
                Console.WriteLine(Beschreibung + " : Hat nach " + GefahrendeMeter + " Metern noch " + Tankinhalt + " l im Tank.");

            // Falls das Auto liegen bleibt
            if(Tankinhalt <= 0)
            {
                float MeterUeber = Math.Abs(Tankinhalt) / VerbrauchMeter;
                Tachostand -= MeterUeber;
                Tankinhalt = 0;

                // Breche Schleife ab
                i = 0;
            }
        }
    
        uint MeterRest = Meter % 10000;
        Tankinhalt -= VerbrauchMeter * MeterRest;
        Tachostand += MeterRest;

        // Falls das Auto liegen bleibt
        if(Tankinhalt <= 0)
        {
            float MeterUeber = Math.Abs(Tankinhalt) / VerbrauchMeter;
            Tachostand -= MeterUeber;
            Tankinhalt = 0;
        }

        // Warne falls weniger als 20 Liter im Tank
        if(Tankinhalt <= 20)
        {
            Console.WriteLine("WARNUNG nur noch " + Tankinhalt + " Liter im Tank bitte Tanken !!!!");
        }
    }
}

class Register
{
    static void Main()
    {
        List<Auto> Autos = new List<Auto>();
        Autos.Add(new Auto("BMW", 40, 23, 10, 0));
        Autos.Add(new Auto("Audi", 60, 15, 10000));
        Autos.Add(new Auto("VW", 20, 5, 0));
        Autos.Add(new Auto("Opel", 35, 20, 7, 230000));
        foreach(Auto auto in Autos)
        {
            auto.Ausgabe();
            auto.Fahre(100000, true);
        }
    }
}
