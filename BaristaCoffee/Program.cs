// See https://aka.ms/new-console-template for more information

using BaristaCoffee;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Inventory inventory = new Inventory();
        Menu menu = new Menu(inventory);
        inventory.display();
        menu.display();
        bool quit = false;
        while (!quit)
        {
          
            String line = "";
            while (line.Equals(""))
            {
                try
                {
                    line = Console.ReadLine();
                }
                catch (IOException e)
                {
                    throw new Exception();
                }
            }
            char c = (char)((line.Length > 1) ? 0 : line.ToLower()[0]);
            switch (c)
            {
                // restock and redisplay inventory and menu
                case 'r':
                    inventory.restock();
                    inventory.display();
                    menu.display();
                    break;
                // quit application
                case 'q':
                    quit = true;
                    break;
                case '1':
                    menu.makeDrink(0);
                    inventory.display();
                    menu.display();
                    break;
                case '2':
                    menu.makeDrink(1);
                    inventory.display();
                    menu.display();
                    break;
                case '3':
                    menu.makeDrink(2);
                    inventory.display();
                    menu.display();
                    break;
                case '4':
                    menu.makeDrink(3);
                    inventory.display();
                    menu.display();
                    break;
                case '5':
                    menu.makeDrink(4);
                    inventory.display();
                    menu.display();
                    break;
                case '6':
                    menu.makeDrink(5);
                    inventory.display();
                    menu.display();
                    break;
                default:
                    Console.WriteLine("Invalid selection: " + line);
                    inventory.display();
                    menu.display();
                    break;
            }
        }
    }
}
