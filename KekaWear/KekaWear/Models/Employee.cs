using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KekaWear.Models.Xhr.Core;

namespace KekaWear.Models
{
    public class Employee : EmployeeBase
    {
        /// <summary>
        /// Gets or sets the employee number.
        /// </summary>
        /// <value>
        /// The employee number.
        /// </value>
        public string EmployeeNumber { get; set; }

        /// <summary>
        /// Gets or sets the employment status.
        /// </summary>
        /// <value>
        /// The employment status.
        /// </value>
        public EmploymentStatus EmploymentStatus { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>
        /// The name of the department.
        /// </value>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the name of the org location.
        /// </summary>
        /// <value>
        /// The name of the org location.
        /// </value>
        public string orgLocationName { get; set; }

        /// <summary>
        /// Gets or sets the work phone.
        /// </summary>
        /// <value>
        /// The work phone.
        /// </value>
        public string WorkPhone { get; set; }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.DisplayName)) return "#";
                return this.DisplayName.Trim()[0].ToString().ToUpper();
            }
        }



        /// <summary>
        /// Gets or sets the mobile phone.
        /// </summary>
        /// <value>
        /// The mobile phone.
        /// </value>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the shift policy identifier.
        /// </summary>
        /// <value>
        /// The shift policy identifier.
        /// </value>
        public string ShiftPolicyId { get; set; }

        /// <summary>
        /// Gets or sets the weekly off policy identifier.
        /// </summary>
        /// <value>
        /// The weekly off policy identifier.
        /// </value>
        public string WeeklyOffPolicyId { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public int LocationId { get; set; }

        /// <summary>
        /// Gets or sets the reporting to.
        /// </summary>
        /// <value>
        /// The reporting to.
        /// </value>
        public int ReportingTo { get; set; }



        /// <summary>
        /// The is selected
        /// </summary>
        private bool isSelected;
        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        public bool IsSelected
        {
            set
            {
                isSelected = value;
            }
            get
            {
                return isSelected;
            }
        }



    }

    public class EmployeeInfo
    {
        public int Count { get; set; }
    }
    public class EmployeeBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the profile image URL.
        /// </summary>
        /// <value>
        /// The profile image URL.
        /// </value>
        public string ProfileImageUrl { get; set; }

        #region AppSide Properties

        /// <summary>
        /// Gets the profile image.
        /// </summary>
        /// <value>
        /// The profile image.
        /// </value>
        public string ProfileImage
        {
            get
            {
                if (!string.IsNullOrEmpty(ProfileImageUrl))
                {

                    return ProfileImageUrl;

                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName
        {
            get
            {
                var names = this.DisplayName.TrimWhiteSpaces().Split(' ');
                return names[0];

            }
        }

        /// <summary>
        /// Gets a value indicating whether [show image].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show image]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowImage
        {
            get
            {
                return string.IsNullOrEmpty(this.ProfileImageUrl);
            }
        }


        /// <summary>
        /// Gets the name of the two letter.
        /// </summary>
        /// <value>
        /// The name of the two letter.
        /// </value>
        public string TwoLetterName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.DisplayName))
                {
                    var names = this.DisplayName.TrimWhiteSpaces().ToUpper().Split(' ');
                    return names.Length > 1 ? string.Format("{0}{1}", names[0][0], names[1][0]) : names[0].Length > 1 ? names[0].Substring(0, 2) : names[0];
                }
                return string.Empty;
            }
        }

        #endregion
    }

    public static class Extensions
    {

        public static string TrimWhiteSpaces(this string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            text = text.Trim();
            return Regex.Replace(text, @"\s{2,}", " ");
        }
    }
}