using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vikinganonymousService.DataObjects
{
    public class User : EntityData
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public string UserType { get; set; }
    }

    public class Threads : EntityData
    {   
        public string Title { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        // FK 
        public int CommentsID { get; set; }
        // FK
        public int UserID { get; set; }

    }

    public class Comments : EntityData
    {
        // PK FK 
        public int ThreadID { get; set; }
        // FK 
        public List<int> CommentsID { get; set; }

    }
    
    public class Comment : EntityData
    {
        public string Content { get; set; }
    }

    public class Diary : EntityData
    {
        // PK FK 
        public int UserID { get; set; }
        //FK
        public List<int> DayID { get; set; }

    }

    public class Day : EntityData
    {
        public string Goals { get; set; }
        // FK
        public List<int> MealsID { get; set; }
        // FK
        public List<int> ExerciseID { get; set; }
        public DateTime Date { get; set; }
    }

    public class HealthPlan : EntityData
    {

        // PK FK 
        public int UserID { get; set; }
        // FK
        public List<int> DayID { get; set; }
    }

    public class Meal : EntityData
    {
        public string Tittle { get; set; }
        public List<string> Ingredients { get; set; }
        // Should maybe be a list? 
        public string Approach { get; set; }
        // Time to put in diary/healthPlan
        public DateTime Timestamp { get; set; }

    }
    public class Exercise : EntityData
    {
        public string Tittle { get; set; }
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public DateTime Timestamp { get; set; }

    }




}