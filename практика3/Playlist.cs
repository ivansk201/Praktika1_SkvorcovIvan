using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{

    public struct Song
    {
        public string Author;
        public string Title;

        public Song(string author, string title)
        {
            Author = author;
            Title = title;
        }

        public override string ToString()
        {
            return $"{Title} от {Author}";
        }
    }

    public class Playlist
    {
        public List<Song> list;
        public int currentIndex;

        public Playlist()
        {
            list = new List<Song>();
            currentIndex = 0;
        }

        public Song CurrentSong()
        {
            if (list.Count > 0)
                return list[currentIndex];
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }

        public void AddSong(Song song)
        {
            list.Add(song);
        }

        public void NextSong()
        {
            if (list.Count > 0)
            {
                currentIndex = (currentIndex + 1) % list.Count;
            }
        }

        public void BackSong()
        {
            if (list.Count > 0)
            {
                currentIndex = (currentIndex - 1 + list.Count) % list.Count;
            }
        }

        public void ClearPlaylist()
        {
            if (list.Count != 0)
            {
                list.Clear();
                currentIndex = 0;
            }
        }

        public void SavePlaylistToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Song song in list)
                {
                    writer.WriteLine($"{song.Author};{song.Title}");
                }
            }
        }

        public void LoadPlaylistFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                ClearPlaylist();

                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length == 2)
                        {
                            string author = parts[0];
                            string title = parts[1];
                            Song song = new Song(author, title);
                            AddSong(song);
                        }
                    }
                }
            }
        }
    }

}

