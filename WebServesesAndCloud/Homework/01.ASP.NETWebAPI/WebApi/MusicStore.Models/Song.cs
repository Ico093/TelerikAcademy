using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class Song
    {
        public int SongId { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public int Year { get; set; }

        public Genre Type { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
