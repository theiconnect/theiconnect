using System;

namespace StudentWebAppliaction.Models
{
    /// <summary>
    /// Lightweight view model used by the shared error view.
    /// Provides the RequestId and a convenience flag to indicate whether it should be shown.
    /// </summary>
    public class StudentModel
    {

        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? FatherName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the request identifier for the current request.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Returns true when a non-empty RequestId is available and should be displayed.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
