using System.Reflection;
using System.Reflection.Metadata;
using System.Text.Json;


namespace TodoProgram
{
    class TodoTask
    {
        public string task_title {get; set;}
        public string task_description {get; set;}
        public int task_id {get; set;}
        public int task_priority {get; set;}
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
                Console.WriteLine("4. Экспортировать задачи");
                Console.WriteLine("5. Импортировать задачи");
                Console.WriteLine("6. Выйти");
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
                        ExportToJson("tasks.json");
                        break;
                    case "5":
                        todo_task_list = ImportedFromJson("tasks.json");
                        break;
                    case "6":
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
                    Console.WriteLine($"Приоритет задачи: {new_todo_task.task_priority}");
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

            Console.WriteLine("Введите приоритет задачи: ");
            int task_priority = Convert.ToInt16(Console.ReadLine());

            TodoTask new_todo_task = new TodoTask
            {   
                task_id = nextID++,
                task_title = title,
                task_description = description,
                task_priority = task_priority
            };

            todo_task_list.Add(new_todo_task);

            todo_task_list = todo_task_list.OrderBy(t => t.task_priority).ToList();

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

        static void ExportToJson(string filePath)
        {
            string json_todo_list = JsonSerializer.Serialize(todo_task_list, new JsonSerializerOptions{WriteIndented = true});

            File.WriteAllText(filePath, json_todo_list);
            Console.WriteLine("Задачи экспортированы");
        }

        static List<TodoTask> ImportedFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден");
                return new List<TodoTask>();
            }

            string json_todo_list = File.ReadAllText(filePath);

            List<TodoTask> importedTodoList = JsonSerializer.Deserialize<List<TodoTask>>(json_todo_list);

            if (importedTodoList.Any())
            {
                nextID = importedTodoList.Max(t => t.task_id) + 1;
            }

            Console.WriteLine("Задачи импортированы");
            return importedTodoList;
       }

    }
}

