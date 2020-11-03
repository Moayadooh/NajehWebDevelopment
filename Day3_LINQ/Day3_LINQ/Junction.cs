using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_LINQ
{
    class Junction
    {
        public int CourseID { get; set; } // Insert
        public int StudentID { get; set; } // Insert

        public Student Student { get; set; } // Read & Build Relation
        public Course Course { get; set; } // Read & Build Relation

        public List<Junction> GetJunctions()
        {

            return new List<Junction>
            {
                new Junction {CourseID= 10,StudentID=100 },
                new Junction {CourseID= 10,StudentID=101 },
                new Junction {CourseID= 10,StudentID=104 },
                new Junction {CourseID= 11,StudentID=104 },
                new Junction {CourseID= 11,StudentID=100 },
                new Junction {CourseID= 11,StudentID=103 },
                new Junction {CourseID= 12,StudentID=100 },
                new Junction {CourseID= 13,StudentID=100 },
                new Junction {CourseID= 13,StudentID=101 },
                new Junction {CourseID= 13,StudentID=102 },
                new Junction {CourseID= 13,StudentID=103 },
                new Junction {CourseID= 13,StudentID=104 },
                new Junction {CourseID= 14,StudentID=102 },
                new Junction {CourseID= 14,StudentID=103 },
            };
        }

    }
}
