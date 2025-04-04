internal class Program
{
    // variable to control the program loop
    public static bool isRunning = true;

    private static void Main(string[] args)
    {
        while (isRunning)
        {
            // Display the menu and handle user input
            HandleMenu(); 
        }
    }
    
    //
    // HandleMenu()
    //
    // Draws the main menu on the screen and handles user input.
    //
    private static void HandleMenu()
    {
        Console.WriteLine("- -- MENU -- -");
        Console.WriteLine("1. Ungdom eller pensionär");
        Console.WriteLine("2. Biopris sällskap");
        Console.WriteLine("0. Avsluta");
        Console.Write("Välj ett alternativ: ");

        string menuChosen = Console.ReadLine();
        Console.WriteLine();

        switch (menuChosen)
        {
            case "0":
                // Exit the program
                Console.WriteLine("Avslutar programmet...");
                isRunning = false;
                break;
            case "1":
                // Calculate ticket price for individual
                TicketPrice();
                break;
            case "2":
                // Calculate ticket price for group
                GroupTicketPrice();
                break;
            default:
                // Handle invalid input
                Console.WriteLine("Felaktikt val, försök igen.");
                break;
        }
    }

    //
    // TicketPrice()
    //
    // Handles the logic for calculating the ticket price based on age.
    //
    private static void TicketPrice()
    {
        Console.WriteLine("Köp av biobiljett:");
        Console.Write("Ange ålder: ");

        int age = int.Parse(Console.ReadLine());
        Console.WriteLine();

        string typeOfPrice = age < 20 ? "Ungdomspris" : age > 64 ? "Pensionärspris" : "Standardpris";

        Console.WriteLine($"{typeOfPrice}: {CalculatePrice(age)}kr");

        Console.WriteLine();
    }

    //
    // GroupTicketPrice()
    //
    // Handles the logic for calculating the total ticket price for a group.
    //
    private static void GroupTicketPrice()
    {
        Console.WriteLine("Köp av biobiljetter till sällskap:");
        Console.WriteLine();
        Console.Write("Ange antal biljetter: ");

        int numberOfTickets = int.Parse(Console.ReadLine());
        
        int totalPrice = 0;

        for (int i = 0; i < numberOfTickets; i++)
        {
            Console.Write($"Ange ålder för besökare {i + 1}: ");
            int age = int.Parse(Console.ReadLine());

            totalPrice += CalculatePrice(age);
        }
        Console.WriteLine();
        Console.WriteLine($"Totalt pris för {numberOfTickets} biljetter: {totalPrice}kr");
        Console.WriteLine();
    }

    //
    // CalculatePrice(int age)
    //
    // Calculates the ticket price based on age.
    // Returns the price as an integer.
    //
    private static int CalculatePrice(int age)
    {
        // Ungdomspris
        if (age < 20)
        {
            return 80;
        }
        // Pensionärspris
        else if (age > 64)
        {
            return 90;
        }
        // Standardpris
        else
        {
            return 120;
        }
    }
}