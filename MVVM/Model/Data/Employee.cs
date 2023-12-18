using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task3SqlWpf.MVVM.Core.DataWorker1;

namespace Task3SqlWpf.MVVM.Model.Data
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public PhoneAttribute Phone{ get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        [NotMapped] public Position EmployeePos { get {
                return DataWorker.GetPositionByID(PositionId);
                    }
        }

    }
}
