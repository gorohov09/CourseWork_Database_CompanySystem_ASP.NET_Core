using Company.Domain.Entities;


namespace Company.DAL
{
    public class TestData
    {
        public static IEnumerable<EmployeeEntity> EmployeeEntities =>
            new List<EmployeeEntity>
            {
                new EmployeeEntity
                {
                    LastName = "Горохов",
                    FirstName = "Андрей",
                    Patronymic = "Сергеевич",
                    Birthday = new DateTime(2002, 7, 9),
                    Email = "andrej.gorokhoff2017@yandex.ru",
                    PhoneNumber = 89961880283,
                    Salary = 90000,
                    EmployeeProjects = new List<EmployeeProjectEntity>
                    {
                        new EmployeeProjectEntity { Project = new ProjectEntity
                            {
                                Title = "Посчитать смету за сентябрь",
                                Description = "Необходимо выполнить расчет сметы №234. По вопросам обращаться к руководителю",
                                Status = Status.OPEN,
                            },
                            IsMaster = true,
                        },
                        new EmployeeProjectEntity { Project = new ProjectEntity
                            {
                                Title = "Выполнить анализ продаж",
                                Description = "Необходимо выполнить анализ продаж. По вопросам обращаться к руководителю",
                                Status = Status.OPEN,
                            }
                        },
                    }
                },
                new EmployeeEntity
                {
                    LastName = "Курочкин",
                    FirstName = "Владислав",
                    Patronymic = "Романович",
                    Birthday = new DateTime(2003, 6, 22),
                    Email = "kurochkin@yandex.ru",
                    PhoneNumber = 89563452389,
                    Salary = 20000,
                    EmployeeProjects = new List<EmployeeProjectEntity>
                    {
                        new EmployeeProjectEntity { Project = new ProjectEntity
                            {
                                Title = "Стоять на кассе",
                                Description = "Необходимо стоять на кассе",
                                Status = Status.OPEN,
                            },
                            IsMaster= true,
                        },
                    }
                },
                new EmployeeEntity
                {
                    LastName = "Аверина",
                    FirstName = "Софья",
                    Patronymic = "Андреевна",
                    Birthday = new DateTime(2002, 5, 3),
                    Email = "averina@yandex.ru",
                    PhoneNumber = 89674563921,
                    Salary = 15000,
                },
                new EmployeeEntity
                {
                    LastName = "Казачина",
                    FirstName = "Алексей",
                    Patronymic = "Дмитриевич",
                    Birthday = new DateTime(2003, 1, 13),
                    Email = "kazak@yandex.ru",
                    PhoneNumber = 89563452389,
                    Salary = 50000,
                }
            };

        public static IEnumerable<ProjectEntity> ProjectsEntities =>
            new List<ProjectEntity>
            {
                new ProjectEntity
                {
                    Title = "Решить баг в системе",
                    Description = "Необходимо решить баг в системе",
                    Status = Status.OPEN,
                },
                new ProjectEntity
                {
                    Title = "Посчитать задачу",
                    Description = "Необходимо решить баг в системе",
                    Status = Status.OPEN,
                },
                new ProjectEntity
                {
                    Title = "Выйграть игру с департаментом",
                    Description = "Необходимо решить баг в системе",
                    Status = Status.OPEN,
                },

            };
    }
}
