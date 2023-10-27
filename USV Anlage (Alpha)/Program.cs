using System;
using System.IO.Pipes;

class program { 

    // Ein Kommentar um Git auszuprobieren 
    static double volt = 12;
    static string? answer = "";
    static double gesamtlast = 0;
    static double l = 0;
    static double components = 0;
    static double Leistung = 0;
    static void Main(string[] args)
        {
            Components();
            Autonom();
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
    static double Autonom()
    {
        Console.WriteLine("geben sie die Anzahl der Akkus an.");
        double Akkus = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Geben sie die Spannung der Akkus in Volt an.");
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
        Console.WriteLine(AkkuVolt * capacity * percent / gesamtlast);
        return AkkuVolt * capacity * percent / gesamtlast;
    }   
    
}
