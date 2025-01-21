using ElevatorChallenge;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Elevator Simulation!");

        // Create a central control system with 3 elevators, 10 floors, and each elevator has a capacity of 5 passengers
        var centralControl = new CentralControlSystem(3, 10, 5);

        while (true)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Display Elevator Status");
            Console.WriteLine("2. Call Elevator");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    centralControl.DisplayStatus();
                    break;

                case "2":
                    Console.Write("Enter floor number: ");
                    int floorNumber = int.Parse(Console.ReadLine());
                    Console.Write("Enter number of passengers: ");
                    int passengers = int.Parse(Console.ReadLine());
                    centralControl.CallElevator(floorNumber, passengers);
                    break;

                case "3":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
