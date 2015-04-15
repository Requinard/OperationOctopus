﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ICT4EVENT
{
    public partial class AdminGUI : Form
    {
        private readonly CampingLogic campingLogic;
        private readonly EventManagmentLogic eventManagment;
        private readonly CreateUserLogic createUser;
        private PostReviewLogic postReview;

        public AdminGUI()
        {
            InitializeComponent();
            eventManagment = new EventManagmentLogic(this);
            campingLogic = new CampingLogic(this);
            postReview = new PostReviewLogic(this);
            createUser = new CreateUserLogic(this);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            campingLogic.AddUserToList();
        }

        private void addEvent(UserEvent userEvent)
        {
            eventManagment.AddEvent(userEvent);
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            var plaats = Convert.ToInt32(nmrPlaats.Text);

            var lines = lbUser.Items.Count;

            if (campingLogic.CheckPlaceSize(plaats, lines))
            {
                MessageBox.Show("Succesvol gereserveerd");
                nmrPlaats.SelectedIndex = 0;
                txtGebruikers.Text = "";
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            createUser.CreateUser();
        }

        public class EventManagmentLogic
        {
            private readonly AdminGUI parent;

            public EventManagmentLogic(AdminGUI gui)
            {
                parent = gui;
                CreateDummyData();
            }

            public void AddEvent(UserEvent userEvent)
            {
                parent.flowEvent.Controls.Add(userEvent);
            }

            public void CreateDummyData()
            {
                var r = new Random();
                var newUserEvent = new UserEvent("Honor The Cage", "Luud", "De kleine lepel",
                    "A event to honor the all mighty cage, Lorem ipsum dolor sit amet, consectetur adipiscing elit. In ultricies tellus a ligula facilisis, id fringilla odio pharetra. Sed consequat leo nibh, in facilisis lorem luctus non. Curabitur risus augue, placerat at efficitur quis, aliquam sed arcu. Nam condimentum ligula eros, ut euismod turpis sodales nec. Duis mattis facilisis feugiat. Ut eu sollicitudin diam. Suspendisse vel ex et magna placerat lacinia. Vivamus mollis at justo eu ornare. Ut lacinia arcu a diam efficitur, vel malesuada nibh pretium. Pellentesque nec blandit leo. Quisque consectetur molestie ex, ut dapibus sem lacinia eu. Etiam ligula sem, sollicitudin eu eros eu, sollicitudin luctus orci. In nisl nunc, auctor vitae aliquet sit amet, placerat pellentesque nulla. Donec egestas tempus egestas. Donec a tellus id orci hendrerit consectetur. Fusce a fringilla nulla, non dictum purus. Aliquam placerat, metus eget volutpat feugiat, nisi mi varius odio, sit amet accumsan purus libero non dui. Sed quis massa cursus, feugiat elit a, imperdiet sem. Fusce non feugiat libero. Suspendisse purus magna, maximus eget imperdiet non, suscipit ac metus. Nulla id felis vitae tortor porta tincidunt quis commodo magna. Sed sollicitudin cursus orci, eget finibus leo dignissim id. Sed aliquam ex in tincidunt ornare.");
                parent.flowEvent.Controls.Add(newUserEvent);

                for (var i = 0; i < 10; i++)
                {
                    var userEvent = new UserEvent("Social Media Event", "Sjaak", "Camping Reeendaal",
                        "Een social media event");
                    parent.flowEvent.Controls.Add(userEvent);
                }
            }
        }

        public class CampingLogic
        {
            private readonly int[] Blokhutten;
            private readonly int[] Bungalinos;
            private readonly int[] Bungalows;
            private readonly int[] ComfortPlaatsen;
            private readonly int[] EigenTenten;
            private readonly int[] Huurtentjes;
            private readonly int[] Invalidenaccomodatie;
            private readonly AdminGUI parent;
            private readonly int[] StaCaravan;
            private int[] AllPlaces;
            private decimal amount;
            private List<string> guests;

            public CampingLogic(AdminGUI gui)
            {
                parent = gui;
                UserList = new List<string>();
                EigenTenten = EigenTentenArray();
                Bungalows = BungalowArray();
                Blokhutten = BlokHuttenArray();
                Bungalinos = BungalinosArray();
                ComfortPlaatsen = ComfortPlaatsenArray();
                StaCaravan = StaCaravanArray();
                Invalidenaccomodatie = Enumerable.Range(85, 6).ToArray();
                Huurtentjes = Enumerable.Range(643, 36).ToArray();
                AllPlaces = AllPlacesArray();
                FillAllPlaces();
            }

            public List<string> UserList { get; private set; }

            public void AddUserToList()
            {
                parent.lbUser.Items.Add(parent.txtGebruikers.Text);
                parent.txtGebruikers.Text = "";
            }

            public bool CheckPlaceSize(int place, int amountofusers)
            {
                if (amountofusers == 0)
                {
                    MessageBox.Show("Vul minstens een persoon in bij gebruikers");
                    return true;
                }
                if (place == 0)
                {
                    MessageBox.Show("Vul een geldige plaats in bij plaats");
                    return true;
                }

                if (Bungalows.Contains(place))
                {
                    if (amountofusers > 8)
                    {
                        MessageBox.Show("Er mogen maximaal 8 personen in een bungalow verblijven.");
                        return false;
                    }
                    return true;
                }

                foreach (var p in Bungalinos)
                {
                    if (p == place)
                    {
                        if (amountofusers > 4)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen in een bungalino verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (var p in EigenTenten)
                {
                    if (p == place)
                    {
                        if (amountofusers > 5)
                        {
                            MessageBox.Show("Er mogen maximaal 5 personen in een eigen tent verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (var p in Blokhutten)
                {
                    if (p == place)
                    {
                        if (amountofusers > 4)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen in een blokhut verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (var p in ComfortPlaatsen)
                {
                    if (p == place)
                    {
                        if (amountofusers > 4)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen op een comfortplaats verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (var p in Huurtentjes)
                {
                    if (p == place)
                    {
                        if (amountofusers > 4)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen in een huurtentje verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (var p in StaCaravan)
                {
                    if (p == place)
                    {
                        if (amountofusers > 6)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen in een stacaravan verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (var p in Invalidenaccomodatie)
                {
                    if (p == place)
                    {
                        if (amountofusers > 4)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen in een invalidenaccomodatie verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                MessageBox.Show("Plaats niet gevonden.");
                return false;
            }

            private void FillAllPlaces()
            {
                for (var i = 0; i <= 678; i++)
                {
                    parent.nmrPlaats.Items.Add(i);
                }
                /*
                foreach (int place in AllPlaces)
                {
                    parent.nmrPlaats.Items.Add(place);
                }
                 */
            }

            private int[] EigenTentenArray()
            {
                var Tenten1 = Enumerable.Range(101, 23).ToArray();
                var Tenten2 = Enumerable.Range(200, 14).ToArray();
                var Tenten3 = Enumerable.Range(401, 19).ToArray();
                var Tenten4 = Enumerable.Range(314, 10).ToArray();
                int[] Tenten5 = {544, 431};
                var Tenten = Tenten1.Concat(Tenten2).Concat(Tenten3).Concat(Tenten4).Concat(Tenten5).ToArray();
                return Tenten;
            }

            private int[] BungalowArray()
            {
                var Bungalows1 = Enumerable.Range(2, 11).ToArray();
                var Bungalows2 = Enumerable.Range(14, 2).ToArray();
                var Bungalows3 = Enumerable.Range(17, 4).ToArray();
                var Bungalows4 = Enumerable.Range(23, 4).ToArray();
                var Bungalows = Bungalows1.Concat(Bungalows2).Concat(Bungalows3).Concat(Bungalows4).ToArray();
                return Bungalows;
            }

            private int[] BlokHuttenArray()
            {
                var Blokhutten1 = Enumerable.Range(72, 10).ToArray();
                var Blokhutten2 = Enumerable.Range(91, 2).ToArray();
                var Blokhutten3 = Enumerable.Range(95, 2).ToArray();
                var Blokhutten4 = Enumerable.Range(138, 5).ToArray();
                var Blokhutten5 = Enumerable.Range(143, 8).ToArray();
                int[] Blokhutten6 = {124};
                var Blokhutten =
                    Blokhutten1.Concat(Blokhutten2)
                        .Concat(Blokhutten3)
                        .Concat(Blokhutten4)
                        .Concat(Blokhutten5)
                        .Concat(Blokhutten6)
                        .ToArray();
                return Blokhutten;
            }

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
                return allplaces;
            }
        }

        public class PostReviewLogic
        {
            private readonly AdminGUI parent;

            public PostReviewLogic(AdminGUI gui)
            {
                parent = gui;
                CreateDummyData();
            }

            public void CreateDummyData()
            {
                UserPost post;
                post = new UserPost("David != fucking haat", "Guus", null,
                    null);
                parent.flowPostReview.Controls.Add(new UserPostReview(post));


                post = new UserPost("David != fucking haat", "Guus", null,
                    null);
                parent.flowPostReview.Controls.Add(new UserPostReview(post));

                post = new UserPost("David != fucking haat", "Guus", null,
                    null);
                parent.flowPostReview.Controls.Add(new UserPostReview(post));
            }
        }

        public class CreateUserLogic
        {
            private readonly AdminGUI parent;
            public CreateUserLogic(AdminGUI gui)
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
        }     
    }
}