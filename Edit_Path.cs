﻿using System;
using System.IO;

namespace Desk_Cleaner
{
    internal class Edit_Path
    {
        public static string Add_date_to_path(string path)
        {
            string dated_path = $"{path}/{DateTime.Today.Year}/{DateTime.Today.Month}";
            if (Directory.Exists(dated_path))
            {
                return dated_path;
            }
            else
            {
                Directory.CreateDirectory(dated_path);
                return dated_path;
            }
        }

        public static string Rename_file(string source, string destination_path)
        {
            if (Directory.Exists($"{destination_path}/{Path.GetFileName(source)}"))
            {
                int increment = 0;
                do
                {
                    increment += 1;
                    string new_name = $"{destination_path}{Path.GetFileNameWithoutExtension(source)}_{increment}{Path.GetExtension(source)}";

                    if (!Directory.Exists(new_name))
                    {
                        return new_name;
                    }
                } while (true);
            }
            else
            {
                return $"{destination_path}{Path.GetFileName(source)}";
            }
        }
    }
}