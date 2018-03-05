//  --------------------------------------------------------------------------------------
// NetCore.Globalization.Example.Web.ErrorViewModel.cs
// 2018/03/05
//  --------------------------------------------------------------------------------------

namespace NetCore.Globalization.Example.Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}