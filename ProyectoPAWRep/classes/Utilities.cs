﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace ProyectoPAWRep.classes
{
    public static class Utilities
    {
        public static string ComputarSHA256(string rawData)
        {
            SHA256 sha256Hash = SHA256.Create();

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
  
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
        public static string ComputarSHA128(string rawData)
        {
            SHA1 sha128Hash = SHA1.Create();

            byte[] bytes = sha128Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
        public static string GenerateBigAlarm(string title, string body, string footer, string alarm_type)
        {
            string alarm;
            switch (alarm_type)
            {
                case "success":
                    alarm = "<div class='alert alert-success alert-dismissible fade show' role='alert'>";
                    break;
                case "danger":
                    alarm = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>";
                    break;
                case "primary":
                    alarm = "<div class='alert alert-primary alert-dismissible fade show' role='alert'>";
                    break;
                case "secondary":
                    alarm = "<div class='alert alert-secondary alert-dismissible fade show' role='alert'>";
                    break;
                case "warning":
                    alarm = "<div class='alert alert-warning alert-dismissible fade show' role='alert'>";
                    break;
                default:
                    alarm = "<div class='alert alert-dark alert-dismissible fade show' role='alert'>";
                    break;
            }
            alarm += "<h4 class='alert-heading'>"+title+"</h4>";
            alarm += "<p>"+body+"</p><hr>";
            alarm += "<p class='mb-0'>"+footer+ "</p><button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";

            return alarm;
        }
        public static string GenerateAlarm(string body, string alarm_type)
        {
            string alarm;
            switch (alarm_type)
            {
                case "success":
                    alarm = "<div class='alert alert-success d-flex align-items-center alert-dismissible fade show' role='alert'>";
                    break;
                case "danger":
                    alarm = "<div class='alert alert-danger d-flex align-items-center alert-dismissible fade show' role='alert'>";
                    break;
                case "primary":
                    alarm = "<div class='alert alert-primary d-flex align-items-center alert-dismissible fade show' role='alert'>";
                    break;
                case "secondary":
                    alarm = "<div class='alert alert-secondary d-flex align-items-center alert-dismissible fade show' role='alert'>";
                    break;
                case "warning":
                    alarm = "<div class='alert alert-warning d-flex align-items-center alert-dismissible fade show' role='alert'>";
                    break;
                default:
                    alarm = "<div class='alert alert-dark d-flex align-items-center alert-dismissible fade show' role='alert'>";
                    break;
            }
            alarm += "<div>"+body+ "</div> <button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button> <div>";

            return alarm;
        }
    }
}