using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3SqlWpf.MVVM.Model.Data;

namespace Task3SqlWpf.MVVM.Core
{
    class DataWorker1
    {
        public static class DataWorker
        {
            #region Посмотреть все отделы 
            public static List<Departament> GetAllDepartamets()
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return db.Departamentes.ToList();
                }
            }
            #endregion
            #region Все должности
            public static List<Position> GetAllPositions()
            {
                using (ApplicationContext db = new ApplicationContext()) { return db.Positions.ToList(); }

            }
            #region Все сотрудники
            public static List<Employee> GetAllEmployees()
            {
                using (ApplicationContext db = new ApplicationContext()) { return db.Employees.ToList(); }

            }
            #endregion
            #region Добавить новый отдел
            public static string CreateDepartament(string departamenName)
            {
                string result = "Отдел уже существует!";
                using (ApplicationContext db = new ApplicationContext())
                {
                    bool checkISExist = db.Departamentes.Any(a => a.DPName == departamenName);
                    if (!checkISExist)
                    {
                        db.Departamentes.Add(new Departament { DPName = departamenName });
                    }
                    db.SaveChanges();
                    result = "Успешно добавлено!";
                    return result;
                }
            }
            #endregion
            #region Добавить Должность
            public static string CreatePostion(string positionName,decimal salary,int countMaxOfEmployees,Departament departament)
            {
                string result = "Должность имеется";
                using (ApplicationContext db = new ApplicationContext())
                {
                    bool checkISExist = db.Positions.Any(a => a.PositionName==positionName && a.Salary==salary && a.MaxCountOfEmployees== countMaxOfEmployees);
                    if (!checkISExist)
                    {
                        db.Positions.Add(new Position
                        {
                            PositionName = positionName,
                            Salary = salary,
                            MaxCountOfEmployees= countMaxOfEmployees,
                            DepartamentID = departament.ID
                        }) ;
                    }
                    db.SaveChanges();
                    result = "Успешно добавлено!";
                    return result;
                }
            }

            #endregion
        }
        #region Добавить сотрудника
        public static string CreateEmpoloyee(string name, string surename, string phone, Position position)
        {
            string result = "Сотрудник уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkISExist = db.Employees.Any(a => a.Name == name  && a.Surename == surename &&a.Phone==phone );
                if (!checkISExist)
                {
                    db.Employees.Add(new Employee{ 
                    Name=name,
                    Surename=surename,
                    Phone=phone,
                    PositionId=position.ID});
                }
                db.SaveChanges();
                result = "Успешно добавлено!";
                return result;
            }
        }

        #endregion
        #region Удалить отдел 
        public static string DeleteDepartament(Departament departament)
        {
            string result = "Нет такого отдела!";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Departamentes.Remove(departament);
                db.SaveChanges();
                result = $"Отдел {departament.DPName} удален";

              }
            return result;
        }
        #endregion
        #region Удалить сотрудника 
        public static string DeleteEmploy(Employee employ)
        {
            string result = "Нет такого отдела!";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Employees.Remove(employ);
                db.SaveChanges();
                result = $"Отдел {employ.Name} удален";

            }
            return result;
        }
        #endregion
    }
    #region Удалить должность 
    public static string DeletePositio(Position position)
    {
        string result = "Нет такой должности!";
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Positions.Remove(position);
            db.SaveChanges();
            result = $"Отдел {position.PositionName} удален";

        }
        return result;
    }
    #endregion

}
#endregion
