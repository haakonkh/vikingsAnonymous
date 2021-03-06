﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;
using YWWACP.Core.ViewModels.Community;
using YWWACP.Core.ViewModels.Diary;
using YWWACP.Core.ViewModels.Goal;

//Author: Student n9808205, Student Ingrid Skar

namespace YWWACP.Core.ViewModels.ExerciseRecipe
{
    public class ListExercisesViewModel : MvxViewModel
    {
        //navbar
        public ICommand OpenCommunityCommand { get; set; }
        public ICommand OpenHealthPlanCommand { get; set; }
        public ICommand OpenDiaryCommand { get; set; }
        public ICommand OpenHomeCommand { get; set; }
        public ICommand OpenExerciseCommand { get; set; }

        //for exercise
        private readonly IDatabase database;
        public ICommand RecipesViewCommand { get; set; }
        public ICommand SelectExerciseCommand { get; set; }
        public ICommand CreateExerciseCommand { get; set; }

        private ObservableCollection<NewExerciseThread> newExercise = new ObservableCollection<NewExerciseThread>();

        public ObservableCollection<NewExerciseThread> NewExercise
        {
            get { return newExercise; }
            set { SetProperty(ref newExercise, value); }
        }

        private string _userId;

        public string UserId
        {
            get { return _userId; }
            set { SetProperty(ref _userId, value); }
        }


        public ListExercisesViewModel(IDatabase database)
        {
            this.database = database;
            CreateExerciseCommand = new MvxCommand(() => ShowViewModel<CreateExerciseViewModel>(new { userid = UserId }));
            SelectExerciseCommand = new MvxCommand<NewExerciseThread>(thread => ShowViewModel<SingleExerciseViewModel>(new { exerciseId = thread.ExerciseId }));


            RecipesViewCommand = new MvxCommand(() =>
            {
                ShowViewModel<RecipeViewModel>(new { userid = UserId });
                Close(this);
            });

            // Navbar
            OpenHealthPlanCommand = new MvxCommand(() =>
            {
                ShowViewModel<HealthPlanViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenDiaryCommand = new MvxCommand(() =>
            {
                ShowViewModel<DiaryViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenHomeCommand = new MvxCommand(() =>
            {
                ShowViewModel<GraphViewModel>(new { userid = UserId });
                Close(this);
            });
            
            OpenExerciseCommand = new MvxCommand(() =>
            {
                ShowViewModel<CreateNewGViewModel>(new { userid = UserId });
                Close(this);
            });

            OpenCommunityCommand = new MvxCommand(() =>
            {
                ShowViewModel<CommunityViewModel>(new { userid =UserId});
                Close(this);
            });
        }

        public void Init(string userid)
        {
            UserId = userid;
        }

        public void OnResume()
        {
            GetExercises();
        }

        public async void GetExercises()
        {
            var threads = await database.GetTable();
            NewExercise.Clear();
            foreach (var thread in threads)
            {
                var c = thread.ExerciseId;

                if (c != null && thread.basic)
                {
                    NewExercise.Insert(0, new NewExerciseThread(thread.ExerciseId, thread.ExerciseTitle, thread.ExerciseSummary));
                }
            }

            RaisePropertyChanged(() => NewExercise);

        }

    }

}