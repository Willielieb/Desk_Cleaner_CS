using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Proxies;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Desk_Cleaner
{
    class EventHandler
    {
        public static Extensions extensions = new Extensions();
        public static void On_modified(string watchpath, string destination_path)
        {
            watchpath = Path.GetFullPath(watchpath);
            destination_path = Path.GetFullPath(destination_path);
            foreach (var child in Directory.EnumerateFiles(watchpath))
            {
                if (File.Exists(child) && (extensions.extension_paths.ContainsKey(Path.GetExtension(child))))
                {
                    destination_path = $"{destination_path}{Path.GetExtension(child)}";
                    destination_path = Edit_Path.Add_date_to_path(destination_path);
                    destination_path = Edit_Path.Rename_file(child, destination_path);
                    File.Move(child, destination_path);
                }
            }
        }
    }
}
