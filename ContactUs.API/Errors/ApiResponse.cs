using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Talabat.API.Errors
{
   
    public class ApiResponse 
    {

        public int StatusCode { get; set; } 
        public string Masssage { get; set; }


        public ApiResponse( int statusCode ,string message=null)
        {
            StatusCode = statusCode ;
            Masssage = message ?? GetDefaultStatusCodeMassage(statusCode);
        }

        private string GetDefaultStatusCodeMassage(int statusCode)
   => statusCode switch
   {
       400 => "BadRequest, You Have Made",
       401 => "Authorized , You Are Not",
       404 => "Resource  was  Not Found ",
       500 => "Error are the path to the DarkSide , Errors lead to Anger",
       _ => null


   };
    }
    }

