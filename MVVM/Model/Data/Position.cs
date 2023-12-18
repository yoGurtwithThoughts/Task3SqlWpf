using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task3SqlWpf.MVVM.Core.DataWorker1;

namespace Task3SqlWpf.MVVM.Model.Data
{
    class Position
    {
        public int ID { get; set; }
        public string PositionName { get; set; }
        public decimal Salary { get; set; }
        public int MaxCountOfEmployees { get; set; }
        
        public List<Employee> Employees { get; set; }
        public int DepartamentID { get; set; }
        public virtual Departament Departament { get; set; }
        [NotMapped]
        public Departament PositionDepartament { get { return DataWorker.GetDepartamentByID(DepartamentID); } }
        [NotMapped]
        public List<Employee> PositionEmployees
        {
            get
            {
                return DataWorker.GetAllEmployeesByPositionID(ID);
            }
        }
    }
}
