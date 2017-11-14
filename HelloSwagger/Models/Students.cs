﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace HelloSwagger.Models
{
    /// <summary>
    /// Studentasdf Modelsdaf
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Username
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// First Name
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name (Surname)
        /// </summary>
        //[Required]
        public string LastName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Birth Date
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Age
        /// </summary>
        public int? Age { get; set; }

    }
}