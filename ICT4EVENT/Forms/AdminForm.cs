using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;

namespace ICT4EVENT
{
    public partial class AdminForm : Form
    {
        private readonly CampingLogic campingLogic;
        private readonly CreateUserLogic createUser;
        private PostReviewLogic postReview;

        private RFID rfid;

        public AdminForm()
        {
            InitializeComponent();
            campingLogic = new CampingLogic(this);
            postReview = new PostReviewLogic(this);
            createUser = new CreateUserLogic(this);

            OpenRFIDConnection();
        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            gbCreateEvent.Visible = true;
        }

        private void btnUpdateEvents_Click(object sender, EventArgs e)
        {
            flowEvent.Controls.Clear();
                FillEventList(EventManager.FindAllEvents());
            }

            public void AddEvent(UserEvent userEvent)
            {
            flowEvent.Controls.Add(userEvent);
            }

            public void FillEventList(List<EventModel> eventModels)
            {
                foreach (var eventModel in eventModels)
                {
                flowEvent.Controls.Add(new UserEvent(eventModel));
                }
            }

        private void btnCreateNewEvent_Click(object sender, EventArgs e)
        {
            EventModel eventModel = EventManager.CreateNewEvent(tbEventName.Text, tbLocation.Text, tbDescription.Text, dateTimePicker1.Value,
                    dateTimePicker2.Value);
            if (eventModel != null)
                        {
                flowEvent.Controls.Add(new UserEvent(eventModel));
            }
        }

        class CampingLogic
        {

            private int[] BungalinosArray()
            {
                var Bungalinos1 = Enumerable.Range(50, 6).ToArray();
                var Bungalinos2 = Enumerable.Range(60, 12).ToArray();
                var Bungalinos3 = Enumerable.Range(101, 5).ToArray();
                var Bungalinos = Bungalinos1.Concat(Bungalinos2).Concat(Bungalinos3).ToArray();
                return Bungalinos;
            }

            private int[] ComfortPlaatsenArray()
            {
                var Comfortplaats1 = Enumerable.Range(601, 26).ToArray();
                var Comfortplaats2 = Enumerable.Range(432, 4).ToArray();
                var ComfortPlaats = Comfortplaats1.Concat(Comfortplaats2).ToArray();
                return ComfortPlaats;
            }

            private int[] StaCaravanArray()
            {
                var StaCaravan1 = Enumerable.Range(34, 8).ToArray();
                var StaCaravan2 = Enumerable.Range(125, 3).ToArray();
                var StaCaravan3 = Enumerable.Range(93, 2).ToArray();
                var StaCaravan4 = Enumerable.Range(97, 4).ToArray();
                var StaCaravan = StaCaravan1.Concat(StaCaravan2).Concat(StaCaravan3).Concat(StaCaravan4).ToArray();
                return StaCaravan;
            }

            private int[] AllPlacesArray()
            {
                var allplaces = Bungalows.Concat(Blokhutten)
                    .Concat(Bungalinos)
                    .Concat(ComfortPlaatsen)
                    .Concat(EigenTenten)
                    .Concat(Huurtentjes)
                    .Concat(StaCaravan)
                    .Concat(Invalidenaccomodatie)
                    .ToArray();
                Array.Sort(allplaces);
                return allplaces;
            }
        }

        public class PostReviewLogic
        {
            private readonly AdminForm parent;

            public PostReviewLogic(AdminForm form)
            {
                parent = form;
                CreateDummyData();

                List<PostModel> posts = new List<PostModel>();
                posts = PostManager.GetPostsByPage();

                foreach (PostModel post in posts)
                {
                    List<PostReportModel> reports = new List<PostReportModel>();
                    reports = PostManager.GetPostReports(post);
                    foreach (PostReportModel report in reports)
                    {
                        parent.flowPostReview.Controls.Add(new UserPostReview(post, report.Reason));
                    }
                }

            }

            public void CreateDummyData()
            {
            }
        }

        public class CreateUserLogic
        {
            private readonly AdminForm parent;
            public CreateUserLogic(AdminForm gui)
            {
                parent = gui;
            }

            public void CreateUser()
            {
                string FullName = parent.txtName.Text + " " + parent.txtSurName.Text;
                string Password = GeneratePassword();
                string userName = parent.txtUsername.Text;
                string Address = parent.txtAddress.Text;
                string TelNr = parent.txtTelNr.Text;
                string Email = parent.txtEmail.Text;
                string Rfid = parent.txtAssignRfid.Text;
                UserManager.CreateUser(userName, Password, FullName, Address, TelNr, Email, Rfid);
                RemoveInput();
            }

            private string GeneratePassword()
            {
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                char[] PasswordChars = new char[8];
                Random r = new Random();

                for (int i = 0; i < PasswordChars.Length; i++)
                {
                    PasswordChars[i] = chars[r.Next(chars.Length)];
                }

                string RandomPassword = new String(PasswordChars);
                return RandomPassword;
            }

            private void RemoveInput()
            {
                parent.txtName.Text = "";
                parent.txtSurName.Text = "";
                parent.txtUsername.Text = "";
                parent.txtAddress.Text = "";
                parent.txtTelNr.Text = "";
                parent.txtEmail.Text = "";
                parent.txtAssignRfid.Text = "";
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (txtAssignRfid.Text != null)
            {
                createUser.CreateUser();
                MessageBox.Show("Gebruiker aangemaakt");
            }
            else
            {
                MessageBox.Show("Scan eerst een RFID");
            }
        }

        private void OpenRFIDConnection()
        {
            try
            {
                rfid = new RFID();
                rfid.Error += RFID_Error;
                rfid.Tag += RFID_Tag;

                rfid.open(-1);

                rfid.waitForAttachment(1000);
            }
            catch (PhidgetException ex)
            {
                MessageBox.Show(ex.Description);
            }
        }

        private void RFID_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Description);
        }

        private void RFID_Tag(object sender, TagEventArgs e)
        {
            txtAssignRfid.Text = Convert.ToString(e.Tag);
        }


        private void tabMainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMainTab.SelectedTab.Name == "tabCreateUser")
            {
                rfid.Antenna = true;
                rfid.LED = true;
            }
            else
            {
                rfid.Antenna = false;
                rfid.LED = false;
            }
        }
    }
}