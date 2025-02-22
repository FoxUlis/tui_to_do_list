using System.Reflection;



namespace TodoProgram
{
    class TodoTask
    {
        public string task_title {get; set;}
        public string task_description {get; set;}
        public int task_id {get; set;}
    }

    class TodoProgram
    {
        static List<TodoTask> todo_task_list = new List<TodoTask>();

        static int nextID = 1;

        static void Main()
        {
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
                        ViewTask();
                        break;
                    case "2":
                        AddTask();
                        break;
                    case "3":
                        RemoveTask();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Такого варианта ответа нет, попробуйте снова");
                        break;

                }                
            }
        }

        static void ViewTask()
        {
            if (todo_task_list.Count >= 0)
            {
                foreach (var new_todo_task in todo_task_list)
                {
                    Console.WriteLine($"Номер задачи: {new_todo_task.task_id}");
                    Console.WriteLine($"Название задачи: {new_todo_task.task_title}");
                    Console.WriteLine($"Описание задачи: {new_todo_task.task_description}");
                }
            }
            else 
            {
                Console.WriteLine("Нет задач");
            }
        }


        static void AddTask()
        {
            Console.WriteLine("Введите название задачи:");
            string title = Console.ReadLine();

            Console.WriteLine("Введите описание задачи: ");
            string description = Console.ReadLine();

            TodoTask new_todo_task = new TodoTask
            {   
                task_id = nextID++,
                task_title = title,
                task_description = description,
            };

            todo_task_list.Add(new_todo_task);

            Console.WriteLine("Задача добавлена");
        }

        static void RemoveTask()
        {
            ViewTask();

            if (todo_task_list.Count > 0)
            {
                Console.WriteLine("Введите ID задачи для удаления");

                if (int.TryParse(Console.ReadLine(), out int task_id))
                {
                    TodoTask taskToRemove = todo_task_list.FirstOrDefault(t => t.task_id == task_id);
                    if (taskToRemove != null)
                    {
                        todo_task_list.Remove(taskToRemove);
                        Console.WriteLine("Задача удалена");
                    }
                    else
                    {
                        Console.WriteLine("Задачи с таким ID не существует");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ID задачи");
                }
            }
        }
    }
}

