using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
//using SQLiteNetExtensions.Attributes;

namespace YWWACP.Core.Models
{
    [Table("User")]
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

    [Table("Threads")]
    public class Threads
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        //[ForeignKey(typeof(Comments))]
        public int CommentsID { get; set; }
        //[ForeignKey(typeof(User))]
        public int UserID { get; set; }

        public Comments Comments { get; set; }
        public User User { get; set; }
    }
    [Table("Comments")]
    public class Comments
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //[ForeignKey(typeof(Threads))]
        public int ThreadID { get; set; }
        //[ForeignKey(typeof(Comment))]
        [Ignore]
        public List<int> CommentsID { get; set; }

        public Threads Threads { get; set; }
        public Comment Comment { get; set; }

    }
    [Table("Comment")]
    public class Comment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Content { get; set; }

    }
    [Table("Diary")]
    public class Diary
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //[ForeignKey(typeof(User))]
        public int UserID { get; set; }
        //[ForeignKey(typeof(Day))]
        [Ignore]
        public List<int> DayID { get; set; }

        public User User { get; set; }
        public Day Day { get; set; }
    }
    [Table("Day")]
    public class Day
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Goals { get; set; }
       // [ForeignKey(typeof(Meal))]
        [Ignore]
        public List<int> MealsID { get; set; }
        //[ForeignKey(typeof(Exercise))]
        [Ignore]
        public List<int> ExerciseID { get; set; }
        public DateTime Date { get; set; }

        public  Meal Meal { get; set; }
        public Exercise Exercise { get; set; }
    }
    [Table("HealthPlan")]
    public class HealthPlan
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
      //  [ForeignKey(typeof(User))]
        public int UserID { get; set; }
        //[ForeignKey(typeof(Day))]
        [Ignore]
        public List<int> DayID { get; set; }

        public  User User { get; set; }
        public Day Day { get; set; }
    }

    [Table("Meal")]
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
    [Table("Exercise")]
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
