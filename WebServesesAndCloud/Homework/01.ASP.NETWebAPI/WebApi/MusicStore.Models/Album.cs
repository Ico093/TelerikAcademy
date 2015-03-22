using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Album
    {
        private ICollection<Artist> artists;

        private ICollection<Song> songs;

        public Album()
        {
            this.artists = new HashSet<Artist>();
            this.songs = new HashSet<Song>();
        }

        public int AlbumId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [MaxLength(100)]
        public string Producer { get; set; }

        public virtual ICollection<Artist> Artists
        {
            get { return artists; }
            set { artists = value; }
        }

        public virtual ICollection<Song> Songs
        {
            get { return songs; }
            set { songs = value; }
        }
    }
}
