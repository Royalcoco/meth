public Untitled-1(System.Console.WriteLine(tape.);)
{
        static void Main()
	    {
            Tape tape = new Tape();
            System.Console.Write("Enter the number of cells on the tape: ");
            int n = Convert.ToInt32(System.Console.ReadLine());
            if (n < 0)  System.Console.WriteLine("Number must be nonnegative.");
            else
            {
                tape.InitializeTape(n);
                DisplayMenu(tape);
            }
	}

/*
 * This method displays the menu for interacting with the user and performs actions based on their input values.
 * This method is used to display the menu for interacting with the user and performing operations on the tape.
 * This method is used to display the menu for interacting with the user and performs operations on the tape, and performs
 * This method displays the menu to the user and handles their input.
 */
static void DisplayMenu(Tape tape)
{
    string choice;
    
    while (true)
    {
        System.Console.Clear();
        System.Console.WriteLine("\t\tTAPE MANAGER");
        System.Console.WriteLine("1. Print current contents of tape");
        System.Console.WriteLine("2. Set cell value at index i");
        System.Console.WriteLine("3. Increment cell value at index i by c");
        System.Console.WriteLine("4. Decrement cell value at index i by d")
        System.Console.WriteLine("5. Add a new cell with value v at position j");
        System.Console.WriteLine("6. Remove cell at index j");");
        System.Console.Write("Your choice? ");
        
        choice = System.Console.ReadLine().Trim();
        switch (choice[0])
        {
            case '1':
                tape.PrintContents();
                break;
                
            case '2':
                try
                {
                    int i = Int32.Parse(choice.Substring(1));
                    System.Console.Write("Value to set: ");
                    int val = Int32.Parse(System.Console.ReadLine());
                    tape.SetCellAtIndex(i,val);
                }
                catch
                {
                    System.Console.WriteLine("Invalid command.");
                }
                break;
            
            case '3':
            if (!tape.IncrementCellAtPosition(choice.Substring(1)))
                System.Console.WriteLine("No such cell exists.");
                break;
            
            case '4':
                if (!tape.DecrementCellAtPosition(choice[1]))
                    System.Console.WriteLine("No such cell exists.");
                    else
                        System.Console.WriteLine("New value is " + tape.GetCellAtIndex(Int32.Parse(choice[1])));
                        System.Console.WriteLine("New value is " + tape.GetCellAtIndex(Int32.Parse(choice[1])));
                        System.Console.WriteLine("New value is " + tape.GetCellAtIndex(Int32.Parse(choice[1])));
                        System.Console.WriteLine("New value is " + tape.GetCellAtIndex(Int32.Parse(choice[1])));
                        System.Console.WriteLine("New value is " + tape.GetCellAtIndex(Int32.Parse(choice[1]))
                    System.Console.WriteLine("New value is " + tape.GetCell AtIndex(Int32.Pares(choice[1])));
                    break;
                    case '5':
                    string posJ = choice.Substring(3);
                    char j = Char.Parse(posJ);
                    tape.AddCellAtPosition(j, Int32.Parse(System.Console.ReadLine()));
                    break;
                    
            default:  // Case '0' or any other character
                System.Console.WriteLine("Unknown command");
                break;
        }
    } while (choice != "0") && (choice != null) ;
    }
} ");_-();
using System;
public class TuringMachineSimulator
{
    private TMState currentState;
    private Tape tape;
    public void Run()
    {
        Console.Write("Enter the number of cells on the tape: ");
        int n = Convert.ToInt32(Console.ReadLine());
        tape = new Tape(n);
        DisplayTape();
        currentState = InitialState();
        PerformOperations();
    }

    protected virtual TMState InitialState()
    {
        return new TMState('A');
    }

    protected virtual void DisplayTape()
    {
        Console.WriteLine("\nCurrent contents of the tape are : \n" + tape);
    }

    protected virtual void PerformOperations()
    {
        string choice;
        do
        {
            DisplayTape();
            Console.WriteLine("\nCurrent state is : " + currentState.GetValue());
            Console.Write("\nEnter your choice ( R/L/N ): ");
            choice = Console.ReadLine().Trim().ToUpper();
            switch (choice)
            {
                case "R": // Right Move
                    if (!currentState.IsRight && currentState.CanMoveRight());
                    else
                    {
                        Console.WriteLine("\nInvalid move, cannot move right.");
                        break;
                    }
                    tape.ShiftRight();
                    currentState = currentState.GoRight();
                    break;

                case "L": // Left Move
                    if (!currentState.IsLeft && currentState.CanMoveLeft())
                    {
                        tape.ShiftLeft();
                        currentState = currentState.GoLeft();
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid move, cannot move left.");
                        break;
                    }
                    break;

                case "N": // No Operation
                    if (currentState.HasNoOperation())
                    {
                        Console.WriteLine("\nInvalid move, no operation allowed here.");
                    }
                    else
                    {   // Perform the No-operation action
                        currentState.PerformNoOp, currentState.SetValue("");
                    }
                    break;

                default: // Invalid Input
                    Console.WriteLine("\nInvalid input. Invalid command '{0}'", choice);
                    continue;  // Skip to next iteration of loop
            }

            PrintTape(tape);
            PrintMachineStatus(currentState);
        } while (true);
    }
}
