﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace shinny_ssg
{

    class Page
    {
        private string _head;
        private string _title;
        private string _body;
        private string _cssString;
        public Page() { }
        public Page(string text)
        {
            var paraps = Regex.Split(text, "\r?\n\r?\n");
            //first line is _title
            _title = paraps[0];
            _cssString = String.IsNullOrEmpty(Globals.cssUrl)
                       ? "<style type ='text/css'> body { display: block;max-width: 800px; margin: 20px auto; padding: 0 10px; word-wrap: break-word  }</style >"
                       : $"<link rel =\"stylesheet\"href =\"{Globals.cssUrl}\" >";

            _head = $"<meta charset = \"utf-8\" >" +
                 _cssString +
                $"<title >{_title} </title >" +
                $"<meta name = \"viewport\" content = \"width=device-width, initial-scale=1\">";
            _body += $"<h1>{_title}</h1>";
            for (var i = 1; i < paraps.Length; i++)
            {
                var temp = Regex.Replace(paraps[i], "\r?\n", " ");
                _body += $"<p>{temp}</p>";
            }
        }

        public string GetPage()
        {
            //Creates a new file, write the contents to the file, and then closes the file. If the target file already exists, it is overwritten
            return $"<!DOCTYPE html> <html> <head> {_head} </head> <body>{_body}</body> </html>";
        }
    }
}
