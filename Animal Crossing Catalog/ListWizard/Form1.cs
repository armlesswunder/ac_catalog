using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ListWizard
{
    public partial class AC_Catalog : Form
    {
        //name of database file ("catalog".mdf)
        const string catalogName = "catalogv1";
        string connectionString;
        string basePath;

        //database tables are all named with the following convention:
        // ac(game)_(thing) where (game) is the animal crossing game you are playing
        // and (thing) is the type of item you are searching for
        string qualifier = "accf_";
        string tableName = "furniture";
        string query = "";

        //hunting tables (the table used for filtering insects and fish by season)
        // are of similar format to the other tables except they include the season
        // as a three character string in the middle (ac(game)_(season)_(fish/bug))
        string huntingSeason = "jan";
        string huntingType = "fish";
        string huntingQuery = "";

        public AC_Catalog()
        {
            InitializeComponent();
            basePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);

            //dynamic db path - grabs your db from local folder
            connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + basePath + "\\"+ catalogName + ".mdf;" + "Integrated Security=True;Connect Timeout=30;User Instance=False";

            //hard code db path
            //connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\catalog.mdf;Integrated Security=True;Connect Timeout=30";

            setImages();
            loadSettings();
            
        }

        //the wyzzrd was the original name of this application. couldn't figure
        //out how to change this name... but this is what happens when the
        //window first loads
        private void The_Wyzzrd_Load(object sender, EventArgs e)
        { fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%'); }

        private void setImages() 
        {
            tabPage1.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\bg.png");
            tabPage3.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\bg.png");
            BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\bg.png");
            furnBtn.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\furn_ic.png");
            wallpaperBtn.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\wallpaper_ic.png");
            carpetBtn.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\carpet_ic.png");
            shirtBtn.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\shirt_ic.png");
            accBtn.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\hat_ic.png");
            statBtn.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\paper_ic.png");
            songBtn.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\song_ic.png");
            umbrellaBtn.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\tool_ic.png");
            paintingBtn.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\painting_ic.png");
            fishBtn.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\fish_ic.png");
            insectBtn.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\insect_ic.png");
            gyroidBtn.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\gyroid_ic.png");
            fossilBtn.BackgroundImage = System.Drawing.Image.FromFile(basePath + "\\image_resources\\fossil_ic.png");
        }

        private void gamecubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qualifier = "acgc_";
            //there are no accesories in gamecube. also paintings are included in furniture.
            //I couldn't find data for shadows of fish so all of these options are disabled
            //and re-enabled for city folk 
            accBtn.Enabled = false;
            paintingBtn.Enabled = false;
            shadowFilter.Enabled = false;

            //if the user was looking at paintings or accessories, they will be 
            //redirected to furniture
            if (tableName == "painting" || tableName == "accessory")
            {
                fillData(connectionString, makeCatalogQuery("furniture"), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
            }
            else 
            {
                fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
            }
            fillHuntingData(connectionString, makeHuntingQuery());

        }

        private void cityFolkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qualifier = "accf_";
            accBtn.Enabled = true;
            paintingBtn.Enabled = true;
            shadowFilter.Enabled = true;

            fillData(connectionString, query, '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
            fillHuntingData(connectionString, makeHuntingQuery());

        }

        //selecting a hunting season
        private void seasonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (seasonComboBox.Text) {
                case "January" : huntingSeason = "jan"; break;
                case "February": huntingSeason = "feb"; break;
                case "March": huntingSeason = "mar"; break;
                case "April": huntingSeason = "apr"; break;
                case "May": huntingSeason = "may"; break;
                case "June": huntingSeason = "jun"; break;
                case "July": huntingSeason = "jul"; break;
                case "August - 1st Half": huntingSeason = "aug1"; break;
                case "August - 2nd Half": huntingSeason = "aug2"; break;
                case "September - 1st Half": huntingSeason = "sep1"; break;
                case "September - 2nd Half": huntingSeason = "sep2"; break;
                case "October": huntingSeason = "oct"; break;
                case "November": huntingSeason = "nov"; break;
                case "December": huntingSeason = "dec"; break;
                default : huntingSeason = "jan"; break;
            }

            fillHuntingData(connectionString, makeHuntingQuery());
        }

        //selecting fish/bugs
        private void huntingTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (huntingTypeComboBox.Text)
            {
                case "Fish": huntingType = "fish"; break;
                case "Insects": huntingType = "insect"; break;
                default: huntingType = "fish"; break;
            }

            fillHuntingData(connectionString, makeHuntingQuery());
        }

        //call this function to create your database query for everything except hunting
        //data
        private string makeCatalogQuery() {
            query = "select * from " + qualifier + tableName + " where name like @name";
            if (filterBox.Checked)
            {
                query += " and selected = " + (selectedBox.Checked ? '1' : '0');
            }
            if (isFromFiltered())
                query += " and \"from\" like @from";
            return query;
        }
        //overrides the catalog query so that a different table is selected from
        //(see gamecubeToolStripMenuItem_Click)
        private string makeCatalogQuery(string tableName)
        {
            query = "select * from " + qualifier + tableName + " where name like @name";
            if (filterBox.Checked)
            {
                query += " and selected = " + (selectedBox.Checked ? '1' : '0');
            }
            if (isFromFiltered())
                query += " and \"from\" like @from";
            return query;
        }

        private string makeHuntingQuery() {

            huntingQuery = "select * from " + qualifier + huntingType + " where \"Index\" in (select * from " + qualifier + huntingSeason + '_' + huntingType + ")";

            if (huntingFilter.Checked)
            {
                if (huntingSelected.Checked)
                {
                    huntingQuery += " and selected = 1";
                }
                else
                {
                    huntingQuery += " and selected = 0";
                }
            }

            if (shadowFilter.SelectedIndex != 0 && huntingType != "insect" && qualifier != "acgc_")
            {
                huntingQuery += " and shadow = '" + shadowFilter.Text + "'";
            }

            if (huntingLocation.SelectedIndex != 0 && huntingType != "insect")
            {
                huntingQuery += " and location like '%" + huntingLocation.Text + "%'";
            }

            return huntingQuery;

        }

        private void shadowFilter_SelectedIndexChanged(object sender, EventArgs e)
        {   
            fillHuntingData(connectionString, makeHuntingQuery());
        }

        private void huntingLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (huntingTypeComboBox.Text)
            {
                case "Fish": huntingType = "fish"; break;
                case "Insects": huntingType = "insect"; break;
                default: huntingType = "fish"; break;
            }

            fillHuntingData(connectionString, makeHuntingQuery());
        }

        private void huntingFilter_CheckedChanged(object sender, EventArgs e)
        {
            fillHuntingData(connectionString, makeHuntingQuery());
        }

        private void huntingSelected_CheckedChanged(object sender, EventArgs e)
        {
            fillHuntingData(connectionString, makeHuntingQuery());
        }

        //executes the sql command and then uses the result to fill the dataGridView
        private void fillHuntingData(String conStr, String query) {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet);
                huntingDataGridView.DataSource = dataSet.Tables[0];
            }
            
            //set the checkbox value based on the selected attribute for each row.
            foreach (DataGridViewRow row in huntingDataGridView.Rows)
            {
                if (row.Cells["Selected"].Value != null)
                {
                    if ((int)row.Cells["Selected"].Value == 1)
                        row.Cells[seasonalAcquired.Name].Value = true;
                    else
                        row.Cells[seasonalAcquired.Name].Value = false;
                }
            }

            //for some reason, the first row never gets its checkbox set properly in the previous
            //foreach, so it works if its done afterwards...
            if (huntingDataGridView.Rows.Count != 0)
            {
                if ((int)huntingDataGridView.Rows[0].Cells["Selected"].Value == 1)
                    huntingDataGridView.Rows[0].Cells[seasonalAcquired.Name].Value = true;
                else
                    huntingDataGridView.Rows[0].Cells[seasonalAcquired.Name].Value = false;
            }
            //set the appearance of the columns, mostly sizes. Selected is irrelevant to the user bc they will
            //be interacting with that column via checkbox
            huntingDataGridView.Columns["Selected"].Visible = false;
            huntingDataGridView.Columns["Index"].Width = 50;
            huntingDataGridView.Columns["Times"].Width = 500;
            huntingDataGridView.Columns[seasonalAcquired.Name].Width = 66;
            
        }


        void fillData(String conStr, String query, String param, String param2)
        {

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", param);
                if(isFromFiltered())
                    cmd.Parameters.AddWithValue("@from", param2);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
               
                dataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Selected"].Value != null)
                {
                    if ((int)row.Cells["Selected"].Value == 1)
                        row.Cells[Acquired.Name].Value = true;
                    else
                        row.Cells[Acquired.Name].Value = false;
                }
            }

            if (dataGridView1.Rows.Count != 0)
            {
                if ((int)dataGridView1.Rows[0].Cells["Selected"].Value == 1)
                    dataGridView1.Rows[0].Cells[Acquired.Name].Value = true;
                else
                    dataGridView1.Rows[0].Cells[Acquired.Name].Value = false;
            }
            dataGridView1.Columns["Selected"].Visible = false;
            dataGridView1.Columns["Index"].Width = 50;
            if (dataGridView1.Columns["Times"] != null)
                dataGridView1.Columns["Times"].Width = 500;
            dataGridView1.Columns[Acquired.Name].Width = 66;
        }

        //this basically executes the command of clicking the checkbox (user has acquired a new item)
        // and then updates the dataGridView to reflect that change
        void updateData(String conStr, String query)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
           
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }

        void updateSeasonData(String conStr, String query)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }

            fillHuntingData(connectionString, makeHuntingQuery());
        }

        //returns whether the table should be filtered on the from column
        private bool isFromFiltered() { 
            return tableName != "fossil" && tableName != "fish" && tableName != "insect" && tableName != "gyroid" && tableName != "song";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableName = "furniture";
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tableName = "wallpaper";
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }
        private void carpetBtn_Click(object sender, EventArgs e)
        {
            tableName = "carpet";
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }
        private void shirtBtn_Click(object sender, EventArgs e)
        {
            tableName = "shirt";
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }
        private void umbrellaBtn_Click(object sender, EventArgs e)
        {
            tableName = "tool";
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }
        private void accBtn_Click(object sender, EventArgs e)
        {
            tableName = "accessory";
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }
        private void statBtn_Click(object sender, EventArgs e)
        {
            tableName = "stationery";
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }

        private void gyroidBtn_Click(object sender, EventArgs e)
        {
            tableName = "gyroid";
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }

        private void songBtn_Click(object sender, EventArgs e)
        {
            tableName = "song";
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }
        private void insectBtn_Click(object sender, EventArgs e)
        {
            tableName = "insect";
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }

        private void fishBtn_Click(object sender, EventArgs e)
        {
            tableName = "fish";
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }

        private void fossilBtn_Click(object sender, EventArgs e)
        {
            tableName = "fossil";
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }

        private void paintingBtn_Click(object sender, EventArgs e)
        {
            tableName = "painting";
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }

        //clear the textbox for name
        private void clearBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void clearFromBtn_Click(object sender, EventArgs e)
        {
            fromTextBox.Text = "";
        }

        //update the dataGridView based on user input (search bar w/o the search button!)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }

        private void fromTextBox_TextChanged(object sender, EventArgs e)
        {
            
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
        }

        //handles the checkbox changed event
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int selected = 0;
                try {
                    string index = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Index"].Value.ToString();
                    DataGridViewCheckBoxCell checkbox = new DataGridViewCheckBoxCell();
                    checkbox = (DataGridViewCheckBoxCell)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0];

                    if (checkbox.Value == null)
                        checkbox.Value = false;
                    switch (checkbox.Value.ToString())
                    {
                        case "True":
                            checkbox.Value = false;
                            selected = 0;
                            break;
                        case "False":
                            checkbox.Value = true;
                            selected = 1;
                            break;
                    }
                    updateData(connectionString, "update " + qualifier + tableName + " set selected = " + selected + " where \"Index\" = " + index);
                }
                catch { }
            } 
        }

        private void huntingDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int selected = 0;
                try
                {
                    string index = huntingDataGridView.Rows[huntingDataGridView.CurrentRow.Index].Cells["Index"].Value.ToString();
                    DataGridViewCheckBoxCell checkbox = new DataGridViewCheckBoxCell();
                    checkbox = (DataGridViewCheckBoxCell)huntingDataGridView.Rows[huntingDataGridView.CurrentRow.Index].Cells[0];

                    if (checkbox.Value == null)
                        checkbox.Value = false;
                    switch (checkbox.Value.ToString())
                    {
                        case "True":
                            checkbox.Value = false;
                            selected = 0;
                            break;
                        case "False":
                            checkbox.Value = true;
                            selected = 1;
                            break;
                    }
                    updateSeasonData(connectionString, "update " + qualifier + huntingType + " set selected = " + selected + " where \"Index\" = " + index);
                }
                catch { }
            }
        }

        //user may filter the results by whether they have acquired a thing or not.
        private void filterBox_CheckedChanged_1(object sender, EventArgs e)
        {
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
            //save the users preference
            global::AC_Catalog.Properties.Settings.Default.filterCheck = filterBox.Checked;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void selectedBox_CheckedChanged_1(object sender, EventArgs e)
        {
            fillData(connectionString, makeCatalogQuery(), '%' + textBox1.Text + '%', '%' + fromTextBox.Text + '%');
            global::AC_Catalog.Properties.Settings.Default.selectedCheck = selectedBox.Checked;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        //the following functions are for the perfect town screen. the users input is basically saved
        //in settings so they can keep track of how many flowers and trees they have per acre.
        //naming conventions are (N0(t/f) where N = Y coordinates used in ac maps(A-F), 0 = the X coordinates in the maps (1-5)
        // and (t/f) = t for tree or f for flower)
        private void A1T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.A1T = A1T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void A1F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.A1F = A1F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void A2T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.A2T = A2T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void A2F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.A2F = A2F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void A3T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.A3T = A3T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void A3F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.A3F = A3F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void A4T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.A4T = A4T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void A4F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.A4F = A4F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void A5T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.A5T = A5T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void A5F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.A5F = A5F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void B1T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.B1T = B1T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void B1F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.B1F = B1F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void B2T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.B2T = B2T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void B2F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.B2F = B2F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void B3T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.B3T = B3T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void B3F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.B3F = B3F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void B4T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.B4T = B4T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void B4F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.B4F = B4F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void B5T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.B5T = B5T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void B5F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.B5F = B5F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void C1T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.C1T = C1T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void C1F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.C1F = C1F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void C2T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.C2T = C2T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void C2F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.C2F = C2F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void C3T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.C3T = C3T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void C3F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.C3F = C3F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void C4T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.C4T = C4T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void C4F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.C4F = C4F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void C5T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.C5T = C5T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void C5F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.C5F = C5F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void D1T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.D1T = D1T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void D1F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.D1F = D1F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void D2T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.D2T = D2T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void D2F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.D2F = D2F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void D3T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.D3T = D3T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void D3F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.D3F = D3F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void D4T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.D4T = D4T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void D4F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.D4F = D4F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void D5T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.D5T = D5T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void D5F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.D5F = D5F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void E1T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.E1T = E1T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void E1F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.E1F = E1F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void E2T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.E2T = E2T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void E2F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.E2F = E2F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void E3T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.E3T = E3T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void E3F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.E3F = E3F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void E4T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.E4T = E4T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void E4F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.E4F = E4F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void E5T_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.E5T = E5T.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        private void E5F_ValueChanged(object sender, EventArgs e)
        {
            global::AC_Catalog.Properties.Settings.Default.E5F = E5F.Value;
            global::AC_Catalog.Properties.Settings.Default.Save();
        }

        //when the form loads, the settings users preferences are loaded into the form
        private void loadSettings() {

            A1T.Value = global::AC_Catalog.Properties.Settings.Default.A1T;
            A1F.Value = global::AC_Catalog.Properties.Settings.Default.A1F;
            A2T.Value = global::AC_Catalog.Properties.Settings.Default.A2T;
            A2F.Value = global::AC_Catalog.Properties.Settings.Default.A2F;
            A3T.Value = global::AC_Catalog.Properties.Settings.Default.A3T;
            A3F.Value = global::AC_Catalog.Properties.Settings.Default.A3F;
            A4T.Value = global::AC_Catalog.Properties.Settings.Default.A4T;
            A4F.Value = global::AC_Catalog.Properties.Settings.Default.A4F;
            A5T.Value = global::AC_Catalog.Properties.Settings.Default.A5T;
            A5F.Value = global::AC_Catalog.Properties.Settings.Default.A5F;

            B1T.Value = global::AC_Catalog.Properties.Settings.Default.B1T;
            B1F.Value = global::AC_Catalog.Properties.Settings.Default.B1F;
            B2T.Value = global::AC_Catalog.Properties.Settings.Default.B2T;
            B2F.Value = global::AC_Catalog.Properties.Settings.Default.B2F;
            B3T.Value = global::AC_Catalog.Properties.Settings.Default.B3T;
            B3F.Value = global::AC_Catalog.Properties.Settings.Default.B3F;
            B4T.Value = global::AC_Catalog.Properties.Settings.Default.B4T;
            B4F.Value = global::AC_Catalog.Properties.Settings.Default.B4F;
            B5T.Value = global::AC_Catalog.Properties.Settings.Default.B5T;
            B5F.Value = global::AC_Catalog.Properties.Settings.Default.B5F;

            C1T.Value = global::AC_Catalog.Properties.Settings.Default.C1T;
            C1F.Value = global::AC_Catalog.Properties.Settings.Default.C1F;
            C2T.Value = global::AC_Catalog.Properties.Settings.Default.C2T;
            C2F.Value = global::AC_Catalog.Properties.Settings.Default.C2F;
            C3T.Value = global::AC_Catalog.Properties.Settings.Default.C3T;
            C3F.Value = global::AC_Catalog.Properties.Settings.Default.C3F;
            C4T.Value = global::AC_Catalog.Properties.Settings.Default.C4T;
            C4F.Value = global::AC_Catalog.Properties.Settings.Default.C4F;
            C5T.Value = global::AC_Catalog.Properties.Settings.Default.C5T;
            C5F.Value = global::AC_Catalog.Properties.Settings.Default.C5F;

            D1T.Value = global::AC_Catalog.Properties.Settings.Default.D1T;
            D1F.Value = global::AC_Catalog.Properties.Settings.Default.D1F;
            D2T.Value = global::AC_Catalog.Properties.Settings.Default.D2T;
            D2F.Value = global::AC_Catalog.Properties.Settings.Default.D2F;
            D3T.Value = global::AC_Catalog.Properties.Settings.Default.D3T;
            D3F.Value = global::AC_Catalog.Properties.Settings.Default.D3F;
            D4T.Value = global::AC_Catalog.Properties.Settings.Default.D4T;
            D4F.Value = global::AC_Catalog.Properties.Settings.Default.D4F;
            D5T.Value = global::AC_Catalog.Properties.Settings.Default.D5T;
            D5F.Value = global::AC_Catalog.Properties.Settings.Default.D5F;

            E1T.Value = global::AC_Catalog.Properties.Settings.Default.E1T;
            E1F.Value = global::AC_Catalog.Properties.Settings.Default.E1F;
            E2T.Value = global::AC_Catalog.Properties.Settings.Default.E2T;
            E2F.Value = global::AC_Catalog.Properties.Settings.Default.E2F;
            E3T.Value = global::AC_Catalog.Properties.Settings.Default.E3T;
            E3F.Value = global::AC_Catalog.Properties.Settings.Default.E3F;
            E4T.Value = global::AC_Catalog.Properties.Settings.Default.E4T;
            E4F.Value = global::AC_Catalog.Properties.Settings.Default.E4F;
            E5T.Value = global::AC_Catalog.Properties.Settings.Default.E5T;
            E5F.Value = global::AC_Catalog.Properties.Settings.Default.E5F;
            

            selectedBox.Checked = global::AC_Catalog.Properties.Settings.Default.selectedCheck;
            filterBox.Checked = global::AC_Catalog.Properties.Settings.Default.filterCheck;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //not implemented feature. this was going to be questionaire which guides you through serena's questions and
        //helps you pick the best answer. Maybe I'll add this later...
        private void serenaQuestionaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new SerenaQuestions();
            form.Show();
        }

        
        //giving thanks where its due
        private void acknowledgementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("A special thanks to Nintendo for making these and many other great games.\nThanks to Liquify for making the guides I referenced.\nThanks to Microsoft for creating Windows Forms.", "Acknowledgements");
        }

        //information about the author AKA myself
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Created by Adam Wilson AKA(ArmlessWunder)\nFeel free to reach out to me about anything related to this program, especially any bugs!\nEmail me at: abw4v.dev@gmail.com", "About");

        }
    }
}
