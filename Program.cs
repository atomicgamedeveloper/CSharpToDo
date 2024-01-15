using System;
public struct ToDo {
    public string Name;
    public Boolean Completion;
    
    public ToDo(string name, Boolean completion) {
        Name = name;
        Completion = completion;
    }

    public override string ToString()
    {
        
        return $"Task: {Name}, Completed: {Completion}";
    }
}

public class Program {
    public static void Main() {
        Console.WriteLine("Let's get some stuff done!");
        ToDo myTodo = new ToDo("My very first todo",false);
        Console.WriteLine(myTodo.ToString());
    }
}