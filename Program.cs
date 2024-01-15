using System.Collections.Generic;

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
        List<ToDo> ToDos = new List<ToDo>();
        Console.WriteLine("Let's get some stuff done!");

        ToDo myTodo = new ToDo("wash clothes",false);
        ToDos.Add(myTodo);
        ToDo myTodo1 = new ToDo("dry clothes",true);
        ToDos.Add(myTodo1);
        ToDo myTodo2 = new ToDo("put clothes away",true);
        ToDos.Add(myTodo2);
        
        foreach(ToDo toDo in ToDos) {
            Console.WriteLine(toDo.ToString());
        }
    }
}