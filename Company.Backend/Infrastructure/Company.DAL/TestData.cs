﻿using Company.Domain.Entities;


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
                            }
                        },
                        new EmployeeProjectEntity { Project = new ProjectEntity
                            {
                                Title = "Выполнить анализ продаж",
                                Description = "Необходимо выполнить анализ продаж. По вопросам обращаться к руководителю",
                                Status = Status.OPEN,
                            }
                        },
                    }
                }
            };
    }
}