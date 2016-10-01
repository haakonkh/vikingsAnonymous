﻿using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YWWACP.Core.Models
{
   public class User 
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public string UserType { get; set; }
            
    }

    public class Threads
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public int CommentsID { get; set; }
        public int UserID { get; set; }

    }

    public class Comments
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ThreadID { get; set; }
        public List<int> CommentsID { get; set; }

    }

    public class Comment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Content { get; set; }

    }

    public class Diary
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserID { get; set; }
        //FK
        public List<int> DayID { get; set; }

    }

    public class Day
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Goals { get; set; }
        // FK
        public List<int> MealsID { get; set; }
        // FK
        public List<int> ExerciseID { get; set; }
        public DateTime Date { get; set; }
    }

    public class HealthPlan
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        // FK 
        public int UserID { get; set; }
        // FK
        public List<int> DayID { get; set; }
    }

    public class Meal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Tittle { get; set; }
        public List<string> Ingredients { get; set; }
        // Should maybe be a list? 
        public string Approach { get; set; } 
        // Time to put in diary/healthPlan
        public DateTime Timestamp { get; set; }

    }
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public DateTime Timestamp { get; set; }

    }
}