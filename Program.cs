using System.Collections.Generic;

public struct Todo
{
    public string Name;
    public Boolean Completion;

    public Todo(string name, Boolean completion)
    {
        Name = name;
        Completion = completion;
    }

    public override string ToString()
    {

        return $"Task: {Name}, Completed: {Completion}";
    }
}

public class Program
{
    public static Todo makeTodo()
    {
        Console.WriteLine("Todo name:");
        string name = "" + Console.ReadLine();
        if (name == "")
        {
            name = "No name";
        }
        Todo newTodo = new Todo(name, false);
        return newTodo;
    }

    public static void printTodos(List<Todo> Todos)
    {
        if (Todos.Count == 0)
        {
            Console.WriteLine("No todos right now.");
        }
        for (int i = 0; i < Todos.Count(); i++)
        {
            Console.WriteLine($"{i + 1}. {Todos[i]}");
        }
    }

    public static void Main()
    {
        List<Todo> Todos = new List<Todo>();
        Console.WriteLine("Let's get some stuff done!");
        string? command = "none";
        while (command != "exit")
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do? (make, print, exit)");
            command = Console.ReadLine();
            switch (command)
            {
                case "make":
                    Todos.Add(makeTodo());
                    break;
                case "print":
                    printTodos(Todos);
                    break;
                case "exit":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}