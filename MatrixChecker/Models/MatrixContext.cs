using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixChecker.Models
{
    public class MatrixContext : DbContext
    {
        public DbSet<Matrix> Matrixes { get; set; }

        public MatrixContext(DbContextOptions<MatrixContext> options) : base(options)
        {
        }
    }
}
