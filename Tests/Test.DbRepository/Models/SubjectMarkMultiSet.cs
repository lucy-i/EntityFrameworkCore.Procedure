﻿using EntityFrameworkCore.Procedure;
using EntityFrameworkCore.Procedure.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.DbRepository.Models
{
    public class Student
    {
        ICollection<Subject> Subjects;
    }

    public class Subject
    {
        ICollection<Mark> Subjects;
    }

    public class Mark
    {

    }

    public class SubjectMarkYearReportMultiSet : MultiResult
    {
        [ResultSet(0)]
        public  RCollection<Student> Strudents { get; set; }
        [ResultSet(2)]
        public RCollection<Mark> Marks { get; set; }
        [ResultSet(1)]
        public RCollection<Subject> Subjects { get; set; }
    }
}
