using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixChecker.Models
{
    public class Matrix
    {
        public int ID { get; set; }
        public string MatrixArray { get; set; }
        public DateTime CreatedDate { get; set; }

        //public Matrix()
        //{
        //    this.CreatedDate = DateTime.UtcNow;
        //}
    }
}