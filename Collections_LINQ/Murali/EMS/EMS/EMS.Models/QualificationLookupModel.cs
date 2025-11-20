using EMS.Models.Enums;

namespace EMS.Models
{
    public class QualificationLookupModel
    {
        public QualificationLookupModel(int qualificationId, string qualificationCode, string qualification)
        {
            QualificationIdPk = qualificationId;
            QualificationCode = qualificationCode;
            Qualification = qualification;
        }
        public int QualificationIdPk { get; set; }
        public string QualificationCode { get; set; }
        public string Qualification { get; set; }
    }
}
