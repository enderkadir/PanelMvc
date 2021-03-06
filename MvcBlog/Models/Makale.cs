using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class Makale
    {
        public Makale()
        {
            this.Yorums = new List<Yorum>();
            this.Etikets = new List<Etiket>();
            this.Resims = new List<Resim>();
        }

        public int id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public int MakaleTipID { get; set; }
        public System.DateTime YayimTarihi { get; set; }
        public int KategoriID { get; set; }
        public System.Guid YazarID { get; set; }
        public int KapakResimID { get; set; }
        public int Goruntuleme { get; set; }
        public int Begeni { get; set; }
        public bool Aktif { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual Kullanici Kullanici1 { get; set; }
        public virtual MakaleTip MakaleTip { get; set; }
        public virtual Resim Resim { get; set; }
        public virtual MakaleTakip MakaleTakip { get; set; }
        public virtual ICollection<Yorum> Yorums { get; set; }
        public virtual ICollection<Etiket> Etikets { get; set; }
        public virtual ICollection<Resim> Resims { get; set; }
    }
}
