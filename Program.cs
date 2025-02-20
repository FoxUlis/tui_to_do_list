var tasks = new List<string>();
var tasks_title = new List<string>();


while(true)
{
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine("Выберите действие и введите его номер");
    Console.WriteLine("1. Смотреть задачи");
    Console.WriteLine("2. Добавить задачи");
    Console.WriteLine("3. Удалить задачи");
    Console.WriteLine("4. Выйти");
    Console.WriteLine("-----------------------------------------");


    switch (Console.ReadLine())
    {
        case "1":
            ViewTask(tasks, tasks_title);
            break;
        
        case "2":
            AddTask(tasks, tasks_title);
            break;

        case "3":
            RemoveTask(tasks, tasks_title);
            break;

        case "4":
            return;

        default:
            Console.WriteLine("Такого варианта нет, попробуйте снова");
            break;

    }
}

void ViewTask(List<string> tasks, List<string>? tasks_title)
{
    if (tasks.Count > 0)
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{tasks_title[i]}\n {tasks[i]}");
        }
    }
    else
    {
        Console.WriteLine("Нет задач");
    }

}

void AddTask(List<string>? tasks, List<string>? tasks_title)
{
    Console.WriteLine("Введите название задачи:");
    string? task_title = Console.ReadLine();

    Console.WriteLine("Введите описание задачи: ");
    string? task = Console.ReadLine();

    tasks_title.Add(task_title);
    tasks.Add(task);
    

    Console.WriteLine("Задача добавлена");
}

void RemoveTask(List<string>? tasks, List<string>? tasks_title)
{
    ViewTask(tasks, tasks_title);

    if (tasks.Count > 0)
    {
        Console.WriteLine("Введите номер задачи для удаления");
        if(int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Задача удалена");
        }
        else
        {
            Console.WriteLine("Неверный номер задачи");
        }
        
    }


}

