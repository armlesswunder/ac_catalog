using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListWizard
{
    public partial class SerenaQuestions : Form

     
    {
        const string A1 = "What kind of axe did you throw in?";
        const string A2 = "Don't you think I look completely different?";
        const string A3 = "Do you really not like me or something?";
        const string A4 = "Ouch and takes your axe.";

        const string B1 = "Did I seem goddessy?";
        const string B2 = "What kind of axe do you want?";
        const string B3 = "Did I do something to make you not like me?";

        const string C1 = "I do happen to have some silver axes lying around. Want one of those?";
        const string C2 = "How much do you not like me?";
        const string C3 = "You really think I will give you that?";
        const string C4 = "So, how bad do you want one?";

        const string D1 = "Maybe I should disqualify myself from goddess hood...";
        const string D2 = "Did you really think that?";

        const string E1 = "Do you think you'll be able to like me more?";
        const string F1 = "You're just trying to make me feel better, aren't you?";
        const string G1 = "...Do you want a present?";
        const string H1 = "Left or right?";

        string currentQuestion = "P0";

        public SerenaQuestions()
        {
            InitializeComponent();
        }

        private void SerenaQuestions_Load(object sender, EventArgs e)
        {
            initialState();
        }
        private void initialState()
        {
            q1.Text = A1;
            q2.Text = A2;
            q3.Text = A3;
            q4.Text = A4;

            string[] arr = { };
            arr[0] = "Normal Axe";
            ab1.DataSource = arr;
            arr[0] = "Big Change";
            ab2.DataSource = arr;
            arr[0] = "Yeah";
            ab3.DataSource = arr;
        }

        private void a1_Click(object sender, EventArgs e)
        {
            
        }

        private void a2_Click(object sender, EventArgs e)
        {
            switch (q2.Text)
            {
                case A2: 
                    {
                        q1.Text = B2;
                        //a1.Text = "";
                        break; 
                    }
                case C1: { break; }
            }
        }

        private void a3_Click(object sender, EventArgs e)
        {
            switch (q3.Text)
            {
                case A3: { break; }
                case "": { break; }
            }
        }

        private void a4_Click(object sender, EventArgs e)
        {
            switch (q4.Text)
            {
                case A4: { break; }
                case "": { break; }
            }
        }

        private void a5_Click(object sender, EventArgs e)
        {

        }

        private void a6_Click(object sender, EventArgs e)
        {

        }

        private void q1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (q1.Text)
            {
                case A1:
                    {
                        q1.Text = B1;
                        ab1.Text = "Range bar: \t100% (gives any axe or new question) or\n\t\t 85% (Golden or Regular) or\n\t\t0% (takes or gives special axe)";

                        q2.Text = C1;
                        //a2.Text = "Yes, please";
                        break;
                    }
                case B1:
                    {

                        break;
                    }
                case B2:
                    { break; }

            }
        }
    }
}
