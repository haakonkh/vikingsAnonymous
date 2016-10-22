using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YWWACP.Core.Models
{
    public class MyTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
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

        //Goal/graph 
        public string GoalId { get; set; }
        public string GoalContent { get; set; }
        public string GoalDate { get; set; }
        public double GoalSatisfaction { get; set; }

        public string MealId { get; set; }
        public string MealTitle { get; set; }
        public string MealSummary { get; set; }

        public string Ingredients { get; set; }
        // Should maybe be a list? 
        public string Approach { get; set; }
        // Time to put in diary/healthPlan
        public string MealDate { get; set; }
        public string MealTimestamp { get; set; }

        public string ExerciseId { get; set; }

        public string ExerciseContent { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public bool basic { get; set; }
        public string ExerciseTimestamp { get; set; }
        public string ExerciseDate { get; set; }

        public string ExerciseTitle { get; set; }
        public string ExerciseSummary { get; set; }


    }
    /*
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
        
        // FK
        public List<int> MealsID { get; set; }
        // FK
        public List<int> ExerciseID { get; set; }
        public string Goals { get; set; }
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

    }*/
}
