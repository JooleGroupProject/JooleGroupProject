//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JooleGroupProject.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class tblUser
    {
        public int User_ID { get; set; }
        [RequiredAttribute(ErrorMessage = "Please Enter Your User Name or Email!")]
        public string User_Name { get; set; }
        [RequiredAttribute(ErrorMessage = "Please Enter Your User Name or Email!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
        ErrorMessage = "Please Enter Valid Email!")]
        public string User_Email { get; set; }
        public string User_Image { get; set; }
        [DataType(DataType.Password)]
        public string User_Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("User_Password", ErrorMessage = "Confirm Password Does Not Match!")]
        public string ConfirmPassword { get; set; }
        public string LoginErrorMessage { get; set; }
        public HttpPostedFileBase Imgfile { get; set; }
    }
}
