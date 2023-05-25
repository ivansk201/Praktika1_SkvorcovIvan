using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace zad3
{
    public partial class Form1 : Form
    {
        private Playlist playlist;
        private string playlistFilename = "playlist.txt";
        public Form1()
        {
            InitializeComponent();
            playlist = new Playlist();
            LoadPlaylist();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Song currentSong = playlist.CurrentSong();
                label5.Text = $"{currentSong.Title} от {currentSong.Author}";
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string author = textBox1.Text;
            string title = textBox2.Text;

            if (string.IsNullOrEmpty(author))
            {
                MessageBox.Show("Пожалуйста, введите автора песни", "Ошибка");
                return;
            }
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Пожалуйста, введите название песни", "Ошибка");
                return;
            }
            Song song = new Song(author, title);
            playlist.AddSong(song);
            listBox1.Items.Add(song);

            SavePlaylist();
            UpdateCurrentSongDisplay();

            label1.Visible = true;
            label5.Visible = true;
            button3.Visible = true;
            button4.Visible = true;

            MessageBox.Show("Песня добавлена в плейлист", "Успешно");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            playlist.NextSong();
            UpdateCurrentSongDisplay();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            playlist.BackSong();
            UpdateCurrentSongDisplay();
        }
        private void UpdateCurrentSongDisplay()
        {
            Song currentSong = playlist.CurrentSong();
            label5.Text = $"{currentSong.Title} от {currentSong.Author}";

            
            button4.Enabled = playlist.list.Count > 1;
            button3.Enabled = playlist.list.Count > 1;

            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < playlist.list.Count)
            {
                playlist.currentIndex = selectedIndex;
                UpdateCurrentSongDisplay();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            playlist.ClearPlaylist();
            listBox1.Items.Clear();
            SavePlaylist();

            MessageBox.Show("Плейлист очищен");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = listBox1.SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < playlist.list.Count)
                {
                    playlist.list.RemoveAt(selectedIndex);
                    listBox1.Items.RemoveAt(selectedIndex);
                    SavePlaylist();
                    UpdateCurrentSongDisplay();
                    MessageBox.Show("Песня удалена из плейлиста", "Успешно");
                }
            }
            catch
            {
                MessageBox.Show("Удалено", "Успешно");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            playlist.currentIndex = 0;
            UpdateCurrentSongDisplay();
        }
        private void SavePlaylist()
        {
            playlist.SavePlaylistToFile(playlistFilename);
        }

        private void LoadPlaylist()
        {
            playlist.LoadPlaylistFromFile(playlistFilename);
            foreach (Song song in playlist.list)
            {
                listBox1.Items.Add(song);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
          
            SavePlaylist();

        }
    }
}