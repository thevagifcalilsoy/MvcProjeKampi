using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EntityLayer.Concrete
{
  public  class About
    {
       [Key]
        public int AboutId { get; set; }
        [StringLength(1000)]
        public string AboutDetails1 { get; set; }
        [StringLength(1000)]
        public string AboutDetails2 { get; set; }
        [StringLength(100)]
        public string  AboutImage1 { get; set; }
        [StringLength(100)]
        public string AboutImage2 { get; set; }

//        Valla Video sonuna geldiğimde anladığımı kağıda dökünce olay daha net oturdu.bence anlamadıysak baştan bi daha bir daha izlemek lazım önemli konu.ama çözdüm.çözünce de cok basit oldugunu gördüm.
//Düz mantık: 
//1)Hangi Tabloyu bir diğerine bağlayacaksak.Önce O clanda ICollection nesnesi oluşturup içine bağlayacağımız clasın adını yazıyoruz.ismide de s eklenmiş hali oluyor.
//2) Bağladığımız tabloya da giderek.Bir önceki tablonun property olarak  İd sini tanımlıyoruz.Sonra da altına virtual ile bağlanan  clasın adını yazıyoruz.
//5 kere arka arkaya yapan biri bunu ömür billah unutmaz.hangi sütünları bağlayacağını da belirlemesi gerekir tabi.ama tekil olarak id ile bağlanıyor zaten en basit şekilde
    }
}
