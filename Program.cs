using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

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
    public static bool IsTodos(List<Todo> Todos)
    {
        if (Todos.Count == 0)
        {
            Console.WriteLine("No todos right now.");
            return false;
        }
        return true;
    }

    public static int ChooseTodo(List<Todo> Todos)
    {
        for (int i = 0; i < Todos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Todos[i]}");
        }
        Console.WriteLine($"\nNumber (1-{Todos.Count}):");
        string? toEditStr = Console.ReadLine();
        bool isInt = int.TryParse(toEditStr, out int toEdit);
        bool withinRange = toEdit > 0 && toEdit <= Todos.Count;
        while (!isInt || !withinRange)
        {
            Console.WriteLine($"Please enter a postive whole number (1-{Todos.Count}):");
            toEditStr = Console.ReadLine();
            isInt = int.TryParse(toEditStr, out toEdit);
            withinRange = toEdit > 0 && toEdit <= Todos.Count;
        }
        return toEdit - 1;
    }

    public static List<Todo> EditTodos(List<Todo> Todos)
    {
        if (!IsTodos(Todos)) return Todos;
        Console.WriteLine("Choose a todo to edit.");
        int ToEdit = ChooseTodo(Todos);
        Todo todo = Todos[ToEdit];
        Console.WriteLine($"You choose '{todo.Name}'.");
        Console.WriteLine();
        Console.WriteLine("What would you like to do? (toggle, remove, rename, exit)");
        string? command = Console.ReadLine();
        switch (command)
        {
            case "toggle":
                if (todo.Completion)
                {
                    todo.Completion = false;
                    Console.WriteLine($"'{todo.Name}' is now toggled to false.");
                }
                else
                {
                    todo.Completion = true;
                    Console.WriteLine($"'{todo.Name}' is now toggled to true.");
                }
                Todos[ToEdit] = todo;
                break;
            case "remove":
                Console.WriteLine($"Are you sure you want to remove '{todo.Name}'? (Confirm with 'yes')");
                string? confirmation = Console.ReadLine();
                if (confirmation == "yes")
                {
                    Console.WriteLine($"The todo, '{todo.Name}', is now removed.");
                    Todos.Remove(todo);
                }
                else
                {
                    Console.WriteLine($"The todo, '{todo.Name}', was not deleted.");
                }
                break;
            case "rename":
                Console.WriteLine($"Write a new name for '{todo.Name}':");
                string? newName = Console.ReadLine();
                if (newName == "" || newName == null)
                {
                    Console.WriteLine($"No new name was chosen for '{todo.Name}'");
                }
                else
                {
                    Console.WriteLine($"'{todo.Name}' was successfully changed to '{newName}");
                    todo.Name = newName;
                    Todos[ToEdit] = todo;
                }
                break;
            case "exit":
                Console.WriteLine("Returning to main interface.");
                break;
            default:
                Console.WriteLine("Unknown command.");
                break;
        }
        return Todos;

    }
    public static Todo MakeTodo(string? name)
    {
        if (name == "" || name == null)
        {
            name = "No name";
        }
        Todo newTodo = new Todo(name, false);
        return newTodo;
    }

    public static void PrintTodos(List<Todo> Todos)
    {
        if (!IsTodos(Todos)) return;
        for (int i = 0; i < Todos.Count(); i++)
        {
            Console.WriteLine($"{i + 1}. {Todos[i]}");
        }
    }

    public static void Main()
    {
        List<Todo> Todos = [];
        Console.WriteLine("Let's get some stuff done!");
        string? input = "none";
        while (input != "exit")
        {
            Console.WriteLine();
            Console.WriteLine("Write a new todo or choose a command (print, edit, exit).");
            input = Console.ReadLine();
            switch (input)
            {
                case "print":
                    PrintTodos(Todos);
                    break;
                case "edit":
                    Todos = EditTodos(Todos);
                    break;
                case "exit":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Todos.Add(MakeTodo(input));
                    Console.WriteLine($"Added new todo, '{input}'!");
                    break;
            }
        }
    }
}