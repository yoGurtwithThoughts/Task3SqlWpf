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
            public static string CreatePostion(string PositionName)
            {
                string result = "Должность имеется";
                using (ApplicationContext db = new ApplicationContext())
                {
                    bool checkISExist = db.Positions.Any(a => a.PositionName == PositionName && a.Salary == salary && a.MaxCountOfEmployees = maxCountOfEmployee);
                    if (!checkISExist)
                    {
                        db.Positions.Add(new Position
                        {
                            PositionName = PositionName,
                            Salary=salary,
                            MaxCountOfEmployees= maxCountOfEmployees,
                            DepartamentID = depotament.ID
                        }) ;
                    }
                    db.SaveChanges();
                    result = "Успешно добавлено!";
                    return result;
                }
            }

            #endregion
        }
        //#region Добавить сотрудника
        //public static string CreateEmpoloyee(string Name,string Surename, string Phone, Position position)
        //{
        //    string result = "Отдел уже существует!";
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        bool checkISExist = db.Departamentes.Any(a => a.DPName == );
        //        if (!checkISExist)
        //        {
        //            db.Departamentes.Add(new Departament { DPName = PositionName });
        //        }
        //        db.SaveChanges();
        //        result = "Успешно добавлено!";
        //        return result;
        //    }
        //}
   
        //#endregion
    }
}
    #endregion
}