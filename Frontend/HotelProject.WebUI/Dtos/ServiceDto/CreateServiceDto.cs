using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto

{
    public class CreateServiceDto
    {
        [Required(ErrorMessage ="Servis İkon Lİnki Girin")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlığı Girin")]
        [StringLength(100,ErrorMessage = "hizmet başlığı en fazla 100 karakter olabilir.")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
