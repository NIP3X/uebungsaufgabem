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
        Console.WriteLine("Tankkapazität : " + Tankkapazitaet); 
        Console.WriteLine("Tankinhalt : " + Tankinhalt); 
        Console.WriteLine("Verbrauch : " + Verbrauch); 
        Console.WriteLine("Tachostand : " + Tachostand + "m"); 
    }
    
    public void Fahre(uint Meter, bool MacheAusgabe = false)
    {
        float VerbrauchMeter = Verbrauch / 100000f;
        float Gesamtverbrauch = VerbrauchMeter * Meter;
        float VerbleibendeLiter = Tankinhalt - Gesamtverbrauch;
        Tachostand += Meter;
        Tankinhalt = VerbleibendeLiter;








        // Falls das Auto liegen bleibt
        if(VerbleibendeLiter <= 0)
        {
            float MeterUeber = Math.Abs(VerbleibendeLiter) / VerbrauchMeter;
            Tachostand -= MeterUeber;
            Tankinhalt = 0;
        }

        // Warne falls weniger als 20 Liter im Tank
        if(Tankinhalt <= 20)
        {
            Console.WriteLine("WARUNG nur noch " + Tankinhalt + " Liter im Tank bitte Tanken !!!!");
        }
    }
}

class Register
{
    static void Main()
    {
        List<Auto> Autos = new List<Auto>();
        Autos.Add(new Auto("BMW", 40, 23, 4, 1000));
        foreach(Auto auto in Autos)
        {
            auto.Ausgabe();
            auto.Fahre(3000);
            auto.Ausgabe();
            auto.Fahre(700000);
            auto.Ausgabe();
        }
    }
}
