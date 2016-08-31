using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

//Haakon Kristoffer Baalerud Helgesen        Student nr: n9787283


namespace YWWACP
{
    [Activity(Label = "ProfileActivity")]
    public class ProfileActivity : Activity
    {


       // private Button btnEditText;
        private Button btnSaveText;
        private EditText EditText;


        //Array all userinfo is stored in
        String[] data = { "UserInfo","UserInfo2" };


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Profile);

            //Buttons
            btnSaveText = FindViewById<Button>(Resource.Id.buttonSaveText);
            //btnEditText = FindViewById<Button>(Resource.Id.buttonEditText);

            //Textfields
            EditText = FindViewById<EditText>(Resource.Id.userInfo);

            
            btnSaveText.Click += BtnSaveText_Click;
            //btnEditText.Click += BtnEditText_Click;

            //Sets user info into editText field
            EditText.SetText(data[0], TextView.BufferType.Editable);

        }


        private void BtnSaveText_Click(object sender, EventArgs e)
        {
            //GetsTheTextFromEditTextField
            string getTextField = EditText.Text;

            //Adds getTextField Into a array.
            data[0] = getTextField;

        }

      
    }
    }



