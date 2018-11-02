using MatrixChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixChecker.Repositories
{
    public class MatrixRepository
    {
        private MatrixContext matrixContext;

        public MatrixRepository(MatrixContext matrixContext)
        {
            this.matrixContext = matrixContext;
        }

        public void Create(Matrix elements)
        {
            matrixContext.Add(elements);
            matrixContext.SaveChanges();
        }

        public List<Matrix> GetAllElements()
        {
            return matrixContext.Matrixes.ToList();
        }
    }
}
