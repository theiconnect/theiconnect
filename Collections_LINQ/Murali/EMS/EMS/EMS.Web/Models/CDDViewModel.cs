namespace EMS.Web.Models
{
    public class CDDViewModel
    {
    }

    public class CountryViewModel
    {
        public int CountryIdPk { get; set; }
        public string CountryName { get; set; }
    }

    public class StateViewModel
    {
        public int StateIdPk { get; set; }
        public string StateName { get; set; }
        public int CountryIdFk { get; set; }
    }

    public class CityViewModel
    {
        public int CityIdPk { get; set; }
        public string CityName { get; set; }
        public int StateIdFk { get; set; }
    }
}
