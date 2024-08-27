using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Let’s guess!");
        Console.WriteLine("");
        wer();
    }

    public static bool menu() {
        int wahl = -1;
        while ((wahl < 0) || (wahl > 2)) {
            Console.WriteLine("Wer rät?");
            Console.WriteLine("0. Ich.");
            Console.WriteLine("1. Sie.");
            Console.WriteLine("2. Ausgang.");
            string? str = Console.ReadLine();

            try {
                wahl = Convert.ToInt32(str);
            } catch (FormatException) {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl ein.");
                wahl = -1;  
            }

            switch (wahl) {
                case 0:
                    return true;
                case 1:
                    return false;
                case 2:
                    Environment.Exit(0);
                    break;  
                default:
                    Console.WriteLine("Ungültige Auswahl. Bitte wählen Sie erneut.");
                    break;
            }
        }
        return false; 
    }

    public static void wer(){
        bool werspielt = menu(); 
    
        if (werspielt) {
            Console.Clear();
            Console.WriteLine("Bitte denken Sie an eine Zahl zwischen 0 und 99 und behalten Sie sie im Kopf.");
            Console.ReadLine();
            Console.WriteLine("Drücken Sie bitte die Taste 'G', wenn Ihre Zahl größer ist, und die Taste 'K', wenn sie kleiner ist.");
            Console.WriteLine("Wenn ich die Zahl erraten habe, drücken Sie bitte !");
        } else {
            
            ich();
        }
        derZahl();
    }

    public static void ich(){
        Random random= new Random();
        int meineZahl= random.Next(0, 100);
        int controlZahl=-1;
        Console.Clear();
        Console.WriteLine("Ok, ich habe eine Zahl ausgedacht.");
        Console.WriteLine("Jetzt raten Sie mal, welche Zahl ich mir ausgedacht habe.");
        string? controlZahlString=Console.ReadLine();
        controlZahl= Convert.ToInt32(controlZahlString);
        if (controlZahl == meineZahl) {
            Console.WriteLine("Bravo!!! "+meineZahl+ " ist die richtige Zahl!");
        }else{
            while(controlZahl != meineZahl){
                if  (controlZahl > meineZahl){
                    Console.WriteLine("Meine zahl ist kleiner. Welche Zahl ist meine?");
                    controlZahlString=Console.ReadLine();
                    controlZahl= Convert.ToInt32(controlZahlString);
                }
                else if (controlZahl < meineZahl)
                {
                    Console.WriteLine("Meine Zahl ist größer. Welche Zahl ist meine?");
                    controlZahlString=Console.ReadLine();
                    controlZahl= Convert.ToInt32(controlZahlString);
                } 
                if (controlZahl==meineZahl){
                    Console.WriteLine("Bravo, das ist die Zahl!");
                    Console.ReadLine();

                    
                }
                
            
            }
            wer();
        }
        Console.WriteLine("");
    }

    public static void derZahl(){
        int low = 0;
        int high = 99;
        int mid;

        while(low <= high){
            mid = (low + high) / 2;
            Console.WriteLine("Ist deine Zahl: " + mid + "? (Bitte geben Sie 'g', 'k' oder '!')");
            string? gOderK = Console.ReadLine();

            while(gOderK != "g" && gOderK != "k" && gOderK != "!"){
                Console.WriteLine("Etwas ist schief, bitte geben Sie 'g', 'k' oder '!':");
                gOderK = Console.ReadLine();
            }

            if (gOderK == "g"){
                low = mid + 1;
            } else if (gOderK == "k"){
                high = mid - 1;
            } else {
                Console.WriteLine("Ich habe die Zahl erraten!");
                break;
            }
        }
        wer();
    }
}
