using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KekaWear.Models.Xhr.Core;

namespace KekaWear.Models
{
    /// <summary>
    /// Represents the Leave Type Summary Model
    /// </summary>
    /// <seealso cref="Cirrious.MvvmCross.ViewModels.MvxNotifyPropertyChanged" />
    public class LeaveTypeSummary 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeaveTypeSummary" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public LeaveTypeSummary(LeaveType type)
        {
            this.Type = type;
        }
        /// <summary>
        /// Gets the name of the type
        /// </summary>
        public string Name { get { return Type.Name; } }
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public LeaveType Type { get; private set; }

        /// <summary>
        /// The _annual quota
        /// </summary>
        private float _annualQuota;

        /// <summary>
        /// Gets or sets the Total leaves in hours for this plan leave type
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public float AnnualQuota
        {
            get
            {
                return _annualQuota;

            }
            set
            {
                _annualQuota = value;
               
            }

        }

        /// <summary>
        /// Gets or sets the accrued leaves in hours for this plan leave type
        /// </summary>
        /// <value>
        /// The accrued.
        /// </value>
        public float Accrued { get; set; }

        /// <summary>
        /// Gets or sets the comp offs.
        /// </summary>
        /// <value>
        /// The comp offs.
        /// </value>
        public float CompOffs { get; set; }

        /// <summary>
        /// Gets or sets the initial adjustments.
        /// </summary>
        /// <value>
        /// The initial adjustments.
        /// </value>
        public float InitialAdjustments { get; set; }

        /// <summary>
        /// Gets or sets the carryover balance.
        /// </summary>
        /// <value>
        /// The carryover balance.
        /// </value>
        public float CarryoverBalance { get; set; }

        /// <summary>
        /// Gets or sets the utilized in days.
        /// </summary>
        /// <value>
        /// The utilized in days.
        /// </value>
        public float ConsumedInDays { get; set; }

        /// <summary>
        /// The _available in days
        /// </summary>
        private float _availableInDays;
        /// <summary>
        /// Gets or sets the available leaves in days.
        /// </summary>
        /// <value>
        /// The available days.
        /// </value>
        public float AvailableInDays
        {
            get
            {
                return _availableInDays;
            }

            set
            {
                _availableInDays = value;
               
            }
        }

        /// <summary>
        /// Gets the current scaling.
        /// </summary>
        /// <value>
        /// The current scaling.
        /// </value>
      
        public Scaling CurrentScaling
        {
            get
            {
                var scaling = new Scaling();
                var availablewidth = (this.AvailableInDays / this.AnnualQuota) * 150;
                scaling.Width = Convert.ToInt32(availablewidth);
                scaling.Height = 25;
                return scaling;
            }

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class LeaveType
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is paid].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is paid]; otherwise, <c>false</c>.
        /// </value>
        public bool IsPaid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is sick].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is sick]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSick { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is statutory.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is statutory; otherwise, <c>false</c>.
        /// </value>
        public bool IsStatutory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is restricted to gender.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is restricted to gender; otherwise, <c>false</c>.
        /// </value>
        public bool IsRestrictedToGender { get; set; }

        /// <summary>
        /// Gets or sets the restricted gender.
        /// </summary>
        /// <value>
        /// The restricted gender.
        /// </value>
        public Gender RestrictedGender { get; set; }

        /// <summary>
        /// Gets or sets the type of the system leave.
        /// </summary>
        /// <value>
        /// The type of the system leave.
        /// </value>
        public SystemLeaveType SystemLeaveType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [system generated].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [system generated]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystemGenerated { get; set; }
    }
    /// <summary>
    /// Scaling
    /// </summary>
    public class Scaling
    {
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height { get; set; }
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width { get; set; }

    }
}