using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vikinganonymousService.DataObjects
{

    public class MyTable : EntityData
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Age { get; set; }
        public string UserType { get; set; }

        public string ThreadID { get; set; }
        public string ThreadTitle { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public string CommentsID { get; set; }
        public string CommentID { get; set; }
        public string CommentContent { get; set; }


        public string DiaryEntry { get; set; }
        public string GoalId { get; set; }
        public string Goals { get; set; }
        
        //public DateTime Date { get; set; }

        public string MealId { get; set; }
        public string MealTitle { get; set; }
        
        //public List<string> Ingredients { get; set; }
        // Should maybe be a list? 
        public string Approach { get; set; }
        // Time to put in diary/healthPlan
        
        //public DateTime MealTimestamp { get; set; }

        public string ExerciseId { get; set; }
        public string ExerciseTittle { get; set; }
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        
        public DateTime ExerciseTimestamp { get; set; }

    }
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