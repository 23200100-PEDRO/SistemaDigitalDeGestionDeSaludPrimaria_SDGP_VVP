namespace SDGP_VVP.Web.Models
{
    public class HistoriaClinicaCompletaViewModel
    {
        public HistoriaClinicaViewModel Historia { get; set; }
            = new HistoriaClinicaViewModel();

        public List<HistoriaDetalleViewModel> Consultas { get; set; }
            = new();
    }
}