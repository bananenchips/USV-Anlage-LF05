using System;

class program { 
    static double volt = 12;
    static string? answer = "";
    static double gesamtlast = 0;
    static double l = 0;
    static double components = 0;
    static double Leistung = 0;
    static double netzspannung = 230; // Volt
    static int counter = 0; 
    static void Main(string[] args)
        {
            Menu();
            Choose();
        }

    static void Menu() {
        Console.Clear();
        Console.WriteLine("Willkommen im Menü");
        Console.WriteLine("Besitzen sie schon eine eingerichtete USV und wollen die");
        Console.WriteLine("Autonomie Zeit berechnen ? ");
        Console.WriteLine();
        Console.WriteLine("Oder wollen sie sich eine USV-Anlage anschaffen und wissen noch nicht");
        Console.WriteLine("wie viel Leistung diese haben muss?");
        Console.WriteLine("Wählen sie mit den Pfeiltasten aus und bestätigen sie mit der Enter Taste");
    }
    static void Choose()
    {
        string pressed = "";
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Berechnung der Autonomie Zeit");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Berechnung der erforderlichen Leistung");
        Console.WriteLine("Was ist die Autonomie Zeit und wie wird sie berechnet ?");
        ConsoleKey key = Console.ReadKey().Key;
        pressed = key.ToString();

        while (pressed != "Enter")
        {
            

            if (pressed == "UpArrow")
            {
                counter--;
            }
            else if (pressed == "DownArrow")
            {
                counter++;
            }
            counter = counter > 2 ? 0 : counter = counter;
            counter = counter < 0 ? 2 : counter = counter;
            switch (counter)
            {
                case 0:
                    Menu();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Berechnung der Autonomie Zeit");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Berechnung der erforderlichen Leistung");
                    Console.WriteLine("Was ist die Autonomie Zeit und wie wird sie berechnet ?");
                break;

                case 1:
                    Menu();
                    Console.WriteLine("Berechnung der Autonomie Zeit");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Berechnung der erforderlichen Leistung");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Was ist die Autonomie Zeit und wie wird sie berechnet ?");
                break;

                case 2:
                    Menu();
                    Console.WriteLine("Berechnung der Autonomie Zeit");
                    Console.WriteLine("Berechnung der erforderlichen Leistung");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Was ist die Autonomie Zeit und wie wird sie berechnet ?");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            pressed = "";
            key = Console.ReadKey().Key;
            pressed = key.ToString();

        }

        switch (counter)
        {
            case 0: Time(); break;
            case 1: Leistungsbedarf(); break;
            case 2: Help();  break;
        }
    }

    static void Help()
    {
        Console.Clear(); 
        Console.WriteLine("Text einfügen");
    }

    static void Back()
    {

    }
   static void Time()
    {
        Components();
        Autonomie();
    }
    static void Components() {
         Console.WriteLine("Wie viele Komponenten sind an das System angeschlossen?");
         components = Convert.ToDouble(Console.ReadLine());
         Console.WriteLine("Haben alle Komponenten die selbe Leistungsaufnahme?");
         Console.WriteLine("Y/N");
         try { answer = Console.ReadLine(); }
         catch { return; }
         if (answer == "y" || answer  == "Y" )
         {
             Console.WriteLine("geben sie die Leistungsaufnahme der Geräte in Volt Ampere (VA) an");
             Leistung = Convert.ToDouble(Console.ReadLine());
             gesamtlast = Leistung * components; 
         }else if (answer == "N" || answer == "n" ) {
             componentLoop();
         }else { return; }
        
    }

    static void componentLoop() {
        for(int i = 1; i <= components; i++)
            {
             //   Console.Clear();
                Console.WriteLine("Geben sie die: "+ i + "te Leistungsaufnahme ein" );
                Leistung = Convert.ToDouble(Console.ReadLine());
                l = l + Leistung;
                 
        }
            gesamtlast = l;    
    }
    static double Autonomie()
    {
        Console.WriteLine("geben sie die Anzahl der Akkus an.");
        double Akkus = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Geben sie die Spannung der Akkus in Volt an.(insgesamt)");
        try { 
         volt = Convert.ToDouble(Console.ReadLine());
        }catch(Exception)
        {
            return 0 ;
        }
        double AkkuVolt = Akkus * volt;
        Console.WriteLine("Geben sie die Kapazität der Akkus in Amperestunden (Ah) an");
        double capacity = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Bis zu viel % sollen die Akkus genutzt werden?");
        double percent = Convert.ToDouble(Console.ReadLine());
        percent = (100 - percent)/100;
        if (percent <= 0) percent = 1; 
        Console.WriteLine(AkkuVolt+ " * " +  capacity * percent + " / " + gesamtlast);
        Console.WriteLine($" Der Akku hält für: {AkkuVolt * capacity * percent / gesamtlast} Stunden");
        return AkkuVolt * capacity * percent / gesamtlast;
    }   
    
    static void Leistungsbedarf()
    {
        Components(); // Gesamtlast wird errechnet

        double Wirklast = gesamtlast * 0.65; // Umrechnung von VA nach Watt
        Wirklast = Wirklast * 1.3;           // Leistungsreserve wird verrechnet
        double Scheinleistung = Wirklast * 1.55;

        Console.WriteLine($"Die USV benötigt mindestens ${Wirklast} W bzw. ${Scheinleistung} VA");
    }
}
