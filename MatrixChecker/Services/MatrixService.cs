using MatrixChecker.Models;
using MatrixChecker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixChecker.Services
{
    public class MatrixService
    {
        private MatrixRepository matrixRepository;

        public MatrixService(MatrixRepository matrixRepository)
        {
            this.matrixRepository = matrixRepository;
        }

        public void CreateMatrix(string matrix_in)
        {
            Matrix matrix = new Matrix();
            matrix.MatrixArray = matrix_in;
            matrixRepository.Create(matrix);
        }

        public List<Matrix> GetMatrixes()
        {
            return matrixRepository.GetAllElements();
        }

        public void MatrixChecker(string matrix)
        {
            string[] matrixRows = matrix.Split(
                                  new[] { "\r\n", "\r", "\n" },
                                  StringSplitOptions.None);

            List<string> rowNumbers = new List<string>();
            foreach (string row in matrixRows)
            {
                string[] nums = row.Split(new[] { " " }, StringSplitOptions.None);

                foreach (var item in nums)
                {
                    rowNumbers.Add(item);
                }
            }

            if (matrixRows.Length != rowNumbers.Count / matrixRows.Length)
            {
                throw new Exception("is not square.");
            }
            MatrixIncreaseChecker(rowNumbers);
            CreateMatrix(matrix);
        }

        public int[] MatrixIncreaseChecker(List<string> matrix)
        {
            int[] myInts = matrix.Select(int.Parse).ToArray();
            double squareRoot = Math.Sqrt(myInts.Length);
            int sqRoot = (int)squareRoot;
            int counter = 0;
            int counter1 = 0;

            for (int i = 0; i < myInts.Length - squareRoot; i++)
            {
                if (myInts[i] < myInts[i + sqRoot])
                {
                    counter++;
                }
            }

            for (int j = 0; j < myInts.Length - 1; j++)
            {
                if (j == 0 && myInts[j] < myInts[j + 1])
                {
                    counter1++;
                }

                else if ((j + 1) % sqRoot != 0 && myInts[j] < myInts[j + 1])
                {
                    counter1++;
                }
            }

            if (counter == myInts.Length - sqRoot && counter1 == myInts.Length - sqRoot)
            {
                return myInts;
            }
            else
            {
                throw new Exception("is not increasing.");
            }
        }
    }
}
