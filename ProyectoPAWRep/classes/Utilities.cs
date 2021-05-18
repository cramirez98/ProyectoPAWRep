using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPAWRep.classes
{
    public static class Utilities
    {
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
    }
}