using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
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
                using (ApplicationContext db = new ApplicationContext()) 
                { return db.Positions.ToList(); }

            }
            #region Все сотрудники
            public static List<Employee> GetAllEmployees()
            {
                using (ApplicationContext db = new ApplicationContext()) 
                { return db.Employees.ToList(); }

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
            public static string CreatePostion(string positionName, decimal salary, int countMaxOfEmployees, Departament departament)
            {
                string result = "Должность имеется";
                using (ApplicationContext db = new ApplicationContext())
                {
                    bool checkISExist = db.Positions.Any(a => a.PositionName == positionName && a.Salary == salary && a.MaxCountOfEmployees == countMaxOfEmployees);
                    if (!checkISExist)
                    {
                        db.Positions.Add(new Position
                        {
                            PositionName = positionName,
                            Salary = salary,
                            MaxCountOfEmployees = countMaxOfEmployees,
                            DepartamentID = departament.ID
                        });
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
                bool checkISExist = db.Employees.Any(a => a.Name == name && a.Surename == surename && a.Phone == phone);
                if (!checkISExist)
                {
                    db.Employees.Add(new Employee {
                        Name = name,
                        Surename = surename,
                        Phone = phone,
                        PositionId = position.ID });
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
        #region Удалить должность 
        public static string DeletePosition(Position position)
        {
            string result = "Нет такой должности!";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Positions.Remove(position);
                db.SaveChanges();
                result = $"Должность {position.PositionName} удалена";

            }
            return result;
        }
        #endregion
        #region Редактировать сотрудника
        public static string EditEmployee(Employee employeeNm, string newName, string newSur, string newPhone,Position nposition )
        {
            string result = "Такого работника нет!";
            using (ApplicationContext db = new ApplicationContext())
            {
                Employee employee = db.Employees.FirstOrDefault(e => e.Id == employeeNm.Id);
                if (employee != null) 
                {
                    employee.Name= newName;
                    employee.Surename= newSur;
                    employee.Phone= newPhone;
                    employee.PositionId= nposition.ID;
                    db.SaveChanges();
                    result = $"Информация поменялась";
                }
            }
            return result;
        }

        #endregion
        #region Редактировать должность
        public  static string EditPosition(Position posName, string newPositionN, decimal newSalary,int newMaxEmp,Departament deprtN) 
        {
            string result = "Нет такой должности";
            using (ApplicationContext db = new ApplicationContext())
            {
                Position position = db.Positions.FirstOrDefault(f=> f.ID == posName.ID);
                if (position != null)
                {
                    position.PositionName= newPositionN;
                    position.Salary= newSalary;
                    position.MaxCountOfEmployees= newMaxEmp;
                    position.DepartamentID= deprtN.ID;
                    db.SaveChanges();
                    result = "$Должность изменена";
                }
            }
            return result;
        }

        #endregion
        #region Вычислю по ID
        public static Position GetPositionByID(int id)
        {
            using (ApplicationContext db = new ApplicationContext()) { return db.Positions.FirstOrDefault(p => p.ID == id); }
        }
        public static Departament GetDepartamentById(int id) 
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Departamentes.FirstOrDefault(d => d.ID == id);
            }
        }
       public static List<Employee> GetAllEmployeesByPositionID(int id)
        {
           using (ApplicationContext db = new ApplicationContext())
            {
                List<Employee> employees = (from employee in GetAllEmployees()
                                            where employee.PositionID == id
                                            select employee).ToList();
                return employees;
            }
        }
       
         public static List<Position> GetAllPositionsByDepartament(int id) 
            {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Position> positions=(from position in GetAllPositions()
                                          where position.DepartamentID == id
                                          select position).ToList();
                return positions;
            }

        }
        #endregion
    }


}
#endregion