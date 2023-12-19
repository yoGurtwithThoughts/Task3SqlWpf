using NetTopologySuite.GeometriesGraph;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task3SqlWpf.MVVM.Core.DataWorker1;

namespace Task3SqlWpf.MVVM.Model.Data
{
    class Departament
    {
        public int ID { get; set; }
        public string DPName { get; set; }
        public List<Position> Positions { get; set; }
        [NotMapped]
        public List<Position> DPPositions {
            get {
                return DataWorker.GetAllPositionsByDepartament();
            }
        }
    }
}
